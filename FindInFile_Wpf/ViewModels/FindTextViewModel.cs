using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile.Models.Messages;
using FindInFile.Wpf.Utilities;
using FindInFile.Wpf.ViewModels.Commands;
using FindInFile.Wpf.Views;
using GalaSoft.MvvmLight.Messaging;

namespace FindInFile.Wpf.ViewModels
{
    public class FindTextViewModel : IViewModel, INotifyPropertyChanged
    {
        private const string DEFAULT_QUERY = "Get-EmpiEnvironment";
        private const string DEFAULT_ROOT_PATH = @"C:\Users\D760026\Documents\WindowsPowerShell";
        private const string DEFAULT_FILTER = "*.ps1, *.psd1, *.psm1, *.cs, *.cshtml, *.html, *.txt, *.js";

        #region Find Group Private Members
        private string m_QueryText;
        private bool m_RecursiveChecked;
        private bool m_FuzzySearchChecked;
        private bool m_MatchCaseChecked;
        private bool m_CopyToClipBoardChecked;
        private ICommand m_FindClicked;
        #endregion

        #region Filter Group Private Members
        private string m_FilterText;
        private ICommand m_AdvancedClick;
        #endregion

        #region Folder Group Private Members
        private string m_RootPathText;
        private ICommand m_BrowseClick;
        #endregion

        #region Window Private Members
        private ObservableCollection<SearchMatch> m_MatchList;
        private Guid m_AuthToken;
        private string m_StatusBarText;
        private string m_StatusBarTextColor;
        private bool m_QueryProvided;
        private ICommand m_OpenFileCommand;
        #endregion

        #region Find Group Public Members
        public string QueryText {
            get { return m_QueryText; }
            set
            {
                m_QueryText = value;
                QueryProvided = !string.IsNullOrEmpty(value);
                NotifyPropertyChanged();
            }
        }

        public bool RecursiveChecked {
            get { return m_RecursiveChecked; }
            set { m_RecursiveChecked = value; NotifyPropertyChanged(); }
        }

        public bool FuzzySearchChecked
        {
            get { return m_FuzzySearchChecked; }
            set { m_FuzzySearchChecked = value; NotifyPropertyChanged(); }
        }

        public bool MatchCaseChecked
        {
            get { return m_MatchCaseChecked; }
            set { m_MatchCaseChecked = value; NotifyPropertyChanged(); }
        }

        public bool CopyToClipboardChecked
        {
            get { return m_CopyToClipBoardChecked; }
            set { m_CopyToClipBoardChecked = value; NotifyPropertyChanged(); }
        }

        public ICommand FindClicked {
            get { return m_FindClicked; }
            set { m_FindClicked = value; }
        }
        #endregion

        #region Filter Group Public Members
        public string FilterText
        {
            get { return m_FilterText; }
            set { m_FilterText = value; NotifyPropertyChanged(); }
        }

        public ICommand AdvancedClicked
        {
            get { return m_AdvancedClick; }
            set { m_AdvancedClick = value; }
        }
        #endregion

        #region Folder Group Public Members
        public string RootPathText
        {
            get { return m_RootPathText; }
            set { m_RootPathText = value; NotifyPropertyChanged(); }
        }

        public ICommand BrowseClicked
        {
            get { return m_BrowseClick; }
            set { m_BrowseClick = value; }
        }
        #endregion

        #region Window Public Members
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<SearchMatch> MatchList
        {
            get { return m_MatchList; }
            set
            {
                m_MatchList = value;
                if (m_MatchList.Any()) QueryProvided = true;
                NotifyPropertyChanged();
            }
        }

        public string StatusBarText
        {
            get { return m_StatusBarText; }
            set { m_StatusBarText = value; NotifyPropertyChanged(); }
        }

        public string StatusBarTextColor
        {
            get { return m_StatusBarTextColor; }
            set { m_StatusBarTextColor = value; NotifyPropertyChanged(); }
        }

        public bool QueryProvided
        {
            get { return m_QueryProvided; }
            set { m_QueryProvided = value; NotifyPropertyChanged(); }
        }

        public ICommand OpenFileCommand
        {
            get { return m_OpenFileCommand; }
            set { m_OpenFileCommand = value; }
        }
        #endregion

        public FindTextViewModel()
        {
            /* ------------------------------------------------------------------------
             * Since we create instances of this class in the TabManager Constructor
             * we need to wait until the TabManager is fully initialzed before we 
             * call Initialize() as the method uses TabManager to resolve the auth
             * token for this view model instance, i.e we can resolve it if the class
             * isnt fully contructed yet. 
             ------------------------------------------------------------------------ */
            if (TabManager<FindTextViewModel>.Instance.Initialized == false)
            {
                Messenger.Default.Register<TabManagerInitializedMessage>(this, message =>
                {
                    Initialize();
                    Messenger.Default.Unregister(this);
                });
            }
            else
            {
                Initialize();
            }
        }

        public void UpdateStatusBar(string text, string color = "Green")
        {
            StatusBarText = text;
            StatusBarTextColor = color;
        }

        public void Initialize()
        {
#if DEBUG
            QueryText = DEFAULT_QUERY;
            RootPathText = DEFAULT_ROOT_PATH;
            FilterText = DEFAULT_FILTER;
            RecursiveChecked = true;
#endif
            FindClicked = new FindCommand(this);
            BrowseClicked = new BrowseCommand(this);
            AdvancedClicked = new RelayCommand(RetrieveExtensions);
            OpenFileCommand = new RelayCommand(OpenFile);

            m_AuthToken = TabManager<FindTextViewModel>.Instance.ResolveActiveTabToken();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RetrieveExtensions(object parameter)
        {
            var fileExtensionDialog = new FileExtensionDialog(); //TODO: Convert to idisposable so it can be places in a using block
            //fileExtensionDialog.Owner = this;

            Messenger.Default.Register<ReturnExtensionsMessage>(this, m_AuthToken, (message) => 
            {
                MergeFiltersFromMessage(message.Extensions);
            });

            Messenger.Default.Send(new FileExtensionDialogInitializationMessage()
            {
                FolderPath = m_RootPathText,
                RecursiveChecked = m_RecursiveChecked
            }, m_AuthToken);

            fileExtensionDialog.ShowDialog();
        }

        private void OpenFile(object parameter)
        {
            try
            {
                var match = parameter as SearchMatch;

                if (!string.IsNullOrEmpty(match?.Path))
                    System.Diagnostics.Process.Start(match.Path);
            }
            catch
            {
                // Handle this
            }
        }

        private void MergeFiltersFromMessage(List<ExtensionCellItem> extensionsToMerge)
        {
            HashSet<string> extensions = null;
            if (!string.IsNullOrEmpty(m_FilterText))
            {
                string[] currentExtensions = m_FilterText.Replace(" ", "").Replace("*", "").Split(',');
                extensions = new HashSet<string>(currentExtensions);
            }
            extensions.UnionWith(extensionsToMerge.Select(ext => ext.Extension));

            StringBuilder sb = new StringBuilder();
            foreach (var extension in extensions)
            {
                sb.Append('*');
                sb.Append(extension);
                sb.Append(", ");
            }

            if (sb != null)
            {
                sb.Remove(sb.Length - 2, 2); //Removes last ", "
                FilterText = sb.ToString();
            }
        }
    }
}

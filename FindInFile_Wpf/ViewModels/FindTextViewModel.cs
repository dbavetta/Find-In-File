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
using FindInFile.Wpf.ViewModels.Commands;
using FindInFile.Wpf.Views;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;

namespace FindInFile.Wpf.ViewModels
{
    public class FindTextViewModel : IViewModel, INotifyPropertyChanged, IModule
    {
        private const string DEFAULT_QUERY = "Get-EmpiEnvironment";
        private const string DEFAULT_ROOT_PATH = @"C:\Users\D760026\Documents\WindowsPowerShell";
        private const string DEFAULT_FILTER = "*.ps1, *.psd1, *.psm1, *.cs, *.cshtml, *.html, *.txt, *.js";
        private ObservableCollection<SearchMatch> m_MatchList;
        private SubscriptionToken subscriptionToken;
        public IUnityContainer Container { get; private set; }

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
        private string m_StatusBarText;
        private string m_StatusBarTextColor;
        #endregion

        #region Find Group Public Members
        public string QueryText {
            get { return m_QueryText; }
            set { m_QueryText = value; NotifyPropertyChanged(); }
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

        public ICommand AdvancedClick
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

        public ICommand BrowseClick
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
            set { m_MatchList = value; NotifyPropertyChanged(); }
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
        #endregion

        public FindTextViewModel()
        {
            FindClicked = new FindCommand(this);
            BrowseClick = new BrowseCommand(this);
            AdvancedClick = new RelayCommand(RetrieveExtensions);

#if DEBUG
            QueryText = DEFAULT_QUERY;
            RootPathText = DEFAULT_ROOT_PATH;
            FilterText = DEFAULT_FILTER;
            RecursiveChecked = true;
            FuzzySearchChecked = true;
            StatusBarText = "Place Holder Text...";
            StatusBarTextColor = "Green";

            Messenger.Default.Register<ReturnExtensionsMessage>(this, message => {
                MergeFiltersFromMessage(message.Extensions);
            });
#endif
        }

        public void Initialize()
        {
            
        }

        public void UpdateStatusBar(string text, string color = "Green")
        {
            StatusBarText = text;
            StatusBarTextColor = color;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RetrieveExtensions(object parameter)
        {
            Guid authorizationToken = Guid.NewGuid();
            var fileExtensionDialog = new FileExtensionDialog(authorizationToken); //Convert to idisposable so it can be places in a using block
            fileExtensionDialog.Show();

            Messenger.Default.Send(new FileExtensionDialogInitializationMessage()
            {
                FolderPath = m_RootPathText,
                RecursiveChecked = m_RecursiveChecked
            }, authorizationToken);
        }

        private void MergeFiltersFromMessage(List<ExtensionCellItem> extensionsToMerge)
        {
            string[] currentExtensions = m_FilterText.Replace(" ", "").Replace("*", "").Split(',');
            HashSet<string> extensions = new HashSet<string>(currentExtensions);
            extensions.UnionWith(extensionsToMerge.Select(ext => ext.Extension));

            StringBuilder sb = new StringBuilder();
            foreach (var extension in extensions)
            {
                sb.Append('*');
                sb.Append(extension);
                sb.Append(", ");
            }

            //Remove last ", "
            sb?.Remove(sb.Length - 2, 2);

            FilterText = sb.ToString();
        }
    }
}

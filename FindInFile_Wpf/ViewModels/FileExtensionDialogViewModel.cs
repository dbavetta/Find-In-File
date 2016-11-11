using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile.Models.Messages;
using FindInFile.Wpf.Interfaces;
using FindInFile.Wpf.Utilities;
using FindInFile.Wpf.ViewModels.Commands;
using GalaSoft.MvvmLight.Messaging;
using SearchAggregatorUtility;

namespace FindInFile.Wpf.ViewModels
{
    public class FileExtensionDialogViewModel : INotifyPropertyChanged, IViewModel
    {
        public int ColumnCount = 8;

        #region Private Properties
        private List<ExtensionCellItem> m_ExtensionGrid;
        private string m_FolderPath;
        private bool m_RecursiveChecked;
        private bool m_hasReturnItems;
        private ICommand m_RetrieveExtentionsCommand;
        private ICommand m_OkayCommand;
        private ICommand m_CancelCommand;
        private Guid m_AuthToken;
        #endregion

        #region Public Properties
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ExtensionCellItem> ExtensionGrid
        {
            get { return m_ExtensionGrid; }
            set { m_ExtensionGrid = value; NotifyPropertyChanged(); }
        }

        public string FolderPath
        {
            get { return m_FolderPath; }
            set { m_FolderPath = value; NotifyPropertyChanged(); }
        }

        public bool RecursiveChecked
        {
            get { return m_RecursiveChecked; }
            set { m_RecursiveChecked = value; NotifyPropertyChanged(); }
        }

        public bool HasReturnItems
        {
            get { return m_hasReturnItems; }
            set { m_hasReturnItems = value; NotifyPropertyChanged(); }
        }

        public ICommand RetrieveExtensionCommand
        {
            get { return m_RetrieveExtentionsCommand; }
            set { m_RetrieveExtentionsCommand = value; }
        }
        public ICommand OkayCommand
        {
            get { return m_OkayCommand; }
            set { m_OkayCommand = value; }
        }

        public ICommand CancelCommand
        {
            get { return m_CancelCommand; }
            set { m_CancelCommand = value; }
        }
        #endregion

        public FileExtensionDialogViewModel()
        {
            Initialize();
        }

        public void Initialize()
        {
            m_AuthToken = TabManager<FindTextViewModel>.Instance.ResolveActiveTabToken();

            RetrieveExtensionCommand = new RelayCommand(RetrieveExtensions);
            OkayCommand = new RelayCommand(ReturnResultsToViewModel);
            CancelCommand = new RelayCommand(CloseDialog);

            Messenger.Default.Register<FileExtensionDialogInitializationMessage>(this, m_AuthToken, message => {
                FolderPath = message.FolderPath;
                RecursiveChecked = message.RecursiveChecked;
                Messenger.Default.Unregister<FileExtensionDialogInitializationMessage>(this); //One time message
            });
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RetrieveExtensions(object parameter)
        {
            var dataGrid = new List<ExtensionCellItem>();

            var extensions = DirectoryExplorer.GetExtensions(m_FolderPath, m_RecursiveChecked).GroupBy(ext => ext).OrderByDescending(ext => ext.Count());

            if (extensions != null && extensions.Count() > 0)
            {
                foreach (var extension in extensions)
                {
                    dataGrid.Add(new ExtensionCellItem(extension.Key, extension.Count()));
                }

                ExtensionGrid = dataGrid;
                HasReturnItems = true;
            }
        }

        private void ReturnResultsToViewModel(object parameter)
        {
            var extensionsList = new List<ExtensionCellItem>();
            foreach (var extension in m_ExtensionGrid)
            {
                if (extension.Include)
                    extensionsList.Add(extension);
            }

            Messenger.Default.Send(new ReturnExtensionsMessage(extensionsList), m_AuthToken);
            CloseDialog(parameter);
        }

        private void CloseDialog(object parameter)
        {
            if (parameter != null)
            {
                IClosable window = parameter as IClosable;
                window.Close();
            }  
        }
    }
}

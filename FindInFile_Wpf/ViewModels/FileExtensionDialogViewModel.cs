using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile.Models.Messages;
using FindInFile.Wpf.ViewModels.Commands;
using FindInFile.Wpf.Views;
using FindInFile_Wpf.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using SearchAggregatorUtility;

namespace FindInFile.Wpf.ViewModels
{
    public class FileExtensionDialogViewModel : INotifyPropertyChanged
    {
        public int ColumnCount = 8;

        private List<ExtensionCellItem> m_ExtensionGrid;
        private string m_FolderPath;
        private bool m_RecursiveChecked;
        private ICommand m_RetrieveExtentionsCommand;
        private ICommand m_OkayCommand;
        private ICommand m_CancelCommand;

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

        public FileExtensionDialogViewModel()
        {
            RetrieveExtensionCommand = new RelayCommand(RetrieveExtensions);
            OkayCommand = new RelayCommand(ReturnResultsToViewModel);
            CancelCommand = new RelayCommand(CloseDialog);

            Messenger.Default.Register<FileExtensionDialogInitializationMessage>(this, message => {
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

            Messenger.Default.Send(new ReturnExtensionsMessage(extensionsList));
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile_Wpf.ViewModels.Commands;

namespace FindInFile_Wpf.ViewModels
{
    public class FileExtensionDialogViewModel : INotifyPropertyChanged
    {
        public int ColumnCount = 8;

        private const string DEFAULT_ROOT_PATH = @"C:\Users\D760026\Documents\WindowsPowerShell";
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
            //Send request  for the root path to main form view 
            FolderPath = DEFAULT_ROOT_PATH;
            //Initialize Commands
            RetrieveExtensionCommand = new RetrieveExtensionsCommand(this);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

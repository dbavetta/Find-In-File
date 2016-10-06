using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FindInFile_Wpf.ViewModels.Commands
{
    public class BrowseCommand : ICommand
    {
        private FindTextViewModel m_FindTextViewModel;

        public BrowseCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //Open Folder browser dialog
            //Set formviews folder path property to result
            MessageBox.Show("Browse Click");
        }
        #endregion
    }
}

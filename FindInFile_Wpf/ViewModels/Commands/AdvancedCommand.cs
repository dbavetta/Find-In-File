using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FindInFile_Wpf.ViewModels.Commands
{
    public class AdvancedCommand : ICommand
    {
        private FindTextViewModel m_FindTextViewModel;

        public AdvancedCommand(FindTextViewModel viewModel)
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
            //Open Filter Dialog
            //Return result to list view
            MessageBox.Show("Advanced Click");
        }
        #endregion

    }
}

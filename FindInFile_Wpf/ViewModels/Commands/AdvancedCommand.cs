using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FindInFile_Wpf.Views;

namespace FindInFile.Wpf.ViewModels.Commands
{
    public class AdvancedCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;

        public AdvancedCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members
        public override void Execute(object parameter)
        {
            //TODO: Open Filter Dialog
            //TODO: Return result to list view
            var fileExtensionDialog = new FileExtensionDialog(); //Convert to idisposable s it can be places in a using block
            fileExtensionDialog.Show();
            //MessageBox.Show("Advanced Click");
        }
        #endregion
    }
}

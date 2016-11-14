using System.Windows.Forms;

namespace FindInFile.Wpf.ViewModels.Commands
{
    public class BrowseCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;

        public BrowseCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members
        public override void Execute(object parameter)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                    m_FindTextViewModel.RootPathText = dialog.SelectedPath;
            }
        }
        #endregion
    }
}

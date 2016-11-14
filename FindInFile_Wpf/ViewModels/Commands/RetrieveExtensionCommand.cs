using System;

namespace FindInFile.Wpf.ViewModels.Commands
{
    public class RetrieveExtensionCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;
        private readonly Guid m_AuthToken;

        public RetrieveExtensionCommand(FindTextViewModel viewModel, Guid authToken)
        {
            m_FindTextViewModel = viewModel;
            m_AuthToken = authToken;
        }

        public override void Execute(object parameter)
        {
            //var fileExtensionDialog = new FileExtensionDialog(); //TODO: Convert to idisposable so it can be places in a using block
            ////fileExtensionDialog.Owner = this;

            //Messenger.Default.Register<ReturnExtensionsMessage>(this, m_AuthToken, (message) =>
            //{
            //    MergeFiltersFromMessage(message.Extensions);
            //});

            //Messenger.Default.Send(new FileExtensionDialogInitializationMessage()
            //{
            //    FolderPath = m_RootPathText,
            //    RecursiveChecked = m_RecursiveChecked
            //}, m_AuthToken);

            //fileExtensionDialog.ShowDialog();
        }
    }
}
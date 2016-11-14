using FindInFile.Wpf.Views;

namespace FindInFile.Wpf.ViewModels.Commands
{
    public class OpenSettingsCommand : BaseCommand
    {
        public OpenSettingsCommand() { }

        public override void Execute(object parameter)
        {
            var settingsDialog = new SettingsDialog(); //TODO: Convert to idisposable so it can be places in a using block
            //settingsDialog.Owner = this;
            settingsDialog.ShowDialog();
        }
    }
}

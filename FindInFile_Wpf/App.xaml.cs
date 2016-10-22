using System.Windows;
using FindInFile.Models.Messages;
using FindInFile.Wpf.Utilities;
using FindInFile.Wpf.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace FindInFile.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            TabManager<FindTextViewModel>.Instance.Initialize();
            Messenger.Default.Send(new TabManagerInitializedMessage());
            //Bootstrapper bootstrapper = new Bootstrapper();
            //bootstrapper.Run();
        }
    }
}

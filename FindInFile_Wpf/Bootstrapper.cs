using System.Windows;
using FindInFile.Wpf.Modules;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;

namespace FindInFile.Wpf
{
    public class Bootstrapper : UnityBootstrapper 
    {
        protected override DependencyObject CreateShell()
        {
            //return Container.Resolve<Shell>(); //Deleted shell.xaml
            return null;
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(FindTextModule));


            //Type findTextModuleType = typeof(FindTextModule);
            ////Type settingsModuleType = typeof(SettingsModule);

            //ModuleCatalog.AddModule(new ModuleInfo() {
            //    ModuleName = findTextModuleType.Name,
            //    ModuleType = findTextModuleType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.WhenAvailable
            //});
        }
    }
}

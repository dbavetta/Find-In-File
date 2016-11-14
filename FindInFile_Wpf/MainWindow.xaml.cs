using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using FindInFile.Models;
using FindInFile.Wpf.Utilities;
using FindInFile.Wpf.ViewModels;

namespace FindInFile.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            var tab = tabControl?.SelectedItem as TabObject<FindTextViewModel>;

            if (tab != null)
            {
                TabManager<FindTextViewModel>.Instance.SwitchToTab(tab);
                tabControl.SelectedItem = TabManager<FindTextViewModel>.Instance.ActiveTab;
            }
        }

        private void RestartApplication()
        {
            System.Windows.Forms.Application.Restart();
            Application.Current.Shutdown();
        }
    }
}

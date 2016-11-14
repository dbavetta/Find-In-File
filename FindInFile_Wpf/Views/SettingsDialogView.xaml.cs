using System.Configuration;
using System.Windows;
using FindInFile.Wpf.Interfaces;

namespace FindInFile.Wpf.Views
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsDialog : Window, IClosable
    {
        public SettingsDialog()
        {
            InitializeComponent();
        }
    }
}

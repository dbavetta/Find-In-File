using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FindInFile_Wpf.Models;

namespace FindInFile_Wpf
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

        // Open File
        private void HandleListViewDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Match match = ((ListViewItem)sender).Content as Match;

            if (match != null && !string.IsNullOrEmpty(match.Path))
                Process.Start(match.Path);
        }
    }
}

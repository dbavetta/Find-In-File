using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FindInFile.Models;

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

        // Open File
        private void HandleListViewDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SearchMatch match = ((ListViewItem)sender).Content as SearchMatch;

            if (match != null && !string.IsNullOrEmpty(match.Path))
                Process.Start(match.Path);
        }
    }
}

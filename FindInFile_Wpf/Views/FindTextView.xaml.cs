using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;
using FindInFile.Models;
using FindInFile.Wpf.ViewModels;

namespace FindInFile.Wpf.Views
{
    /// <summary>
    /// Interaction logic for FindTextView.xaml
    /// </summary>
    public partial class FindTextView : UserControl
    {
        // Open File
        private void HandleListViewDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SearchMatch match = ((ListViewItem)sender).Content as SearchMatch;

            if (match != null && !string.IsNullOrEmpty(match.Path))
                Process.Start(match.Path);
        }
    }
}

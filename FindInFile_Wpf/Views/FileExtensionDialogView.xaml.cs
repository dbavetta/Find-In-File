using System.Windows;
using FindInFile.Wpf.Interfaces;

namespace FindInFile.Wpf.Views
{
    /// <summary>
    /// Interaction logic for FileExtensionDialog.xaml
    /// </summary>
    public partial class FileExtensionDialog : Window, IClosable
    {
        public FileExtensionDialog()
        {
            InitializeComponent();
        }
    }
}

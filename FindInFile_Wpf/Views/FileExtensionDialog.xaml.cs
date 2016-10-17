using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FindInFile_Wpf.Interfaces;
using GalaSoft.MvvmLight.Messaging;

namespace FindInFile.Wpf.Views
{
    /// <summary>
    /// Interaction logic for FileExtensionDialog.xaml
    /// </summary>
    public partial class FileExtensionDialog : Window, IClosable
    {
        public Guid m_AuthorizationToken;

        public FileExtensionDialog(Guid authorizationToken)
        {
            InitializeComponent();

            m_AuthorizationToken = authorizationToken;
        }
    }
}

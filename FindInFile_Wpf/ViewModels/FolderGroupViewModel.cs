using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindInFile_Wpf.ViewModels.Commands;

namespace FindInFile_Wpf.ViewModels
{
    public class FolderGroupViewModel
    {
        #region Private Members
        private string m_RootPathText;
        private ICommand m_BrowseClick;
        #endregion

        #region Public Members
        public string RootPathText
        {
            get { return m_RootPathText; }
            set { m_RootPathText = value; }
        }

        public ICommand BrowseClick
        {
            get { return m_BrowseClick; }
            set { m_BrowseClick = value; }
        }
        #endregion

        public FolderGroupViewModel()
        {
            //m_BrowseClick = new BrowseCommand(this);
        }
    }
}

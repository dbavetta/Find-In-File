using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FindInFile_Wpf.ViewModels.Commands;

namespace FindInFile_Wpf.ViewModels
{
    public class FilterGroupViewModel
    {
        private string m_FilterText;
        private ICommand m_AdvancedClick;

        public string FilterText
        {
            get { return m_FilterText; }
            set { m_FilterText = value; }
        }

        public ICommand AdvancedClick
        {
            get { return m_AdvancedClick; }
            set { m_AdvancedClick = value; }
        }

        public FilterGroupViewModel()
        {
            //m_AdvancedClick = new AdvancedCommand(this);
        }
    }
}

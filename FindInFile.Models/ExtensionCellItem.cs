using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInFile.Models
{
    public class ExtensionCellItem
    {
        private bool m_Checked;
        private string m_Text;

        public bool Checked
        {
            get { return m_Checked; }
        }

        public string Text
        {
            get { return m_Text; }
        }

        public ExtensionCellItem(bool isChecked, string text)
        {
            m_Checked = isChecked;
            m_Text = text;
        }
    }
}

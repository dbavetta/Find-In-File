using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInFile.Models
{
    public class TabObject<ViewModel>
    {
        public int Index { get; set; }
        public string Header { get; set; }
        public ViewModel Content { get; set; }
        public TabObject()
        {

        }

        public bool Equals(TabObject<ViewModel> tab)
        {
            bool equals = false;
            equals = this.Index == tab.Index;
            equals = equals && this.Header == tab.Header;
            return equals;
        }
    }
}

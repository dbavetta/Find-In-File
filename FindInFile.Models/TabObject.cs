using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInFile.Models
{
    public class TabObject<T>
    {
        public int Index { get; set; }
        public string Header { get; set; }
        public T Content { get; set; }
        public TabObject()
        {

        }

        public bool Equals(TabObject<T> tab)
        {
            bool equals = false;
            equals = this.Index == tab.Index;
            equals = equals && this.Header == tab.Header;
            return equals;
        }
    }
}

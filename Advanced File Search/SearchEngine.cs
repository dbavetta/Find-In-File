using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public class SearchEngine
    {
        // Find components
        private string searchQuery;
        private string filePath;
        private string searchFilter;

        // Find options
        private bool recursiveSearch;
        private bool fuzzySearch;
        private bool matchCase;
        private bool copyToClipboard;

        public SearchEngine() { }

        public SearchEngine(SearchForm form)
        {
        }
    }
}

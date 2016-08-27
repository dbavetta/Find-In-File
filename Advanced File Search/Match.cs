using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_File_Search
{
    class Match
    {
        public string path;
        public string text;
        public int lineNumber;
        public Match(string p, string t, int ln)
        {
            path = p;
            text = t;
            lineNumber = ln;
        }

        public string[] GetRow()
        {
            return new string[] { path, lineNumber.ToString(), text.Trim() };
        }
    }
}

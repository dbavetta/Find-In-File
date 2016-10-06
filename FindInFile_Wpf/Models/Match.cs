using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInFile_Wpf.Models
{
    public class Match
    {
        private string m_Path;
        private string m_ShortenedPath;
        private int m_LineNumber;
        private string m_ResultText;

        public string Path
        {
            get { return m_Path; }
        }

        public string ShortenedPath
        {
            get { return m_ShortenedPath; }
        }
        public int LineNumber
        {
            get { return m_LineNumber; }
        }
        public string ResultText
        {
            get { return m_ResultText; }
        }

        public Match(string p, string sp, int ln, string t)
        {
            m_Path = p;
            m_ShortenedPath = sp;
            m_LineNumber = ln;
            m_ResultText = t;
        }
    }
}

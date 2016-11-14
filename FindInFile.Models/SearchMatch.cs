namespace FindInFile.Models
{
    public class SearchMatch
    {
        private string m_Path;
        private string m_ShortenedPath;
        private int m_LineNumber;
        private string m_MatchedText;
        private string m_MatchedLine;
        private LineMatch m_LineMatch;

        public string Path
        {
            get { return m_Path; }
        }

        public string ShortenedPath
        {
            get { return m_ShortenedPath; }
            set { m_ShortenedPath = value; }
        }
        public int LineNumber
        {
            get { return m_LineNumber; }
        }

        public string MatchedText
        {
            get { return m_MatchedText; }
        }

        public string MatchedLine
        {
            get { return m_MatchedLine; }
        }

        //To be used later in development
        public string[] MatchedLineParts
        {
            get { return m_LineMatch.Parts; }
        }

        public SearchMatch(string path, string shortPath, int lineNumber, string matchedText, string matchedLine)
        {
            m_Path = path;
            m_ShortenedPath = shortPath;
            m_LineNumber = lineNumber;
            m_MatchedText = matchedText;
            m_MatchedLine = matchedLine;
            m_LineMatch = new LineMatch(m_MatchedLine, m_MatchedText);
        }
    }
}

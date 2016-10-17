using System.Text.RegularExpressions;

namespace FindInFile.Models
{
    public class LineMatch
    {
        private string m_LineText;
        private string m_MatchText;
        private string[] m_LineMatchParts;

        //public string LineText
        //{
        //    get { return m_LineText; }
        //}

        //public string MatchText
        //{
        //    get { return m_MatchText; }
        //}

        public string[] Parts
        {
            get { return m_LineMatchParts; }
        }

        //TODO: Create search options model that can be passed around so regex can pull matches based on case sensitivity

        public LineMatch(string lineText, string matchText)
        {
            m_LineText = lineText;
            m_MatchText = matchText;
            m_LineMatchParts = ParseMatchedLine();
        }

        private string[] ParseMatchedLine()
        {
            // Adding parathesis around the delimeter includes the delimeter in the resulting array
            Regex match = new Regex("(" + m_MatchText + ")");
            return match.Split(m_LineText);
        }
    }
}

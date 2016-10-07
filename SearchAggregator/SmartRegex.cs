using System.Text.RegularExpressions;

namespace SearchAggregatorUtility
{
    public class SmartRegex : Regex
    {
        public SmartRegex(string pattern) : base(StringToRegex(pattern))
        {
        }

        public SmartRegex(string pattern, RegexOptions options) : base(StringToRegex(pattern), options)
        {
        }

        public static string StringToRegex(string pattern)
        {
            return "^" + 
             Regex.Escape(pattern).
             Replace("\\*", ".*").
             Replace("\\?", ".").
             Replace(",", "|") + 
             "$";
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public class SearchEngine
    {
        private ConcurrentBag<Match> m_MatchList;
        private bool m_SingleFile = true;

        public SearchEngine() //EventListener listener
        {
            m_MatchList = new ConcurrentBag<Match>();
        }

        public List<Match> SearchFileSet(string query, IEnumerable<string> files, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false)
        {
            m_SingleFile = false;

            if (!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            files.AsParallel().ForAll(currentFile => {

                SearchFile(query, currentFile, fuzzySearch, matchCase, copyToClipboard);
            });

            return m_MatchList.ToList();
        }

        public List<Match> SearchFile(string query, string filePath, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false)
        {
            if(m_SingleFile && !m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            List<Match> matches = FindMatchesInFile(filePath, query, fuzzySearch, matchCase);

            if (matches.Count > 0)
            {
                foreach (var match in matches)
                    m_MatchList.Add(match);

                // Copy searched for text to system clipboard
                if (copyToClipboard)
                    Clipboard.SetText(query);
            }

            return m_MatchList.ToList();
        }

        public IEnumerable<string> GetAllFilesInDirectory(string rootPath, string filter, bool recursive = false)
        {
            Regex _filter = ConvertStringToRegex(filter);

            return GetAllFilesInDirectory(rootPath, _filter, recursive);
        }

        public IEnumerable<string> GetAllFilesInDirectory(string rootPath, Regex filter, bool recursive = false)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(file => filter.IsMatch(Path.GetExtension(file)));
        }

        //Convert the users filter query to regex ~ needed for search
        private Regex ConvertStringToRegex(string text)
        {
            //*.psd1, *.psm1, *.cs, *.cshtml, *.txt" --> \.mp3|\.mp4
            string temp = text.Replace(",", "|").Replace("*", @"\").Replace(" ", "");
            return new Regex(temp, RegexOptions.IgnoreCase);
        }

        private List<Match> FindMatchesInFile(string filePath, string searchQuery, bool fuzzySearch, bool matchCase)
        {
            if (!fuzzySearch)
            {
                return File.ReadLines(filePath)
                .Select((text, index) => new Match(filePath, text, index + 1))
                          .Where(line =>
                              matchCase ?
                                Regex.IsMatch(line.text, @"(^|\s)" + searchQuery + @"(\s|$)") :
                                Regex.IsMatch(line.text, @"(^|\s)" + searchQuery + @"(\s|$)", RegexOptions.IgnoreCase)).ToList();
            }
            else
            {
                return File.ReadLines(filePath)
                    .Select((text, index) => new Match(filePath, text, index + 1))
                              .Where(line => 
                                  matchCase ?
                                    line.text.Contains(searchQuery) :
                                    line.text.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        #region Utility Methods
        #endregion
    }
}

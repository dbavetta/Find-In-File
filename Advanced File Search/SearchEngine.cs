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

        public SearchEngine() //EventListener listener
        {
            //add event listener as parameter
            // Initialize 

            m_MatchList = new ConcurrentBag<Match>();
        }

        public List<Match> SearchFileSet(string query, IEnumerable<string> files, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false)
        {
            if (!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            files.AsParallel().ForAll(currentFile => {

                SearchFile(query, currentFile, fuzzySearch, matchCase, copyToClipboard);
            });

            return m_MatchList.ToList();
        }

        public List<Match> SearchFile(string query, string filePath, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false)
        {
            if(!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            List<Match> matches = FindMatchesInFile(query, filePath, fuzzySearch, matchCase);

            if (matches != null)
            {
                foreach (var match in matches)
                    m_MatchList.Add(match);

                // Copy searched for text to system clipboard
                if (copyToClipboard)
                    Clipboard.SetText(query);
            }

            return m_MatchList.ToList();
        }

        public IEnumerable<string> GetAllFilesInDirectory(string rootPath, Regex filter, bool recursive = false)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(file => filter.IsMatch(Path.GetExtension(file)));
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
                                    line.text.Contains(searchQuery, StringComparison.Ordinal) :
                                    line.text.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        #region Utility Methods
        #endregion
    }
}

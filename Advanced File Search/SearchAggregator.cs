﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public class SearchAggregator
    {
        private readonly string m_Query;
        private readonly bool m_FuzzySearch;
        private readonly bool m_matchCase;
        private readonly bool m_CopyToClipboard;

        private ConcurrentBag<Match> m_MatchList;

        private IEnumerable<string> m_FilesToSearch;

        private bool m_SingleFile = true;

        public SearchAggregator()
        {
            // Empty
        }

        public SearchAggregator(string query, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false) //EventListener listener
        {
            m_Query = query;
            m_FuzzySearch = fuzzySearch;
            m_matchCase = matchCase;
            m_CopyToClipboard = copyToClipboard;
            m_MatchList = new ConcurrentBag<Match>();
        }

        // Method 1
        public List<Match> SearchFileSet()
        {
            m_SingleFile = false;

            if (!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            m_FilesToSearch.AsParallel().ForAll(currentFilePath => {

                SearchFile(currentFilePath);
            });

            return m_MatchList.ToList();
        }

        public List<Match> SearchFile(string filePath)
        {
            if(m_SingleFile && !m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<Match>();

            List<Match> matches = FindMatchesInFile(filePath, m_Query, m_FuzzySearch, m_matchCase);

            if (matches.Count > 0)
            {
                foreach (var match in matches)
                    m_MatchList.Add(match);

                // Copy searched for text to system clipboard
                if (m_CopyToClipboard)
                    Clipboard.SetText(m_Query);
            }

            return m_MatchList.ToList();
        }

        public int GetFileCount()
        {
            return m_FilesToSearch != null ? m_FilesToSearch.Count() : 0;
        }

        /// <summary>
        /// To be used in conjuction with the empty constructor, as a utility method, to gather all files within a specified directory.
        /// - Not intended to be used for a content search.
        /// - Target Usage: FilterDiaglog
        /// </summary>
        /// <param name="rootPath"> The base directory to retrieve filepaths from </param>
        /// <param name="extensionFilter"> Ex. *.psd1, *.psm1, *.cs </param>
        /// <param name="recursive"> Specifies whether or not to include sub directories in the iteration </param>
        /// <returns></returns>
        public IEnumerable<string> ReturnAllFilesInDirectory(string rootPath, string extensionFilter, bool recursive = false)
        {
            Regex filter = ConvertStringToRegex(extensionFilter);
            return GetAllFilesInDirectory(rootPath, filter, recursive);
        }

        public void GetAllFilesInDirectory(string rootPath, string extensionFilter, bool recursive = false)
        {
            Regex filter = ConvertStringToRegex(extensionFilter);
            m_FilesToSearch = GetAllFilesInDirectory(rootPath, filter, recursive);
        }

        private IEnumerable<string> GetAllFilesInDirectory(string rootPath, Regex extensionFilter, bool recursive = false)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(file => extensionFilter.IsMatch(Path.GetExtension(file)));
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

﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FindInFile.Models;
using Alphaleonis.Win32.Filesystem;

namespace SearchAggregatorUtility
{
    public class SearchAggregator
    {
        private readonly string m_Query;
        private readonly bool m_FuzzySearch;
        private readonly bool m_matchCase;
        private readonly bool m_CopyToClipboard;

        private ConcurrentBag<SearchMatch> m_MatchList;
        private List<string> m_FilesToSearch;
        private bool m_SingleFile = true;

        public SearchAggregator(string query, bool fuzzySearch = true, bool matchCase = false, bool copyToClipboard = false)
        {
            m_Query = query;
            m_FuzzySearch = fuzzySearch;
            m_matchCase = matchCase;
            m_CopyToClipboard = copyToClipboard;
            m_MatchList = new ConcurrentBag<SearchMatch>();
        }

        public async Task<List<SearchMatch>> SearchFileSetAsync(List<string> filesToSearch)
        {
            m_SingleFile = false;
            m_FilesToSearch = filesToSearch;

            if (!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<SearchMatch>();

            await Task.Run(() =>
            {
                m_FilesToSearch.AsParallel().ForAll(currentFilePath => {
                    SearchFile(currentFilePath);
                });
                //m_FilesToSearch.ForEach(currentFile => SearchFile(currentFile));
            });

            return m_MatchList.ToList();
        }

        public List<SearchMatch> SearchFileSet(List<string> filesToSearch)
        {
            m_SingleFile = false;
            m_FilesToSearch = filesToSearch;

            if (!m_MatchList.IsEmpty)
                m_MatchList = new ConcurrentBag<SearchMatch>();

            m_FilesToSearch.AsParallel().ForAll(currentFilePath => {
                SearchFile(currentFilePath);
            });

            return m_MatchList.ToList();
        }

        public async Task<List<SearchMatch>> SearchFileAsync(string filePath)
        {
            if (m_SingleFile && !m_MatchList.IsEmpty)
            {
                m_FilesToSearch.Add(filePath);
                m_MatchList = new ConcurrentBag<SearchMatch>();
            }

            List<SearchMatch> matches = new List<SearchMatch>();
            await Task.Run(() => { matches = FindMatchesInFile(filePath, m_Query, m_FuzzySearch, m_matchCase); });

            if (matches.Any())
            {
                matches.ForEach(match => m_MatchList.Add(match));

                // Copy searched for text to system clipboard
                //if (m_CopyToClipboard)
                //    Clipboard.SetText(m_Query);
            }

            return m_MatchList.ToList();
        }

        public List<SearchMatch> SearchFile(string filePath)
        {
            if (m_SingleFile && !m_MatchList.IsEmpty)
            {
                m_FilesToSearch.Add(filePath);
                m_MatchList = new ConcurrentBag<SearchMatch>();
            }

            List<SearchMatch> matches = FindMatchesInFile(filePath, m_Query, m_FuzzySearch, m_matchCase);

            if (matches.Any())
            {
                matches.ForEach(match => m_MatchList.Add(match));

                // Copy searched for text to system clipboard
                //if (m_CopyToClipboard)
                //    Clipboard.SetText(m_Query);
            }
            
            return m_MatchList.ToList();
        }

        public int GetFileCount()
        {
            return m_FilesToSearch?.Count() ?? 0;
        }

        private List<SearchMatch> FindMatchesInFile(string filePath, string searchQuery, bool fuzzySearch, bool matchCase)
        {
            if (!fuzzySearch)
            {
                //.Select((text, index) => new SearchMatch(filePath, filePath.Replace(m_RootPath, "..."), index + 1, searchQuery, text.Trim()))
                return Alphaleonis.Win32.Filesystem.File.ReadLines(filePath)
                    .Select((text, index) => new SearchMatch(filePath.Trim(), filePath.Trim(), index + 1, searchQuery.Trim(),  text.Trim()))
                          .Where(line =>
                              matchCase ?
                                Regex.IsMatch(line.MatchedLine, @"(^|\s)" + searchQuery + @"(\s|$)") :
                                Regex.IsMatch(line.MatchedLine, @"(^|\s)" + searchQuery + @"(\s|$)", RegexOptions.IgnoreCase)).ToList();
            }
            else
            {
                //.Select((text, index) => new SearchMatch(filePath, filePath.Replace(m_RootPath, "..."), index + 1, searchQuery, text.Trim()))
                return Alphaleonis.Win32.Filesystem.File.ReadLines(filePath)
                    .Select((text, index) => new SearchMatch(filePath.Trim(), filePath.Trim(), index + 1, searchQuery.Trim(), text.Trim()))
                              .Where(line =>
                                  matchCase ?
                                    line.MatchedLine.Contains(searchQuery) :
                                    line.MatchedLine.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        #region Utility Methods
        #endregion
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public class SearchEngine
    {
        // Find components
        private SearchForm m_form;

        private ConcurrentBag<Match> m_MatchList;

        private string m_searchQuery;
        private string m_filePath;
        private string m_searchFilter;

        // Find options
        private bool m_recursiveSearch;
        private bool m_fuzzySearch;
        private bool m_matchCase;
        private bool m_copyToClipboard;

        public SearchEngine() { }

        public SearchEngine(SearchForm form)
        {
            // Initialize 
            this.m_form = form;
        }

        private void UpdateEngineData()
        {
            // Find components
            m_searchQuery = m_form.queryTextBox.Text;
            m_filePath = m_form.rootDirectoryTextBox.Text;
            m_searchFilter = m_form.filterTextBox.Text;

            // Find options
            m_fuzzySearch = m_form.fuzzySearchCheckBox.Checked;
            m_recursiveSearch = m_form.recursiveCheckBox.Checked;
            m_matchCase = m_form.matchCaseCheckBox.Checked;
            m_copyToClipboard = m_form.copyToClipboardCheckBox.Checked;
        }

        private void SearchFileSet(IEnumerable<string> files)
        {
            files.AsParallel().ForAll(currentFile => {

                List<Match> matches = FindMatchesInFile(currentFile);

                if (matches != null)
                {
                    foreach (var match in matches)
                        m_MatchList.Add(match);
                }
            });

#if DEBUG
            form.debuggerDataStatusStrip.DropDownItems.Add("Match Count: " + m_MatchList.Count());
#endif
        }

        private List<Match> FindMatchesInFile(string filePath)
        {
            UpdateEngineData();

            if (!fuzzySearch)
            {
                return File.ReadLines(filePath)
                .Select((text, index) => new Match(filePath, text, index + 1))
                          .Where(line =>
                              matchCase ?
                                Regex.IsMatch(line.text, @"(^|\s)" + stringToFind + @"(\s|$)") :
                                Regex.IsMatch(line.text, @"(^|\s)" + stringToFind + @"(\s|$)", RegexOptions.IgnoreCase)).ToList();
            }
            else
            {
                return File.ReadLines(filePath)
                    .Select((text, index) => new Match(filePath, text, index + 1))
                              .Where(line => line.text.Contains(queryTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        private void UpdateStatusStrip(string text, Color? color = null, bool forceRefresh = false)
        {
            searchResultStatusStrip.ForeColor = color ?? Color.Green; //Set defualt color
            searchResultStatusStrip.Text = text;

            if (forceRefresh)
                statusStrip.Refresh();
        }

        private IEnumerable<string> GetAllFilesInDirectory(string rootPath, Regex filter, bool includeSubDirectories = true)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                includeSubDirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(file => filter.IsMatch(Path.GetExtension(file)));
        }
    }
}

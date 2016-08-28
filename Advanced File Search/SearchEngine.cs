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
        
        private SearchForm m_Form;

        private ConcurrentBag<Match> m_MatchList;
        
        private string m_SearchQuery;
        private string m_FilePath;
        private string m_SearchFilter;

        private bool m_RecursiveSearch;
        private bool m_FuzzySearch;
        private bool m_MatchCase;
        private bool m_CopyToClipboard;

        public SearchEngine(SearchForm form)
        {
            //add ewvent listener as parameter
            // Initialize 
            this.m_Form = form;

            UpdateEngineData();
        }

        private void UpdateEngineData()
        {
            // Find components
            m_SearchQuery = m_Form.queryTextBox.Text;
            m_FilePath = m_Form.rootDirectoryTextBox.Text;
            m_SearchFilter = m_Form.filterTextBox.Text;

            // Find options
            m_RecursiveSearch = m_Form.recursiveCheckBox.Checked;
            m_FuzzySearch = m_Form.fuzzySearchCheckBox.Checked;
            m_MatchCase = m_Form.matchCaseCheckBox.Checked;
            m_CopyToClipboard = m_Form.copyToClipboardCheckBox.Checked;
        }

        public void SearchFileSet(IEnumerable<string> files)
        {
            UpdateEngineData();

            files.AsParallel().ForAll(currentFile => {

                List<Match> matches = FindMatchesInFile(currentFile);

                if (matches != null)
                {
                    foreach (var match in matches)
                        m_MatchList.Add(match);
                }
            });

#if DEBUG
            m_Form.debuggerDataStatusStrip.DropDownItems.Add("Match Count: " + m_MatchList.Count());
#endif
        }

        private List<Match> FindMatchesInFile(string filePath)
        {
            if (!m_FuzzySearch)
            {
                return File.ReadLines(filePath)
                .Select((text, index) => new Match(filePath, text, index + 1))
                          .Where(line =>
                              m_MatchCase ?
                                Regex.IsMatch(line.text, @"(^|\s)" + m_SearchQuery + @"(\s|$)") :
                                Regex.IsMatch(line.text, @"(^|\s)" + m_SearchQuery + @"(\s|$)", RegexOptions.IgnoreCase)).ToList();
            }
            else
            {
                return File.ReadLines(filePath)
                    .Select((text, index) => new Match(filePath, text, index + 1))
                              .Where(line => line.text.Contains(m_SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }
        }

        private IEnumerable<string> GetAllFilesInDirectory(string rootPath, Regex filter)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                m_RecursiveSearch ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly)
                        .Where(file => filter.IsMatch(Path.GetExtension(file)));
        }

        #region Utility Methods
        private void UpdateStatusStrip(string text, Color? color = null, bool forceRefresh = false)
        {
            m_Form.searchResultStatusStrip.ForeColor = color ?? Color.Green; //Set defualt color
            m_Form.searchResultStatusStrip.Text = text;

            if (forceRefresh)
                m_Form.statusStrip.Refresh();
        }
        #endregion
    }
}

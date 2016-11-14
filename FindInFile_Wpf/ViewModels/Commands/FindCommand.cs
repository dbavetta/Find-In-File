using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Linq;
using FindInFile.Models;
using SearchAggregatorUtility;

namespace FindInFile.Wpf.ViewModels.Commands
{
    class FindCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;
        private bool UseRelativeFilePaths
        {
            get
            {
                bool result; bool.TryParse(ConfigurationManager.AppSettings.Get("DisplayRelativeFilePaths"), out result);
                return result;
            }
        }

        public FindCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members
        public override async void Execute(object parameter)
        {
            string query = m_FindTextViewModel.QueryText;
            string rootPath = m_FindTextViewModel.RootPathText;
            string extensionFilter = m_FindTextViewModel.FilterText;
            bool recursive = m_FindTextViewModel.RecursiveChecked;
            bool fuzzySearch = m_FindTextViewModel.FuzzySearchChecked;
            bool matchCase = m_FindTextViewModel.MatchCaseChecked;
            bool copyToClipboard = m_FindTextViewModel.CopyToClipboardChecked;

            //debuggerDataStatusStrip.DropDownItems.Clear();
            m_FindTextViewModel.UpdateStatusBar("Searching...");
            try
            {
                var searchAggregator = new SearchAggregator(query, fuzzySearch, matchCase, copyToClipboard);
                var filepaths = DirectoryExplorer.GetFilePaths(rootPath, recursive, extensionFilter).ToList();
                var matches = await searchAggregator.SearchFileSetAsync(filepaths);

                if (UseRelativeFilePaths)
                    foreach (var m in matches)
                        m.ShortenedPath = m.ShortenedPath.Replace(rootPath, "..");

                m_FindTextViewModel.MatchList = new ObservableCollection<SearchMatch>(matches);
            }
            catch (DirectoryNotFoundException)
            {
                //There was an issue with the root directory string i.e. the location doesnt exist
                m_FindTextViewModel.UpdateStatusBar("The provided folder path does not exist.", "Red");
                return;
            }
            catch (Exception ex)
            {
#if DEBUG
                //debuggerDataStatusStrip.DropDownItems.Add("Exception: " + ex);
#endif
            }
            finally
            {
#if DEBUG
                //debuggerDataStatusStrip.DropDownItems.Add("Number of files retrieved in all directories: " + m_SearchAggregator.GetFileCount());
#endif
                if (m_FindTextViewModel.MatchList.Count > 0)
                    m_FindTextViewModel.UpdateStatusBar(m_FindTextViewModel.MatchList.Count + " match(es) found.");
                else
                    m_FindTextViewModel.UpdateStatusBar("No matches found.", "Red");
            }
        }
        #endregion
    }
}
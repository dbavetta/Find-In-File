using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using FindInFile.Models;
using SearchAggregatorUtility;

namespace FindInFile.Wpf.ViewModels.Commands
{
    class FindCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;

        public FindCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members
        public override void Execute(object parameter)
        {
            string query = m_FindTextViewModel.QueryText;
            string rootPath = m_FindTextViewModel.RootPathText;
            string extensionFilter = m_FindTextViewModel.FilterText;
            bool recursive = m_FindTextViewModel.RecursiveChecked;
            bool fuzzySearch = m_FindTextViewModel.FuzzySearchChecked;
            bool matchCase = m_FindTextViewModel.MatchCaseChecked;
            bool copyToClipboard = m_FindTextViewModel.CopyToClipboardChecked;

            //debuggerDataStatusStrip.DropDownItems.Clear();
            try
            {
                var searchAggregator = new SearchAggregator(query, fuzzySearch, matchCase, copyToClipboard);
                var filepaths = DirectoryExplorer.GetFilePaths(rootPath, recursive, extensionFilter).ToList();
                var matches = searchAggregator.SearchFileSet(filepaths);
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
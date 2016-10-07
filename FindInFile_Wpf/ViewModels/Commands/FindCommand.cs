using System;
using System.Collections.ObjectModel;
using System.IO;
using FindInFile.Models;
using SearchAggregatorUtility;

namespace FindInFile.Wpf.ViewModels.Commands
{
    class FindCommand : BaseCommand
    {
        private FindTextViewModel m_FindTextViewModel;
        private SearchAggregator m_SearchAggregator;

        public FindCommand(FindTextViewModel viewModel)
        {
            m_FindTextViewModel = viewModel;
        }

        #region ICommand Members
        public override void Execute(object parameter)
        {
            //debuggerDataStatusStrip.DropDownItems.Clear();
            try
            {
                m_SearchAggregator = new SearchAggregator(m_FindTextViewModel.QueryText, 
                                                          m_FindTextViewModel.FuzzySearchChecked, 
                                                          m_FindTextViewModel.MatchCaseChecked, 
                                                          m_FindTextViewModel.CopyToClipboardChecked);

                m_SearchAggregator.GetAllFilesInDirectory(m_FindTextViewModel.RootPathText, 
                                                          m_FindTextViewModel.FilterText, 
                                                          m_FindTextViewModel.RecursiveChecked);

                m_FindTextViewModel.MatchList = new ObservableCollection<SearchMatch>(m_SearchAggregator.SearchFileSet());
            }
            catch (DirectoryNotFoundException)
            {
                //There was an issue with the root directory string i.e. the location doesnt exist
                m_FindTextViewModel.UpdateStatusBarText("The provided folder path does not exist.", "Red");
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
                    m_FindTextViewModel.UpdateStatusBarText(m_FindTextViewModel.MatchList.Count + " match(es) found.");
                else
                    m_FindTextViewModel.UpdateStatusBarText("No matches found.", "Red");
            }
        }
        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindInFile.Models;
using FindInFile.Wpf.ViewModels.Commands;
using SearchAggregatorUtility;

namespace FindInFile_Wpf.ViewModels.Commands
{
    class RetrieveExtensionsCommand : BaseCommand
    {
        private FileExtensionDialogViewModel m_FileExtentionViewModel;
        private SearchAggregator m_SearchAggregator;
        private readonly int m_ColumnCount;

        public RetrieveExtensionsCommand(FileExtensionDialogViewModel viewModel)
        {
            m_SearchAggregator = new SearchAggregator();
            m_FileExtentionViewModel = viewModel;
            m_ColumnCount = viewModel.ColumnCount;
        }

        public override void Execute(object parameter)
        {
            List<string> extensions = new List<string>();

            IEnumerable<string> files = m_SearchAggregator.ReturnAllFilesInDirectory(m_FileExtentionViewModel.FolderPath,  
                                                                                     m_FileExtentionViewModel.RecursiveChecked);

            foreach (var path in files)
            {
                extensions.Add(Path.GetExtension(path));
            }

            int rowCount = (extensions.Count / m_ColumnCount) > 0 ? (extensions.Count / m_ColumnCount) : 1;
            var matrix = new ExtensionCellItem[rowCount, m_ColumnCount];

            int extensionIter = 0;

            for (int column = 0; column < m_ColumnCount; column++)
            {
                for (int row = 0; row < rowCount; row++)
                {
                    matrix[row, column] = new ExtensionCellItem(false, extensions[extensionIter]);
                }
            }

            m_FileExtentionViewModel.ExtensionMatrix = matrix;
        }
    }
}

using System.Collections.Generic;
using System;
using System.Linq;
using ClaySharp;
using FindInFile.Wpf.ViewModels.Commands;
using SearchAggregatorUtility;
using FindInFile.Models;

namespace FindInFile_Wpf.ViewModels.Commands
{
    class RetrieveExtensionsCommand : BaseCommand
    {
        private FileExtensionDialogViewModel m_FileExtentionViewModel;
        private readonly int m_ColumnCount;
        private int m_RowCount;

        public RetrieveExtensionsCommand(FileExtensionDialogViewModel viewModel)
        {
            m_FileExtentionViewModel = viewModel;
            m_ColumnCount = viewModel.ColumnCount;
        }

        public override void Execute(object parameter)
        {
            string rootPath = m_FileExtentionViewModel.FolderPath;
            bool recursive = m_FileExtentionViewModel.RecursiveChecked;
            var dataGrid = new List<ExtensionCellItem>();

            var extensions = DirectoryExplorer.GetExtensions(rootPath, recursive).GroupBy(ext => ext).OrderByDescending(ext => ext.Count());

            if (extensions != null && extensions.Count() > 0)
            {
                foreach (var extension in extensions)
                {
                    dataGrid.Add(new ExtensionCellItem(extension.Key, extension.Count()));
                }

                m_FileExtentionViewModel.ExtensionGrid = dataGrid;
            }
        }
    }

    //public override void Execute(object parameter)
    //    {
    //        string rootPath = m_FileExtentionViewModel.FolderPath;
    //        bool recursive = m_FileExtentionViewModel.RecursiveChecked;
    //        var dataGrid = new List<dynamic>();
    //        dynamic _new = new ClayFactory();

    //        List<string> extensions = DirectoryExplorer.GetExtensions(rootPath, recursive).ToList();

    //        if (extensions != null && extensions.Count > 0)
    //        {
    //            m_RowCount = (extensions.Count / m_ColumnCount) > 0 ? (extensions.Count / m_ColumnCount) : 1;

    //            int extensionIter = 0;
    //            for (int row = 0; row < m_RowCount; row++)
    //            {
    //                var extRow = _new.ExtensionRow();
    //                Sample s = new Sample();

    //                for (int column = 0; column < m_ColumnCount; column++)
    //                {
    //                    if (extensionIter < extensions.Count)
    //                    {
    //                        switch (extensionIter)
    //                        {
    //                        }
    //                        string extensionKeyName = "extension" + row + "_Key";
    //                        string extensionValuename = "extension" + row + "_Value";
    //                        extRow[extensionKeyName] = extensions[extensionIter];
    //                        extRow[extensionValuename] = false;
    //                        extensionIter++;
    //                    }
    //                }
    //                dataGrid.Add(Convert.ChangeType(extRow, typeof(object)));
    //            }

    //            m_FileExtentionViewModel.ExtensionGrid2 = dataGrid;
    //        }
    //    }
    //}
}

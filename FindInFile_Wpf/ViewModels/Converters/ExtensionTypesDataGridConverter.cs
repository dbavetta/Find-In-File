using System;
using System.Data;
using System.Globalization;
using System.Windows.Data;
using FindInFile.Models;

namespace FindInFile_Wpf.ViewModels.Converters
{
    public class ExtensionTypesDataGridConverter : IValueConverter
    {
        private const int COLUMN_COUNT = 8;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //viewmodel needs a prepopulated matrix with these items in them then they will be converted to correct form

            var array = value as ExtensionCellItem[,];
            if (array == null) return null;

            var rows = array.GetLength(0);
            if (rows == 0) return null;

            var columns = array.GetLength(1);
            if (columns == 0) return null;

            var extensionsGrid = new DataTable();

            for (var column = 0; column < COLUMN_COUNT; column++)
            {
                var col = new DataColumn();
                extensionsGrid.Columns.Add(col);
            }

            // Add data to DataTable
            for (var row = 0; row < rows; row++)
            {
                var newRow = extensionsGrid.NewRow();
                for (var col = 0; col < COLUMN_COUNT; col++)
                {
                    newRow[col] = array[row, col];
                }
                extensionsGrid.Rows.Add(newRow);
            }

            return extensionsGrid.DefaultView;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

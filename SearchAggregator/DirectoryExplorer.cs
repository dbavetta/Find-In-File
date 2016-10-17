using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SearchAggregatorUtility
{
    public class DirectoryExplorer
    {
        public static IEnumerable<string> GetFilePaths(string rootPath, bool recursive = false, string extensionFilter = "*.*")
        {
            SearchOption searchOption = recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            SmartRegex filter = new SmartRegex(extensionFilter);
            return Directory.EnumerateFiles(rootPath, "*", searchOption).
                    Where(filePath => filter.IsMatch(Path.GetExtension(filePath)));
        }

        public static IEnumerable<string> GetExtensions(string rootPath, bool recursive = false)
        {
            return GetFilePaths(rootPath, recursive).
                Select(filePath => Path.GetExtension(filePath));
        }

        public static IEnumerable<string> GetExtensionsUnique(string rootPath, bool recursive = false)
        {
            return GetFilePaths(rootPath, recursive).
                Select(filePath => Path.GetExtension(filePath)).Distinct();
        }
    }
}

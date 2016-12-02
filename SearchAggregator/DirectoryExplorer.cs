using System.Collections.Generic;
using System.Linq;
using Alphaleonis.Win32.Filesystem;

namespace SearchAggregatorUtility
{
    public class DirectoryExplorer
    {
        public static IEnumerable<string> GetFilePaths(string rootPath, bool recursive = false, string extensionFilter = "*.*")
        {
            System.IO.SearchOption searchOption = recursive ? System.IO.SearchOption.AllDirectories : System.IO.SearchOption.TopDirectoryOnly;
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

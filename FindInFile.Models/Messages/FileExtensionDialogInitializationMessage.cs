using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindInFile.Models.Messages
{
    public class FileExtensionDialogInitializationMessage
    {
        public string FolderPath { get; set; }

        public bool RecursiveChecked { get; set; }

        public FileExtensionDialogInitializationMessage()
        {

        }

        public FileExtensionDialogInitializationMessage(string folderPath, bool recursiveChecked)
        {
            FolderPath = folderPath;
            RecursiveChecked = recursiveChecked;
        }
    }
}

using System.Collections.Generic;
using System.Text;

namespace FindInFile.Models.Messages
{
    public class ReturnExtensionsMessage
    {
        public List<ExtensionCellItem> Extensions { get; set; }

        public ReturnExtensionsMessage()
        {

        }

        public ReturnExtensionsMessage(List<ExtensionCellItem> extensions)
        {
            Extensions = extensions;
        }
    }
}

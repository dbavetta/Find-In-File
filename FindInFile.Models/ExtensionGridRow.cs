using System.Collections.Generic;

namespace FindInFile.Models
{
    public class ExtensionGridRow
    {
        private List<ExtensionCellItem> m_Cells;

        public List<ExtensionCellItem> Cells
        {
            get { return m_Cells; }
            set { m_Cells = value; }
        }

        public ExtensionGridRow(List<ExtensionCellItem> cells)
        {
            m_Cells = cells;
        }
    }
}

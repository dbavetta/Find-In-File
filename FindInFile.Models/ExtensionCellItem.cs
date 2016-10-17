namespace FindInFile.Models
{
    public class ExtensionCellItem
    {
        private bool m_included;
        private string m_Extension;
        private int m_ExtensionCount;

        public bool Include
        {
            get { return m_included; }
            set { m_included = value; }
        }

        public string Extension
        {
            get { return m_Extension; }
        }

        public int Count
        {
            get { return m_ExtensionCount; }
        }

        public ExtensionCellItem(string text, int extensionCount, bool isChecked = true)
        {
            m_included = isChecked;
            m_Extension = text;
            m_ExtensionCount = extensionCount;
        }
    }
}

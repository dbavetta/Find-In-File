using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_File_Search
{
     public class SearchFromEntity
    {
        private TextBox m_QueryTextBox;
        private TextBox m_FilePathTextBox;
        private TextBox m_FilterTextBox;

        private CheckBox m_RecursiveCheckBox;
        private CheckBox m_FuzzySearchCheckBox;
        private CheckBox m_MatchCaseCheckBox;
        private CheckBox m_CopyToClipboardCheckBox;

        public SearchFromEntity(TextBox queryTextBox,
                                TextBox filePathTextBox,
                                TextBox filterTextBox,
                                CheckBox recursiveCheckBox,
                                CheckBox fuzzyCheckBox,
                                CheckBox matchCaseCheckBox,
                                CheckBox copyToClipboardCheckBox)
        {
            m_QueryTextBox = queryTextBox;
            m_FilePathTextBox = filePathTextBox;
            m_FilePathTextBox = filterTextBox;
            m_RecursiveCheckBox = recursiveCheckBox;
            m_FuzzySearchCheckBox = fuzzyCheckBox;
            m_MatchCaseCheckBox = matchCaseCheckBox;
            m_CopyToClipboardCheckBox = copyToClipboardCheckBox;
        }

        public TextBox QueryTextBox { get { return m_QueryTextBox; } }
        public TextBox FilePathTextBox { get { return m_FilePathTextBox; } }
        public TextBox FilterTextBox { get { return m_FilterTextBox; } }

        public CheckBox RecursiveCheckBox { get { return m_RecursiveCheckBox; } }
        public CheckBox FuzzySearchCheckBox { get { return m_FuzzySearchCheckBox; } }
        public CheckBox MatchCaseCheckBox { get { return m_MatchCaseCheckBox; } }
        public CheckBox CopyToClipboardCheckBox { get { return m_CopyToClipboardCheckBox; } }
    }
}

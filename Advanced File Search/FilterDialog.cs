using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public partial class FilterDialog : Form
    {
        private string m_BaseDirectory = null;

        public FilterDialog(string baseDirectory)
        {
            m_BaseDirectory = baseDirectory;
            InitializeComponent();
        }

        private List<string> GetExtensionsInDirectory(string rootPath, bool recursive = false)
        {
            return Directory.EnumerateFiles(rootPath, "*",
                recursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Select(filePath => Path.GetExtension(filePath)).ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) 
        {

        }

        private void OnRetrieveExtensionButton_Click(object sender, EventArgs e)
        {
            bool recursive = recursiveCheckBox.Checked;
            List<string> extensions = null;

            if (!string.IsNullOrEmpty(filePathTextBox.Text))
            {
                extensions = GetExtensionsInDirectory(filePathTextBox.Text.Trim());
                DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
                
            }
        }
    }
}

﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Advanced_File_Search
{
    public partial class SearchForm : Form
    {
        private ConcurrentBag<Match> m_MatchList;
        private string DEFAULT_QUERY = "Get-EmpiEnvironment";
        private string DEFAULT_FILE_PATH = @"C:\Users\D760026\Documents\WindowsPowerShell";
        private string DEFAULT_FILTER = "*.ps1, *.psd1, *.psm1, *.cs, *.cshtml, *.html, *.txt, *.js";

        private int filePathColumnWidth;
        private int lineNumberColumnWidth;
        private int lineTextColumnWidth;



        ListViewItem lastHighlightedRow = null;

        public SearchForm()
        {
            //TODO: Convert to WPF application instead of windows forms
            //TODO: Autoscale and position controls relative to GUI size 
            //TODO: Dynamically generate checkboxs for every file type found in directy path -> allow the user to check additional search filters
            //TODO: Copy search query to clipboard after clicking Find button

            InitializeComponent();
            InitializeFindComponents();
            InitilizeListView();

            //create event listener and pass it to searchengine object
            Form form = new Form();

#if RELEASE
            findButton.Enabled = false;
#endif
            m_MatchList = new ConcurrentBag<Match>();
        }

        private void InitializeFindComponents()
        {
            queryTextBox.Text = DEFAULT_QUERY;
            rootDirectoryTextBox.Text = DEFAULT_FILE_PATH;
            filterTextBox.Text = DEFAULT_FILTER;
            findButton.Enabled = true;
        }

        private void InitilizeListView()
        {
            queryResultsListView.View = View.Details;

            //queryResultsListView.OwnerDraw = true;
            //queryResultsListView.DrawSubItem += new DrawListViewSubItemEventHandler(listBox1_DrawItem)

            //Add columns
            queryResultsListView.Columns.Add("File Path", -2, HorizontalAlignment.Left);
            queryResultsListView.Columns.Add("Line #", -2, HorizontalAlignment.Left);
            queryResultsListView.Columns.Add("Find Results", -2, HorizontalAlignment.Left);

            //Set initial column width
            queryResultsListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            queryResultsListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            queryResultsListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);

            //Set initial width of column headers, used later for colunn resizing
            filePathColumnWidth = queryResultsListView.Columns[0].Width;
            lineNumberColumnWidth = queryResultsListView.Columns[1].Width;
            lineTextColumnWidth = queryResultsListView.Columns[2].Width;
        }

        private void AddRowItemToListView(Match match)
        {
            ListViewItem item = new ListViewItem(match.GetRow());
            item.Tag = match;

            queryResultsListView.Items.Add(item);

            //Adjust column width based on whats longer, column header or contents
            queryResultsListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            if(queryResultsListView.Columns[0].Width < filePathColumnWidth)
                queryResultsListView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            if (queryResultsListView.Columns[1].Width < lineNumberColumnWidth)
                queryResultsListView.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);

            if (queryResultsListView.Columns[2].Width < lineTextColumnWidth)
                queryResultsListView.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void OnFindButton_Click(object sender, EventArgs e) 
        {
            m_MatchList = new ConcurrentBag<Match>();
            queryResultsListView.Items.Clear();

            //Convert the users filter query to regex ~ needed for search
            //*.psd1, *.psm1, *.cs, *.cshtml, *.txt" --> \.mp3|\.mp4
            string searchPatternExpression = filterTextBox.Text.Replace(",", "|").Replace("*", @"\").Replace(" ", "");
            Regex searchPattern = new Regex(searchPatternExpression, RegexOptions.IgnoreCase);

            string rootPath = rootDirectoryTextBox.Text;
            bool recursive = recursiveCheckBox.Checked;
            bool fuzzySearch = fuzzySearchCheckBox.Checked;

            Clipboard.SetText(queryTextBox.Text); //copy searched for text to system clipboard

            try
            {
                UpdateStatusStrip("Searching...", Color.DarkOrange, true);
                IEnumerable<string> files = GetAllFilesInDirectory(rootPath, searchPattern, recursive);
#if DEBUG
                debuggerDataStatusStrip.DropDownItems.Clear();
                debuggerDataStatusStrip.DropDownItems.Add("Number of files retrieved in all directories: " + files.Count());
#endif

                SearchFileSet(files);
            }
            catch (DirectoryNotFoundException)
            {
                //There was an issure with the root directory string i.e. the location doesnt exist
                UpdateStatusStrip("The provided folder path does not exist.", Color.Red);
                return;
            }

            foreach (var match in m_MatchList)
            {
                AddRowItemToListView(match);
            }

            if(m_MatchList.Count > 0)
                UpdateStatusStrip(m_MatchList.Count + " match(es) found.");
            else
                UpdateStatusStrip(m_MatchList.Count + " match(es) found.", Color.Red);
        }

        private void OnQueryTextBox_TextChanged(object sender, EventArgs e)
        {
            findButton.Enabled = (!String.IsNullOrEmpty(queryTextBox.Text) && !String.IsNullOrEmpty(rootDirectoryTextBox.Text));
        }

        private void OnQueryResultsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListView listView = sender as ListView;

            if (listView != null && listView.SelectedItems.Count > 0)
            {
                Match listItem = queryResultsListView.SelectedItems[0].Tag as Match;
                if (listItem != null)
                {
                    // Open file
                    if (!string.IsNullOrEmpty(listItem.path))
                        System.Diagnostics.Process.Start(listItem.path);
                }
            }
        }

        private void OnBrowseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK)
                rootDirectoryTextBox.Text = folderBrowserDialog.SelectedPath;
        }

        //TODO: Finish implementing DrawSubItem Event Handler
        private void OnQueryResultsListView_DrawItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                TextFormatFlags flags = TextFormatFlags.Left;
                //e.DrawBackground();
                //e.DrawFocusRectangle();

                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        flags = TextFormatFlags.HorizontalCenter;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        flags = TextFormatFlags.Right;
                        break;
                }

                if (!string.IsNullOrEmpty(e.Header.ToString()) && e.Header.Text.ToString() == "File Path")
                {
                    string line = queryResultsListView.Items[e.ColumnIndex].Text.ToString();
                    string[] lineParts = line.Split(' ');

                    //Microsoft Sans Serif, 7.8pt
                    e.Graphics.DrawString(lineParts[0], new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), new SolidBrush(Color.Black), e.Bounds);
                    e.Graphics.DrawString(lineParts[1], new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular), new SolidBrush(Color.Red), e.Bounds);
                    return;
                }

                e.DrawText(flags);
            }
        }
    }
}

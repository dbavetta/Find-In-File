using System.Windows.Forms;

namespace Advanced_File_Search
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.findWhatLabel = new System.Windows.Forms.Label();
            this.queryTextBox = new System.Windows.Forms.TextBox();
            this.rootDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.rootDirectoryLabel = new System.Windows.Forms.Label();
            this.findButton = new System.Windows.Forms.Button();
            this.queryResultsListView = new System.Windows.Forms.ListView();
            this.recursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.searchResultStatusStrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.debuggerDataStatusStrip = new System.Windows.Forms.ToolStripDropDownButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.copyToClipboardCheckBox = new System.Windows.Forms.CheckBox();
            this.matchCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.fuzzySearchCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.statusStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // findWhatLabel
            // 
            this.findWhatLabel.AutoSize = true;
            this.findWhatLabel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findWhatLabel.Location = new System.Drawing.Point(6, 33);
            this.findWhatLabel.Name = "findWhatLabel";
            this.findWhatLabel.Size = new System.Drawing.Size(75, 18);
            this.findWhatLabel.TabIndex = 0;
            this.findWhatLabel.Text = "Find What:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryTextBox.Location = new System.Drawing.Point(81, 28);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(500, 26);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.TextChanged += new System.EventHandler(this.OnQueryTextBox_TextChanged);
            // 
            // rootDirectoryTextBox
            // 
            this.rootDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootDirectoryTextBox.Location = new System.Drawing.Point(6, 21);
            this.rootDirectoryTextBox.Name = "rootDirectoryTextBox";
            this.rootDirectoryTextBox.Size = new System.Drawing.Size(397, 26);
            this.rootDirectoryTextBox.TabIndex = 2;
            // 
            // rootDirectoryLabel
            // 
            this.rootDirectoryLabel.AutoSize = true;
            this.rootDirectoryLabel.Location = new System.Drawing.Point(484, 16);
            this.rootDirectoryLabel.Name = "rootDirectoryLabel";
            this.rootDirectoryLabel.Size = new System.Drawing.Size(40, 16);
            this.rootDirectoryLabel.TabIndex = 3;
            this.rootDirectoryLabel.Text = "Root:";
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.PaleGreen;
            this.findButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.findButton.Location = new System.Drawing.Point(6, 65);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(140, 43);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "FIND";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.OnFindButton_Click);
            // 
            // queryResultsListView
            // 
            this.queryResultsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResultsListView.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryResultsListView.FullRowSelect = true;
            this.queryResultsListView.GridLines = true;
            this.queryResultsListView.Location = new System.Drawing.Point(12, 143);
            this.queryResultsListView.Name = "queryResultsListView";
            this.queryResultsListView.ShowItemToolTips = true;
            this.queryResultsListView.Size = new System.Drawing.Size(1097, 459);
            this.queryResultsListView.TabIndex = 5;
            this.queryResultsListView.UseCompatibleStateImageBehavior = false;
            this.queryResultsListView.View = System.Windows.Forms.View.Details;
            this.queryResultsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnQueryResultsListView_MouseDoubleClick);
            // 
            // recursiveCheckBox
            // 
            this.recursiveCheckBox.AutoSize = true;
            this.recursiveCheckBox.Checked = true;
            this.recursiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recursiveCheckBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recursiveCheckBox.Location = new System.Drawing.Point(152, 65);
            this.recursiveCheckBox.Name = "recursiveCheckBox";
            this.recursiveCheckBox.Size = new System.Drawing.Size(87, 22);
            this.recursiveCheckBox.TabIndex = 7;
            this.recursiveCheckBox.Text = "Recursive";
            this.recursiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTextBox.Location = new System.Drawing.Point(6, 21);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(397, 26);
            this.filterTextBox.TabIndex = 8;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\D760026\\Documents\\WindowsPowerShell";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseButton.Location = new System.Drawing.Point(409, 18);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(89, 29);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.OnBrowseButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchResultStatusStrip,
            this.debuggerDataStatusStrip});
            this.statusStrip.Location = new System.Drawing.Point(0, 628);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1121, 26);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip";
            // 
            // searchResultStatusStrip
            // 
            this.searchResultStatusStrip.ForeColor = System.Drawing.Color.Green;
            this.searchResultStatusStrip.Name = "searchResultStatusStrip";
            this.searchResultStatusStrip.Size = new System.Drawing.Size(70, 21);
            this.searchResultStatusStrip.Text = "Status Label";
            // 
            // debuggerDataStatusStrip
            // 
            this.debuggerDataStatusStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.debuggerDataStatusStrip.Image = ((System.Drawing.Image)(resources.GetObject("debuggerDataStatusStrip.Image")));
            this.debuggerDataStatusStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debuggerDataStatusStrip.Name = "debuggerDataStatusStrip";
            this.debuggerDataStatusStrip.Size = new System.Drawing.Size(102, 24);
            this.debuggerDataStatusStrip.Text = "Debug Data";
            this.debuggerDataStatusStrip.ToolTipText = "Debug Data\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.copyToClipboardCheckBox);
            this.groupBox1.Controls.Add(this.matchCaseCheckBox);
            this.groupBox1.Controls.Add(this.fuzzySearchCheckBox);
            this.groupBox1.Controls.Add(this.findWhatLabel);
            this.groupBox1.Controls.Add(this.queryTextBox);
            this.groupBox1.Controls.Add(this.findButton);
            this.groupBox1.Controls.Add(this.recursiveCheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 123);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // copyToClipboardCheckBox
            // 
            this.copyToClipboardCheckBox.AutoSize = true;
            this.copyToClipboardCheckBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyToClipboardCheckBox.Location = new System.Drawing.Point(286, 88);
            this.copyToClipboardCheckBox.Name = "copyToClipboardCheckBox";
            this.copyToClipboardCheckBox.Size = new System.Drawing.Size(181, 22);
            this.copyToClipboardCheckBox.TabIndex = 16;
            this.copyToClipboardCheckBox.Text = "Copy Search to Clipboard";
            this.copyToClipboardCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchCaseCheckBox.Location = new System.Drawing.Point(286, 65);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(97, 22);
            this.matchCaseCheckBox.TabIndex = 9;
            this.matchCaseCheckBox.Text = "Match Case";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // fuzzySearchCheckBox
            // 
            this.fuzzySearchCheckBox.AutoSize = true;
            this.fuzzySearchCheckBox.Checked = true;
            this.fuzzySearchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fuzzySearchCheckBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuzzySearchCheckBox.Location = new System.Drawing.Point(152, 88);
            this.fuzzySearchCheckBox.Name = "fuzzySearchCheckBox";
            this.fuzzySearchCheckBox.Size = new System.Drawing.Size(105, 22);
            this.fuzzySearchCheckBox.TabIndex = 15;
            this.fuzzySearchCheckBox.Text = "Fuzzy Search";
            this.fuzzySearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.filterTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(605, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 58);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(409, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 10;
            this.button1.Text = "Advanced";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.rootDirectoryTextBox);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(605, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(504, 59);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Folder Path";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 654);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.queryResultsListView);
            this.Controls.Add(this.rootDirectoryLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1086, 693);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find In File";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label findWhatLabel;
        private Label rootDirectoryLabel;
        private Button findButton;
        private FolderBrowserDialog folderBrowserDialog;
        private Button browseButton;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;

        // Public controls to be used with the SearchEngine class
        public TextBox queryTextBox;
        public TextBox rootDirectoryTextBox;
        public ListView queryResultsListView;
        public CheckBox recursiveCheckBox;
        public TextBox filterTextBox;
        public CheckBox fuzzySearchCheckBox;
        public CheckBox matchCaseCheckBox;
        public CheckBox copyToClipboardCheckBox;
        public StatusStrip statusStrip;
        public ToolStripStatusLabel searchResultStatusStrip;
        public ToolStripDropDownButton debuggerDataStatusStrip;
        private Button button1;
    }
}


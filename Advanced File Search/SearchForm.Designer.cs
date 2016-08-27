﻿using System.Collections.Generic;
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
            this.findWhatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.findWhatLabel.Location = new System.Drawing.Point(6, 31);
            this.findWhatLabel.Name = "findWhatLabel";
            this.findWhatLabel.Size = new System.Drawing.Size(86, 17);
            this.findWhatLabel.TabIndex = 0;
            this.findWhatLabel.Text = "Find What:";
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(98, 28);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(412, 22);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.TextChanged += new System.EventHandler(this.OnQueryTextBox_TextChanged);
            // 
            // rootDirectoryTextBox
            // 
            this.rootDirectoryTextBox.Location = new System.Drawing.Point(6, 28);
            this.rootDirectoryTextBox.Name = "rootDirectoryTextBox";
            this.rootDirectoryTextBox.Size = new System.Drawing.Size(381, 22);
            this.rootDirectoryTextBox.TabIndex = 2;
            // 
            // rootDirectoryLabel
            // 
            this.rootDirectoryLabel.AutoSize = true;
            this.rootDirectoryLabel.Location = new System.Drawing.Point(484, 16);
            this.rootDirectoryLabel.Name = "rootDirectoryLabel";
            this.rootDirectoryLabel.Size = new System.Drawing.Size(42, 17);
            this.rootDirectoryLabel.TabIndex = 3;
            this.rootDirectoryLabel.Text = "Root:";
            // 
            // findButton
            // 
            this.findButton.BackColor = System.Drawing.Color.PaleGreen;
            this.findButton.Location = new System.Drawing.Point(6, 65);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(140, 43);
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = false;
            this.findButton.Click += new System.EventHandler(this.OnFindButton_Click);
            // 
            // queryResultsListView
            // 
            this.queryResultsListView.FullRowSelect = true;
            this.queryResultsListView.GridLines = true;
            this.queryResultsListView.Location = new System.Drawing.Point(16, 143);
            this.queryResultsListView.Name = "queryResultsListView";
            this.queryResultsListView.ShowItemToolTips = true;
            this.queryResultsListView.Size = new System.Drawing.Size(999, 459);
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
            this.recursiveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recursiveCheckBox.Location = new System.Drawing.Point(152, 65);
            this.recursiveCheckBox.Name = "recursiveCheckBox";
            this.recursiveCheckBox.Size = new System.Drawing.Size(102, 21);
            this.recursiveCheckBox.TabIndex = 7;
            this.recursiveCheckBox.Text = "Recursive";
            this.recursiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(6, 21);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(335, 22);
            this.filterTextBox.TabIndex = 8;
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.SelectedPath = "C:\\Users\\D760026\\Documents\\WindowsPowerShell";
            this.folderBrowserDialog.ShowNewFolderButton = false;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(393, 25);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(78, 29);
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
            this.statusStrip.Location = new System.Drawing.Point(0, 608);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1030, 26);
            this.statusStrip.TabIndex = 10;
            this.statusStrip.Text = "statusStrip";
            // 
            // searchResultStatusStrip
            // 
            this.searchResultStatusStrip.ForeColor = System.Drawing.Color.Green;
            this.searchResultStatusStrip.Name = "searchResultStatusStrip";
            this.searchResultStatusStrip.Size = new System.Drawing.Size(0, 21);
            // 
            // debuggerDataStatusStrip
            // 
            this.debuggerDataStatusStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.debuggerDataStatusStrip.Image = ((System.Drawing.Image)(resources.GetObject("debuggerDataStatusStrip.Image")));
            this.debuggerDataStatusStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.debuggerDataStatusStrip.Name = "debuggerDataStatusStrip";
            this.debuggerDataStatusStrip.Size = new System.Drawing.Size(124, 24);
            this.debuggerDataStatusStrip.Text = "Debug Data";
            this.debuggerDataStatusStrip.ToolTipText = "Debug Data\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.copyToClipboardCheckBox);
            this.groupBox1.Controls.Add(this.matchCaseCheckBox);
            this.groupBox1.Controls.Add(this.fuzzySearchCheckBox);
            this.groupBox1.Controls.Add(this.findWhatLabel);
            this.groupBox1.Controls.Add(this.queryTextBox);
            this.groupBox1.Controls.Add(this.findButton);
            this.groupBox1.Controls.Add(this.recursiveCheckBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(516, 123);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // copyToClipboardCheckBox
            // 
            this.copyToClipboardCheckBox.AutoSize = true;
            this.copyToClipboardCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyToClipboardCheckBox.Location = new System.Drawing.Point(286, 88);
            this.copyToClipboardCheckBox.Name = "copyToClipboardCheckBox";
            this.copyToClipboardCheckBox.Size = new System.Drawing.Size(215, 21);
            this.copyToClipboardCheckBox.TabIndex = 16;
            this.copyToClipboardCheckBox.Text = "Copy Search to Clipboard";
            this.copyToClipboardCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchCaseCheckBox
            // 
            this.matchCaseCheckBox.AutoSize = true;
            this.matchCaseCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchCaseCheckBox.Location = new System.Drawing.Point(286, 65);
            this.matchCaseCheckBox.Name = "matchCaseCheckBox";
            this.matchCaseCheckBox.Size = new System.Drawing.Size(114, 21);
            this.matchCaseCheckBox.TabIndex = 9;
            this.matchCaseCheckBox.Text = "Match Case";
            this.matchCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // fuzzySearchCheckBox
            // 
            this.fuzzySearchCheckBox.AutoSize = true;
            this.fuzzySearchCheckBox.Checked = true;
            this.fuzzySearchCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fuzzySearchCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fuzzySearchCheckBox.Location = new System.Drawing.Point(152, 88);
            this.fuzzySearchCheckBox.Name = "fuzzySearchCheckBox";
            this.fuzzySearchCheckBox.Size = new System.Drawing.Size(128, 21);
            this.fuzzySearchCheckBox.TabIndex = 15;
            this.fuzzySearchCheckBox.Text = "Fuzzy Search";
            this.fuzzySearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.filterTextBox);
            this.groupBox2.Location = new System.Drawing.Point(667, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 58);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.rootDirectoryTextBox);
            this.groupBox3.Location = new System.Drawing.Point(538, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 59);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Folder Path";
            // 
            // SearchConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 634);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.queryResultsListView);
            this.Controls.Add(this.rootDirectoryLabel);
            this.Name = "SearchConsole";
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

        private System.Windows.Forms.Label findWhatLabel;
        private System.Windows.Forms.Label rootDirectoryLabel;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel searchResultStatusStrip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripDropDownButton debuggerDataStatusStrip;

        // Public controls to be used with the SearchEngine class
        public System.Windows.Forms.TextBox queryTextBox;
        public System.Windows.Forms.TextBox rootDirectoryTextBox;
        public System.Windows.Forms.ListView queryResultsListView;
        public System.Windows.Forms.CheckBox recursiveCheckBox;
        public System.Windows.Forms.TextBox filterTextBox;
        public System.Windows.Forms.CheckBox fuzzySearchCheckBox;
        public System.Windows.Forms.CheckBox matchCaseCheckBox;
        public System.Windows.Forms.CheckBox copyToClipboardCheckBox;
    }
}

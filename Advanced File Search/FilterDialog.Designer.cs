namespace Advanced_File_Search
{
    partial class FilterDialog
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.retrieveExtensionButton = new System.Windows.Forms.Button();
            this.recursiveCheckBox = new System.Windows.Forms.CheckBox();
            this.rootPathLabel = new System.Windows.Forms.Label();
            this.extensionDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.extensionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(13, 43);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(482, 22);
            this.filePathTextBox.TabIndex = 0;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.filePathTextBox.Text = m_BaseDirectory;
            // 
            // retrieveExtensionButton
            // 
            this.retrieveExtensionButton.Location = new System.Drawing.Point(13, 71);
            this.retrieveExtensionButton.Name = "retrieveExtensionButton";
            this.retrieveExtensionButton.Size = new System.Drawing.Size(315, 32);
            this.retrieveExtensionButton.TabIndex = 1;
            this.retrieveExtensionButton.Text = "Retrieve all file extension types in directoy";
            this.retrieveExtensionButton.UseVisualStyleBackColor = true;
            this.retrieveExtensionButton.Click += new System.EventHandler(this.OnRetrieveExtensionButton_Click);
            // 
            // recursiveCheckBox
            // 
            this.recursiveCheckBox.AutoSize = true;
            this.recursiveCheckBox.Checked = true;
            this.recursiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.recursiveCheckBox.Location = new System.Drawing.Point(334, 78);
            this.recursiveCheckBox.Name = "recursiveCheckBox";
            this.recursiveCheckBox.Size = new System.Drawing.Size(93, 21);
            this.recursiveCheckBox.TabIndex = 2;
            this.recursiveCheckBox.Text = "Recursive";
            this.recursiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // rootPathLabel
            // 
            this.rootPathLabel.AutoSize = true;
            this.rootPathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rootPathLabel.Location = new System.Drawing.Point(13, 20);
            this.rootPathLabel.Name = "rootPathLabel";
            this.rootPathLabel.Size = new System.Drawing.Size(85, 17);
            this.rootPathLabel.TabIndex = 3;
            this.rootPathLabel.Text = "Root Path:";
            // 
            // extensionDataGridView
            // 
            this.extensionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.extensionDataGridView.Location = new System.Drawing.Point(13, 145);
            this.extensionDataGridView.Name = "extensionDataGridView";
            this.extensionDataGridView.RowTemplate.Height = 24;
            this.extensionDataGridView.Size = new System.Drawing.Size(482, 96);
            this.extensionDataGridView.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "File Extension:";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(321, 247);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(79, 30);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(406, 247);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(89, 30);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // FilterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(507, 283);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.extensionDataGridView);
            this.Controls.Add(this.rootPathLabel);
            this.Controls.Add(this.recursiveCheckBox);
            this.Controls.Add(this.retrieveExtensionButton);
            this.Controls.Add(this.filePathTextBox);
            this.MaximumSize = new System.Drawing.Size(525, 1000);
            this.MinimumSize = new System.Drawing.Size(525, 330);
            this.Name = "FilterDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FilterDialog";
            ((System.ComponentModel.ISupportInitialize)(this.extensionDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button retrieveExtensionButton;
        private System.Windows.Forms.CheckBox recursiveCheckBox;
        private System.Windows.Forms.Label rootPathLabel;
        private System.Windows.Forms.DataGridView extensionDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}
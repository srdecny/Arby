namespace Arby
{
    partial class SnapshotManager
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
            this.ImportedEventsBox = new System.Windows.Forms.ListBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.FileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.ImportedEventSnapshotsView = new System.Windows.Forms.DataGridView();
            this.ImportedRunnerFilterBox = new System.Windows.Forms.ComboBox();
            this.ImportedMarketFilterBox = new System.Windows.Forms.ComboBox();
            this.WorkspaceEventsBox = new System.Windows.Forms.ListBox();
            this.WorkspaceEventSnapshotsView = new System.Windows.Forms.DataGridView();
            this.WorkspaceMarketBox = new System.Windows.Forms.ComboBox();
            this.WorkspaceRunnerBox = new System.Windows.Forms.ComboBox();
            this.ToWorkspaceButton = new System.Windows.Forms.Button();
            this.ImportOriginalDatabaseButton = new System.Windows.Forms.Button();
            this.ToImportedButton = new System.Windows.Forms.Button();
            this.ClearImportedButton = new System.Windows.Forms.Button();
            this.ClearWorkspaceButton = new System.Windows.Forms.Button();
            this.ExportToFileButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.FileSaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ImportedEventSnapshotsView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceEventSnapshotsView)).BeginInit();
            this.SuspendLayout();
            // 
            // ImportedEventsBox
            // 
            this.ImportedEventsBox.FormattingEnabled = true;
            this.ImportedEventsBox.Location = new System.Drawing.Point(440, 44);
            this.ImportedEventsBox.Name = "ImportedEventsBox";
            this.ImportedEventsBox.Size = new System.Drawing.Size(156, 394);
            this.ImportedEventsBox.TabIndex = 0;
            this.ImportedEventsBox.SelectedIndexChanged += new System.EventHandler(this.ImportedEventsBox_SelectedIndexChanged);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(440, 12);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(156, 23);
            this.ImportButton.TabIndex = 1;
            this.ImportButton.Text = "Import from file";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // FileSelectDialog
            // 
            this.FileSelectDialog.FileName = "openFileDialog1";
            // 
            // ImportedEventSnapshotsView
            // 
            this.ImportedEventSnapshotsView.AllowUserToAddRows = false;
            this.ImportedEventSnapshotsView.AllowUserToDeleteRows = false;
            this.ImportedEventSnapshotsView.AllowUserToOrderColumns = true;
            this.ImportedEventSnapshotsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ImportedEventSnapshotsView.Location = new System.Drawing.Point(33, 44);
            this.ImportedEventSnapshotsView.Name = "ImportedEventSnapshotsView";
            this.ImportedEventSnapshotsView.Size = new System.Drawing.Size(382, 394);
            this.ImportedEventSnapshotsView.TabIndex = 2;
            // 
            // ImportedRunnerFilterBox
            // 
            this.ImportedRunnerFilterBox.FormattingEnabled = true;
            this.ImportedRunnerFilterBox.Location = new System.Drawing.Point(33, 12);
            this.ImportedRunnerFilterBox.Name = "ImportedRunnerFilterBox";
            this.ImportedRunnerFilterBox.Size = new System.Drawing.Size(121, 21);
            this.ImportedRunnerFilterBox.TabIndex = 3;
            this.ImportedRunnerFilterBox.SelectedIndexChanged += new System.EventHandler(this.FilterEventSnapshotsView);
            // 
            // ImportedMarketFilterBox
            // 
            this.ImportedMarketFilterBox.FormattingEnabled = true;
            this.ImportedMarketFilterBox.Location = new System.Drawing.Point(160, 12);
            this.ImportedMarketFilterBox.Name = "ImportedMarketFilterBox";
            this.ImportedMarketFilterBox.Size = new System.Drawing.Size(121, 21);
            this.ImportedMarketFilterBox.TabIndex = 4;
            this.ImportedMarketFilterBox.SelectedIndexChanged += new System.EventHandler(this.FilterEventSnapshotsView);
            // 
            // WorkspaceEventsBox
            // 
            this.WorkspaceEventsBox.FormattingEnabled = true;
            this.WorkspaceEventsBox.Location = new System.Drawing.Point(722, 44);
            this.WorkspaceEventsBox.Name = "WorkspaceEventsBox";
            this.WorkspaceEventsBox.Size = new System.Drawing.Size(163, 394);
            this.WorkspaceEventsBox.TabIndex = 5;
            this.WorkspaceEventsBox.SelectedIndexChanged += new System.EventHandler(this.WorkspaceEventsBox_SelectedIndexChanged);
            // 
            // WorkspaceEventSnapshotsView
            // 
            this.WorkspaceEventSnapshotsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WorkspaceEventSnapshotsView.Location = new System.Drawing.Point(920, 44);
            this.WorkspaceEventSnapshotsView.Name = "WorkspaceEventSnapshotsView";
            this.WorkspaceEventSnapshotsView.Size = new System.Drawing.Size(372, 394);
            this.WorkspaceEventSnapshotsView.TabIndex = 6;
            // 
            // WorkspaceMarketBox
            // 
            this.WorkspaceMarketBox.FormattingEnabled = true;
            this.WorkspaceMarketBox.Location = new System.Drawing.Point(1171, 12);
            this.WorkspaceMarketBox.Name = "WorkspaceMarketBox";
            this.WorkspaceMarketBox.Size = new System.Drawing.Size(121, 21);
            this.WorkspaceMarketBox.TabIndex = 7;
            // 
            // WorkspaceRunnerBox
            // 
            this.WorkspaceRunnerBox.FormattingEnabled = true;
            this.WorkspaceRunnerBox.Location = new System.Drawing.Point(1044, 12);
            this.WorkspaceRunnerBox.Name = "WorkspaceRunnerBox";
            this.WorkspaceRunnerBox.Size = new System.Drawing.Size(121, 21);
            this.WorkspaceRunnerBox.TabIndex = 8;
            // 
            // ToWorkspaceButton
            // 
            this.ToWorkspaceButton.Location = new System.Drawing.Point(602, 44);
            this.ToWorkspaceButton.Name = "ToWorkspaceButton";
            this.ToWorkspaceButton.Size = new System.Drawing.Size(114, 23);
            this.ToWorkspaceButton.TabIndex = 9;
            this.ToWorkspaceButton.Text = "Shift to Workspace";
            this.ToWorkspaceButton.UseVisualStyleBackColor = true;
            this.ToWorkspaceButton.Click += new System.EventHandler(this.ToWorkspaceButton_Click);
            // 
            // ImportOriginalDatabaseButton
            // 
            this.ImportOriginalDatabaseButton.Location = new System.Drawing.Point(722, 10);
            this.ImportOriginalDatabaseButton.Name = "ImportOriginalDatabaseButton";
            this.ImportOriginalDatabaseButton.Size = new System.Drawing.Size(163, 23);
            this.ImportOriginalDatabaseButton.TabIndex = 10;
            this.ImportOriginalDatabaseButton.Text = "Import application database";
            this.ImportOriginalDatabaseButton.UseVisualStyleBackColor = true;
            this.ImportOriginalDatabaseButton.Click += new System.EventHandler(this.ImportOriginalDatabaseButton_Click);
            // 
            // ToImportedButton
            // 
            this.ToImportedButton.Location = new System.Drawing.Point(602, 73);
            this.ToImportedButton.Name = "ToImportedButton";
            this.ToImportedButton.Size = new System.Drawing.Size(114, 25);
            this.ToImportedButton.TabIndex = 11;
            this.ToImportedButton.Text = "Shift to Imported";
            this.ToImportedButton.UseVisualStyleBackColor = true;
            this.ToImportedButton.Click += new System.EventHandler(this.ToImportedButton_Click);
            // 
            // ClearImportedButton
            // 
            this.ClearImportedButton.Location = new System.Drawing.Point(602, 121);
            this.ClearImportedButton.Name = "ClearImportedButton";
            this.ClearImportedButton.Size = new System.Drawing.Size(114, 25);
            this.ClearImportedButton.TabIndex = 12;
            this.ClearImportedButton.Text = "Clear Imported";
            this.ClearImportedButton.UseVisualStyleBackColor = true;
            this.ClearImportedButton.Click += new System.EventHandler(this.ClearImportedButton_Click);
            // 
            // ClearWorkspaceButton
            // 
            this.ClearWorkspaceButton.Location = new System.Drawing.Point(602, 152);
            this.ClearWorkspaceButton.Name = "ClearWorkspaceButton";
            this.ClearWorkspaceButton.Size = new System.Drawing.Size(114, 25);
            this.ClearWorkspaceButton.TabIndex = 13;
            this.ClearWorkspaceButton.Text = "Clear Workspace";
            this.ClearWorkspaceButton.UseVisualStyleBackColor = true;
            this.ClearWorkspaceButton.Click += new System.EventHandler(this.ClearWorkspaceButton_Click);
            // 
            // ExportToFileButton
            // 
            this.ExportToFileButton.Location = new System.Drawing.Point(287, 10);
            this.ExportToFileButton.Name = "ExportToFileButton";
            this.ExportToFileButton.Size = new System.Drawing.Size(128, 23);
            this.ExportToFileButton.TabIndex = 14;
            this.ExportToFileButton.Text = "Export to file";
            this.ExportToFileButton.UseVisualStyleBackColor = true;
            this.ExportToFileButton.Click += new System.EventHandler(this.ExportToFileButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(602, 195);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(114, 38);
            this.ExitButton.TabIndex = 15;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SnapshotManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1319, 463);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.ExportToFileButton);
            this.Controls.Add(this.ClearWorkspaceButton);
            this.Controls.Add(this.ClearImportedButton);
            this.Controls.Add(this.ToImportedButton);
            this.Controls.Add(this.ImportOriginalDatabaseButton);
            this.Controls.Add(this.ToWorkspaceButton);
            this.Controls.Add(this.WorkspaceRunnerBox);
            this.Controls.Add(this.WorkspaceMarketBox);
            this.Controls.Add(this.WorkspaceEventSnapshotsView);
            this.Controls.Add(this.WorkspaceEventsBox);
            this.Controls.Add(this.ImportedMarketFilterBox);
            this.Controls.Add(this.ImportedRunnerFilterBox);
            this.Controls.Add(this.ImportedEventSnapshotsView);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ImportedEventsBox);
            this.Name = "SnapshotManager";
            this.Text = "SnapshotManager";
            ((System.ComponentModel.ISupportInitialize)(this.ImportedEventSnapshotsView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkspaceEventSnapshotsView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ImportedEventsBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.OpenFileDialog FileSelectDialog;
        private System.Windows.Forms.DataGridView ImportedEventSnapshotsView;
        private System.Windows.Forms.ComboBox ImportedRunnerFilterBox;
        private System.Windows.Forms.ComboBox ImportedMarketFilterBox;
        private System.Windows.Forms.ListBox WorkspaceEventsBox;
        private System.Windows.Forms.DataGridView WorkspaceEventSnapshotsView;
        private System.Windows.Forms.ComboBox WorkspaceMarketBox;
        private System.Windows.Forms.ComboBox WorkspaceRunnerBox;
        private System.Windows.Forms.Button ToWorkspaceButton;
        private System.Windows.Forms.Button ImportOriginalDatabaseButton;
        private System.Windows.Forms.Button ToImportedButton;
        private System.Windows.Forms.Button ClearImportedButton;
        private System.Windows.Forms.Button ClearWorkspaceButton;
        private System.Windows.Forms.Button ExportToFileButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.SaveFileDialog FileSaveDialog;
    }
}
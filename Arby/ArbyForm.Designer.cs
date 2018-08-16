namespace Arby
{
    partial class ArbyForm
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
            this.LoginButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.EventsBox = new System.Windows.Forms.ListBox();
            this.getPricesButton = new System.Windows.Forms.Button();
            this.ScraperAddButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ScrapedEventsListBox = new System.Windows.Forms.ListBox();
            this.FileSelectDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.SnapshotVisualization = new System.Windows.Forms.DataGridView();
            this.UpdateSnapshotView = new System.Windows.Forms.Button();
            this.SnapshotManagerButton = new System.Windows.Forms.Button();
            this.VisualizerButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ScraperRemoveButton = new System.Windows.Forms.Button();
            this.FortunaFeedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotVisualization)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(12, 41);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(126, 23);
            this.LoginButton.TabIndex = 0;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Get popular events";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(486, 574);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(322, 20);
            this.LoginBox.TabIndex = 3;
            this.LoginBox.Text = "Not logged in.";
            // 
            // EventsBox
            // 
            this.EventsBox.FormattingEnabled = true;
            this.EventsBox.Location = new System.Drawing.Point(12, 112);
            this.EventsBox.Name = "EventsBox";
            this.EventsBox.Size = new System.Drawing.Size(159, 303);
            this.EventsBox.TabIndex = 4;
            // 
            // getPricesButton
            // 
            this.getPricesButton.Location = new System.Drawing.Point(199, 70);
            this.getPricesButton.Name = "getPricesButton";
            this.getPricesButton.Size = new System.Drawing.Size(110, 23);
            this.getPricesButton.TabIndex = 6;
            this.getPricesButton.Text = "Get market prices";
            this.getPricesButton.UseVisualStyleBackColor = true;
            this.getPricesButton.Click += new System.EventHandler(this.getPricesButton_Click);
            // 
            // ScraperAddButton
            // 
            this.ScraperAddButton.Location = new System.Drawing.Point(12, 432);
            this.ScraperAddButton.Name = "ScraperAddButton";
            this.ScraperAddButton.Size = new System.Drawing.Size(135, 24);
            this.ScraperAddButton.TabIndex = 10;
            this.ScraperAddButton.Text = "Add to scraper";
            this.ScraperAddButton.UseVisualStyleBackColor = true;
            this.ScraperAddButton.Click += new System.EventHandler(this.ScraperButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(199, 112);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(599, 303);
            this.dataGridView1.TabIndex = 7;
            // 
            // ScrapedEventsListBox
            // 
            this.ScrapedEventsListBox.FormattingEnabled = true;
            this.ScrapedEventsListBox.Location = new System.Drawing.Point(12, 490);
            this.ScrapedEventsListBox.Name = "ScrapedEventsListBox";
            this.ScrapedEventsListBox.Size = new System.Drawing.Size(135, 95);
            this.ScrapedEventsListBox.TabIndex = 11;
            // 
            // FileSelectDialog
            // 
            this.FileSelectDialog.FileName = "openFileDialog1";
            // 
            // SnapshotVisualization
            // 
            this.SnapshotVisualization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SnapshotVisualization.Location = new System.Drawing.Point(174, 490);
            this.SnapshotVisualization.Name = "SnapshotVisualization";
            this.SnapshotVisualization.Size = new System.Drawing.Size(306, 95);
            this.SnapshotVisualization.TabIndex = 15;
            // 
            // UpdateSnapshotView
            // 
            this.UpdateSnapshotView.Location = new System.Drawing.Point(174, 452);
            this.UpdateSnapshotView.Name = "UpdateSnapshotView";
            this.UpdateSnapshotView.Size = new System.Drawing.Size(171, 23);
            this.UpdateSnapshotView.TabIndex = 16;
            this.UpdateSnapshotView.Text = "Refresh scraped events info";
            this.UpdateSnapshotView.UseVisualStyleBackColor = true;
            this.UpdateSnapshotView.Click += new System.EventHandler(this.UpdateSnapshotView_Click);
            // 
            // SnapshotManagerButton
            // 
            this.SnapshotManagerButton.Location = new System.Drawing.Point(12, 12);
            this.SnapshotManagerButton.Name = "SnapshotManagerButton";
            this.SnapshotManagerButton.Size = new System.Drawing.Size(126, 23);
            this.SnapshotManagerButton.TabIndex = 17;
            this.SnapshotManagerButton.Text = "Snapshot Manager";
            this.SnapshotManagerButton.UseVisualStyleBackColor = true;
            this.SnapshotManagerButton.Click += new System.EventHandler(this.SnapshotManagerButton_Click);
            // 
            // VisualizerButton
            // 
            this.VisualizerButton.Location = new System.Drawing.Point(144, 12);
            this.VisualizerButton.Name = "VisualizerButton";
            this.VisualizerButton.Size = new System.Drawing.Size(123, 23);
            this.VisualizerButton.TabIndex = 18;
            this.VisualizerButton.Text = "Snapshot Visualizer";
            this.VisualizerButton.UseVisualStyleBackColor = true;
            this.VisualizerButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Location = new System.Drawing.Point(273, 12);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(121, 23);
            this.SettingsButton.TabIndex = 19;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // ScraperRemoveButton
            // 
            this.ScraperRemoveButton.Location = new System.Drawing.Point(13, 462);
            this.ScraperRemoveButton.Name = "ScraperRemoveButton";
            this.ScraperRemoveButton.Size = new System.Drawing.Size(134, 22);
            this.ScraperRemoveButton.TabIndex = 20;
            this.ScraperRemoveButton.Text = "Remove from scraper";
            this.ScraperRemoveButton.UseVisualStyleBackColor = true;
            this.ScraperRemoveButton.Click += new System.EventHandler(this.ScraperRemoveButton_Click);
            // 
            // FortunaFeedButton
            // 
            this.FortunaFeedButton.Location = new System.Drawing.Point(400, 12);
            this.FortunaFeedButton.Name = "FortunaFeedButton";
            this.FortunaFeedButton.Size = new System.Drawing.Size(115, 23);
            this.FortunaFeedButton.TabIndex = 21;
            this.FortunaFeedButton.Text = "Fortuna XML feed";
            this.FortunaFeedButton.UseVisualStyleBackColor = true;
            this.FortunaFeedButton.Click += new System.EventHandler(this.FortunaFeedButton_Click);
            // 
            // ArbyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 592);
            this.Controls.Add(this.FortunaFeedButton);
            this.Controls.Add(this.ScraperRemoveButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.VisualizerButton);
            this.Controls.Add(this.SnapshotManagerButton);
            this.Controls.Add(this.UpdateSnapshotView);
            this.Controls.Add(this.SnapshotVisualization);
            this.Controls.Add(this.ScrapedEventsListBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ScraperAddButton);
            this.Controls.Add(this.getPricesButton);
            this.Controls.Add(this.EventsBox);
            this.Controls.Add(this.LoginBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.LoginButton);
            this.Name = "ArbyForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnapshotVisualization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.ListBox EventsBox;
        private System.Windows.Forms.Button getPricesButton;
        private System.Windows.Forms.Button ScraperAddButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox ScrapedEventsListBox;
        private System.Windows.Forms.OpenFileDialog FileSelectDialog;
        private System.Windows.Forms.SaveFileDialog FileSaveDialog;
        private System.Windows.Forms.DataGridView SnapshotVisualization;
        private System.Windows.Forms.Button UpdateSnapshotView;
        private System.Windows.Forms.Button SnapshotManagerButton;
        private System.Windows.Forms.Button VisualizerButton;
        private System.Windows.Forms.Button SettingsButton;
        private System.Windows.Forms.Button ScraperRemoveButton;
        private System.Windows.Forms.Button FortunaFeedButton;
    }
}


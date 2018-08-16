namespace Arby
{
    partial class FortunaFeed
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
            this.EventNameBox = new System.Windows.Forms.TextBox();
            this.FindEventsButton = new System.Windows.Forms.Button();
            this.SearchResultsView = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ScrapedEventsBox = new System.Windows.Forms.ListBox();
            this.UpdateScrapedEventsButton = new System.Windows.Forms.Button();
            this.AddToArbitrageButton = new System.Windows.Forms.Button();
            this.RemoveFromArbitrageButton = new System.Windows.Forms.Button();
            this.ArbitrageEventsBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsView)).BeginInit();
            this.SuspendLayout();
            // 
            // EventNameBox
            // 
            this.EventNameBox.Location = new System.Drawing.Point(12, 80);
            this.EventNameBox.Name = "EventNameBox";
            this.EventNameBox.Size = new System.Drawing.Size(138, 20);
            this.EventNameBox.TabIndex = 2;
            // 
            // FindEventsButton
            // 
            this.FindEventsButton.Location = new System.Drawing.Point(12, 12);
            this.FindEventsButton.Name = "FindEventsButton";
            this.FindEventsButton.Size = new System.Drawing.Size(138, 23);
            this.FindEventsButton.TabIndex = 4;
            this.FindEventsButton.Text = "Get Fortuna events";
            this.FindEventsButton.UseVisualStyleBackColor = true;
            this.FindEventsButton.Click += new System.EventHandler(this.FindEventsButton_Click);
            // 
            // SearchResultsView
            // 
            this.SearchResultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SearchResultsView.Location = new System.Drawing.Point(166, 12);
            this.SearchResultsView.Name = "SearchResultsView";
            this.SearchResultsView.Size = new System.Drawing.Size(754, 475);
            this.SearchResultsView.TabIndex = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(12, 51);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(138, 23);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "Search for event";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ScrapedEventsBox
            // 
            this.ScrapedEventsBox.FormattingEnabled = true;
            this.ScrapedEventsBox.Location = new System.Drawing.Point(12, 150);
            this.ScrapedEventsBox.Name = "ScrapedEventsBox";
            this.ScrapedEventsBox.Size = new System.Drawing.Size(138, 303);
            this.ScrapedEventsBox.TabIndex = 7;
            // 
            // UpdateScrapedEventsButton
            // 
            this.UpdateScrapedEventsButton.Location = new System.Drawing.Point(12, 121);
            this.UpdateScrapedEventsButton.Name = "UpdateScrapedEventsButton";
            this.UpdateScrapedEventsButton.Size = new System.Drawing.Size(138, 23);
            this.UpdateScrapedEventsButton.TabIndex = 8;
            this.UpdateScrapedEventsButton.Text = "Update scraped events";
            this.UpdateScrapedEventsButton.UseVisualStyleBackColor = true;
            this.UpdateScrapedEventsButton.Click += new System.EventHandler(this.UpdateScrapedEventsButton_Click);
            // 
            // AddToArbitrageButton
            // 
            this.AddToArbitrageButton.Location = new System.Drawing.Point(926, 12);
            this.AddToArbitrageButton.Name = "AddToArbitrageButton";
            this.AddToArbitrageButton.Size = new System.Drawing.Size(145, 23);
            this.AddToArbitrageButton.TabIndex = 10;
            this.AddToArbitrageButton.Text = "Add to watched";
            this.AddToArbitrageButton.UseVisualStyleBackColor = true;
            this.AddToArbitrageButton.Click += new System.EventHandler(this.AddToArbitrageButton_Click);
            // 
            // RemoveFromArbitrageButton
            // 
            this.RemoveFromArbitrageButton.Location = new System.Drawing.Point(926, 41);
            this.RemoveFromArbitrageButton.Name = "RemoveFromArbitrageButton";
            this.RemoveFromArbitrageButton.Size = new System.Drawing.Size(145, 23);
            this.RemoveFromArbitrageButton.TabIndex = 11;
            this.RemoveFromArbitrageButton.Text = "Remove from watched";
            this.RemoveFromArbitrageButton.UseVisualStyleBackColor = true;
            this.RemoveFromArbitrageButton.Click += new System.EventHandler(this.RemoveFromArbitrageButton_Click);
            // 
            // ArbitrageEventsBox
            // 
            this.ArbitrageEventsBox.FormattingEnabled = true;
            this.ArbitrageEventsBox.Location = new System.Drawing.Point(1087, 12);
            this.ArbitrageEventsBox.Name = "ArbitrageEventsBox";
            this.ArbitrageEventsBox.Size = new System.Drawing.Size(127, 472);
            this.ArbitrageEventsBox.TabIndex = 12;
            // 
            // FortunaFeed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 499);
            this.Controls.Add(this.ArbitrageEventsBox);
            this.Controls.Add(this.RemoveFromArbitrageButton);
            this.Controls.Add(this.AddToArbitrageButton);
            this.Controls.Add(this.UpdateScrapedEventsButton);
            this.Controls.Add(this.ScrapedEventsBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SearchResultsView);
            this.Controls.Add(this.FindEventsButton);
            this.Controls.Add(this.EventNameBox);
            this.Name = "FortunaFeed";
            this.Text = "FortunaFeed";
            ((System.ComponentModel.ISupportInitialize)(this.SearchResultsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox EventNameBox;
        private System.Windows.Forms.Button FindEventsButton;
        private System.Windows.Forms.DataGridView SearchResultsView;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ListBox ScrapedEventsBox;
        private System.Windows.Forms.Button UpdateScrapedEventsButton;
        private System.Windows.Forms.Button AddToArbitrageButton;
        private System.Windows.Forms.Button RemoveFromArbitrageButton;
        private System.Windows.Forms.ListBox ArbitrageEventsBox;
    }
}
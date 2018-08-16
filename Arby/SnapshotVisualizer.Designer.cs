namespace Arby
{
    partial class SnapshotVisualizer
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.EventsBox = new System.Windows.Forms.ListBox();
            this.MatchPriceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.RunnersBox = new System.Windows.Forms.ComboBox();
            this.BetTypeBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.MatchPriceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // EventsBox
            // 
            this.EventsBox.FormattingEnabled = true;
            this.EventsBox.Location = new System.Drawing.Point(12, 45);
            this.EventsBox.Name = "EventsBox";
            this.EventsBox.Size = new System.Drawing.Size(164, 381);
            this.EventsBox.TabIndex = 0;
            this.EventsBox.SelectedIndexChanged += new System.EventHandler(this.EventsBox_SelectedIndexChanged);
            // 
            // MatchPriceChart
            // 
            chartArea5.Name = "ChartArea1";
            this.MatchPriceChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.MatchPriceChart.Legends.Add(legend5);
            this.MatchPriceChart.Location = new System.Drawing.Point(182, 45);
            this.MatchPriceChart.Name = "MatchPriceChart";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Series1";
            this.MatchPriceChart.Series.Add(series5);
            this.MatchPriceChart.Size = new System.Drawing.Size(595, 381);
            this.MatchPriceChart.TabIndex = 1;
            this.MatchPriceChart.Text = "chart1";
            // 
            // RunnersBox
            // 
            this.RunnersBox.FormattingEnabled = true;
            this.RunnersBox.Location = new System.Drawing.Point(182, 18);
            this.RunnersBox.Name = "RunnersBox";
            this.RunnersBox.Size = new System.Drawing.Size(121, 21);
            this.RunnersBox.TabIndex = 2;
            this.RunnersBox.SelectedIndexChanged += new System.EventHandler(this.RunnersBox_SelectedIndexChanged);
            // 
            // BetTypeBox
            // 
            this.BetTypeBox.FormattingEnabled = true;
            this.BetTypeBox.Items.AddRange(new object[] {
            "BACK",
            "LAY"});
            this.BetTypeBox.Location = new System.Drawing.Point(309, 18);
            this.BetTypeBox.Name = "BetTypeBox";
            this.BetTypeBox.Size = new System.Drawing.Size(121, 21);
            this.BetTypeBox.TabIndex = 3;
            this.BetTypeBox.SelectedIndexChanged += new System.EventHandler(this.BetTypeBox_SelectedIndexChanged);
            // 
            // SnapshotVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 450);
            this.Controls.Add(this.BetTypeBox);
            this.Controls.Add(this.RunnersBox);
            this.Controls.Add(this.MatchPriceChart);
            this.Controls.Add(this.EventsBox);
            this.Name = "SnapshotVisualizer";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.MatchPriceChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox EventsBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart MatchPriceChart;
        private System.Windows.Forms.ComboBox RunnersBox;
        private System.Windows.Forms.ComboBox BetTypeBox;
    }
}
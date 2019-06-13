namespace FinanceApp
{
    partial class StratificationPage
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.assetPriceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtstart = new System.Windows.Forms.DateTimePicker();
            this.dtend = new System.Windows.Forms.DateTimePicker();
            this.btnsearch = new System.Windows.Forms.Button();
            this.idasset = new System.Windows.Forms.TextBox();
            this.growthChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.accelerationChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.assetPriceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.growthChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accelerationChart)).BeginInit();
            this.SuspendLayout();
            // 
            // assetPriceChart
            // 
            this.assetPriceChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.assetPriceChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.assetPriceChart.Legends.Add(legend1);
            this.assetPriceChart.Location = new System.Drawing.Point(12, 72);
            this.assetPriceChart.Name = "assetPriceChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.LabelAngle = 90;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.assetPriceChart.Series.Add(series1);
            this.assetPriceChart.Size = new System.Drawing.Size(776, 118);
            this.assetPriceChart.TabIndex = 2;
            // 
            // dtstart
            // 
            this.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtstart.Location = new System.Drawing.Point(183, 25);
            this.dtstart.Name = "dtstart";
            this.dtstart.Size = new System.Drawing.Size(200, 20);
            this.dtstart.TabIndex = 3;
            // 
            // dtend
            // 
            this.dtend.Location = new System.Drawing.Point(389, 25);
            this.dtend.Name = "dtend";
            this.dtend.Size = new System.Drawing.Size(200, 20);
            this.dtend.TabIndex = 4;
            // 
            // btnsearch
            // 
            this.btnsearch.Location = new System.Drawing.Point(595, 24);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 23);
            this.btnsearch.TabIndex = 6;
            this.btnsearch.Text = "button1";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // idasset
            // 
            this.idasset.Location = new System.Drawing.Point(77, 25);
            this.idasset.Name = "idasset";
            this.idasset.Size = new System.Drawing.Size(100, 20);
            this.idasset.TabIndex = 7;
            // 
            // growthChart
            // 
            this.growthChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea2.AxisY.MajorTickMark.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.growthChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.growthChart.Legends.Add(legend2);
            this.growthChart.Location = new System.Drawing.Point(12, 196);
            this.growthChart.Name = "growthChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.LabelAngle = 90;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.growthChart.Series.Add(series2);
            this.growthChart.Size = new System.Drawing.Size(776, 118);
            this.growthChart.TabIndex = 8;
            // 
            // accelerationChart
            // 
            this.accelerationChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.IsStartedFromZero = false;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea3.AxisY.MajorTickMark.Enabled = false;
            chartArea3.Name = "ChartArea1";
            this.accelerationChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.accelerationChart.Legends.Add(legend3);
            this.accelerationChart.Location = new System.Drawing.Point(12, 320);
            this.accelerationChart.Name = "accelerationChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.LabelAngle = 90;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            this.accelerationChart.Series.Add(series3);
            this.accelerationChart.Size = new System.Drawing.Size(776, 118);
            this.accelerationChart.TabIndex = 9;
            // 
            // StratificationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.accelerationChart);
            this.Controls.Add(this.growthChart);
            this.Controls.Add(this.idasset);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.dtend);
            this.Controls.Add(this.dtstart);
            this.Controls.Add(this.assetPriceChart);
            this.Name = "StratificationPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StratificationPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.assetPriceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.growthChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accelerationChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart assetPriceChart;
        private System.Windows.Forms.DateTimePicker dtstart;
        private System.Windows.Forms.DateTimePicker dtend;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox idasset;
        private System.Windows.Forms.DataVisualization.Charting.Chart growthChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart accelerationChart;
    }
}
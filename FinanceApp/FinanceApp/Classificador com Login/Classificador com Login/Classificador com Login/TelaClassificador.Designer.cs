namespace Classificador_com_Login
{
    partial class TelaClassificador
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaClassificador));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtSelecionar = new System.Windows.Forms.Button();
            this.BtClassificar = new System.Windows.Forms.Button();
            this.BtVoltar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ChartMercadoria = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.ChartMercadoria)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // BtSelecionar
            // 
            this.BtSelecionar.Location = new System.Drawing.Point(228, 471);
            this.BtSelecionar.Name = "BtSelecionar";
            this.BtSelecionar.Size = new System.Drawing.Size(157, 39);
            this.BtSelecionar.TabIndex = 1;
            this.BtSelecionar.Text = "Selecionar Arquivo";
            this.BtSelecionar.UseVisualStyleBackColor = true;
            this.BtSelecionar.Click += new System.EventHandler(this.BtSelecionar_Click);
            // 
            // BtClassificar
            // 
            this.BtClassificar.Location = new System.Drawing.Point(428, 471);
            this.BtClassificar.Name = "BtClassificar";
            this.BtClassificar.Size = new System.Drawing.Size(157, 39);
            this.BtClassificar.TabIndex = 2;
            this.BtClassificar.Text = "Classificar";
            this.BtClassificar.UseVisualStyleBackColor = true;
            this.BtClassificar.Click += new System.EventHandler(this.BtClassificar_Click);
            // 
            // BtVoltar
            // 
            this.BtVoltar.Location = new System.Drawing.Point(328, 530);
            this.BtVoltar.Name = "BtVoltar";
            this.BtVoltar.Size = new System.Drawing.Size(157, 39);
            this.BtVoltar.TabIndex = 3;
            this.BtVoltar.Text = "Voltar";
            this.BtVoltar.UseVisualStyleBackColor = true;
            this.BtVoltar.Click += new System.EventHandler(this.BtVoltar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 9);
            this.label1.MaximumSize = new System.Drawing.Size(120, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "AnaliticSA Classificador";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChartMercadoria
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartMercadoria.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartMercadoria.Legends.Add(legend1);
            this.ChartMercadoria.Location = new System.Drawing.Point(174, 66);
            this.ChartMercadoria.Name = "ChartMercadoria";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Valor";
            series1.YValueMembers = "Valor";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.LabelBorderWidth = 10;
            series2.Legend = "Legend1";
            series2.Name = "Media";
            this.ChartMercadoria.Series.Add(series1);
            this.ChartMercadoria.Series.Add(series2);
            this.ChartMercadoria.Size = new System.Drawing.Size(448, 281);
            this.ChartMercadoria.TabIndex = 5;
            this.ChartMercadoria.Text = "chart1";
            // 
            // TelaClassificador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.ChartMercadoria);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtVoltar);
            this.Controls.Add(this.BtClassificar);
            this.Controls.Add(this.BtSelecionar);
            this.Name = "TelaClassificador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaClassificador";
            this.Load += new System.EventHandler(this.TelaClassificador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChartMercadoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BtSelecionar;
        private System.Windows.Forms.Button BtClassificar;
        private System.Windows.Forms.Button BtVoltar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartMercadoria;
    }
}
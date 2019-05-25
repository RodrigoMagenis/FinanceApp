namespace Classificador_com_Login
{
    partial class TelaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuClassificador = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuVoltar = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelAnaliticsSA = new System.Windows.Forms.Label();
            this.MenuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuClassificador,
            this.MenuVoltar});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Margin = new System.Windows.Forms.Padding(1);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(800, 31);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuClassificador
            // 
            this.MenuClassificador.Name = "MenuClassificador";
            this.MenuClassificador.Size = new System.Drawing.Size(116, 27);
            this.MenuClassificador.Text = "Classificador";
            this.MenuClassificador.Click += new System.EventHandler(this.MenuClassificador_Click);
            // 
            // MenuVoltar
            // 
            this.MenuVoltar.Name = "MenuVoltar";
            this.MenuVoltar.Size = new System.Drawing.Size(67, 27);
            this.MenuVoltar.Text = "Voltar";
            this.MenuVoltar.Click += new System.EventHandler(this.MenuVoltar_Click);
            // 
            // LabelAnaliticsSA
            // 
            this.LabelAnaliticsSA.AutoSize = true;
            this.LabelAnaliticsSA.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelAnaliticsSA.Location = new System.Drawing.Point(335, 274);
            this.LabelAnaliticsSA.MaximumSize = new System.Drawing.Size(200, 0);
            this.LabelAnaliticsSA.Name = "LabelAnaliticsSA";
            this.LabelAnaliticsSA.Size = new System.Drawing.Size(121, 29);
            this.LabelAnaliticsSA.TabIndex = 1;
            this.LabelAnaliticsSA.Text = "AnaliticSA";
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.LabelAnaliticsSA);
            this.Controls.Add(this.MenuPrincipal);
            this.MainMenuStrip = this.MenuPrincipal;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPrincipal";
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuClassificador;
        private System.Windows.Forms.ToolStripMenuItem MenuVoltar;
        private System.Windows.Forms.Label LabelAnaliticsSA;
    }
}
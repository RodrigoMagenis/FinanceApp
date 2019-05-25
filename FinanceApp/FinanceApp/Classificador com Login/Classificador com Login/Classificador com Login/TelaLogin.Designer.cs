namespace Classificador_com_Login
{
    partial class TelaLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaLogin));
            this.BtLogar = new System.Windows.Forms.Button();
            this.LabelNome = new System.Windows.Forms.Label();
            this.LabelSenha = new System.Windows.Forms.Label();
            this.CaixaNome = new System.Windows.Forms.TextBox();
            this.CaixaSenha = new System.Windows.Forms.TextBox();
            this.LabelNomePrograma = new System.Windows.Forms.Label();
            this.LabelLogin = new System.Windows.Forms.Label();
            this.BtSair = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtLogar
            // 
            this.BtLogar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtLogar.Location = new System.Drawing.Point(481, 363);
            this.BtLogar.Name = "BtLogar";
            this.BtLogar.Size = new System.Drawing.Size(143, 69);
            this.BtLogar.TabIndex = 0;
            this.BtLogar.Text = "Logar";
            this.BtLogar.UseVisualStyleBackColor = true;
            this.BtLogar.Click += new System.EventHandler(this.BtLogar_Click);
            // 
            // LabelNome
            // 
            this.LabelNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNome.AutoSize = true;
            this.LabelNome.Location = new System.Drawing.Point(183, 151);
            this.LabelNome.Name = "LabelNome";
            this.LabelNome.Size = new System.Drawing.Size(49, 17);
            this.LabelNome.TabIndex = 3;
            this.LabelNome.Text = "Nome:";
            // 
            // LabelSenha
            // 
            this.LabelSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelSenha.AutoSize = true;
            this.LabelSenha.Location = new System.Drawing.Point(183, 238);
            this.LabelSenha.Name = "LabelSenha";
            this.LabelSenha.Size = new System.Drawing.Size(53, 17);
            this.LabelSenha.TabIndex = 4;
            this.LabelSenha.Text = "Senha:";
            // 
            // CaixaNome
            // 
            this.CaixaNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaixaNome.Location = new System.Drawing.Point(257, 151);
            this.CaixaNome.Name = "CaixaNome";
            this.CaixaNome.Size = new System.Drawing.Size(298, 22);
            this.CaixaNome.TabIndex = 6;
            // 
            // CaixaSenha
            // 
            this.CaixaSenha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CaixaSenha.Location = new System.Drawing.Point(257, 235);
            this.CaixaSenha.Name = "CaixaSenha";
            this.CaixaSenha.Size = new System.Drawing.Size(298, 22);
            this.CaixaSenha.TabIndex = 7;
            this.CaixaSenha.UseSystemPasswordChar = true;
            // 
            // LabelNomePrograma
            // 
            this.LabelNomePrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelNomePrograma.AutoSize = true;
            this.LabelNomePrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNomePrograma.Location = new System.Drawing.Point(363, 9);
            this.LabelNomePrograma.Name = "LabelNomePrograma";
            this.LabelNomePrograma.Size = new System.Drawing.Size(86, 20);
            this.LabelNomePrograma.TabIndex = 8;
            this.LabelNomePrograma.Text = "AnaliticSA";
            this.LabelNomePrograma.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelLogin
            // 
            this.LabelLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelLogin.AutoSize = true;
            this.LabelLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelLogin.Location = new System.Drawing.Point(382, 80);
            this.LabelLogin.Name = "LabelLogin";
            this.LabelLogin.Size = new System.Drawing.Size(50, 20);
            this.LabelLogin.TabIndex = 9;
            this.LabelLogin.Text = "Login";
            this.LabelLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtSair
            // 
            this.BtSair.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtSair.Location = new System.Drawing.Point(186, 363);
            this.BtSair.Name = "BtSair";
            this.BtSair.Size = new System.Drawing.Size(143, 69);
            this.BtSair.TabIndex = 10;
            this.BtSair.Text = "Sair";
            this.BtSair.UseVisualStyleBackColor = true;
            this.BtSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 581);
            this.Controls.Add(this.BtSair);
            this.Controls.Add(this.LabelLogin);
            this.Controls.Add(this.LabelNomePrograma);
            this.Controls.Add(this.CaixaSenha);
            this.Controls.Add(this.CaixaNome);
            this.Controls.Add(this.LabelSenha);
            this.Controls.Add(this.LabelNome);
            this.Controls.Add(this.BtLogar);
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaLogin";
            this.Load += new System.EventHandler(this.TelaLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtLogar;
        private System.Windows.Forms.Label LabelNome;
        private System.Windows.Forms.Label LabelSenha;
        private System.Windows.Forms.TextBox CaixaNome;
        private System.Windows.Forms.TextBox CaixaSenha;
        private System.Windows.Forms.Label LabelNomePrograma;
        private System.Windows.Forms.Label LabelLogin;
        private System.Windows.Forms.Button BtSair;
    }
}
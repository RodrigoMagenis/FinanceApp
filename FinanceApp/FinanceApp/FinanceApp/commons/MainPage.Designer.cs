namespace FinanceApp.commons
{
    partial class MainPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnanalytics = new System.Windows.Forms.Button();
            this.mainPageBody = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel1.Controls.Add(this.btnanalytics);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1345, 53);
            this.panel1.TabIndex = 0;
            // 
            // btnanalytics
            // 
            this.btnanalytics.Location = new System.Drawing.Point(10, 10);
            this.btnanalytics.Name = "btnanalytics";
            this.btnanalytics.Size = new System.Drawing.Size(106, 32);
            this.btnanalytics.TabIndex = 1;
            this.btnanalytics.Text = "Estratificação";
            this.btnanalytics.UseVisualStyleBackColor = true;
            this.btnanalytics.Click += new System.EventHandler(this.btnanalytics_Click);
            // 
            // mainPageBody
            // 
            this.mainPageBody.AutoSize = true;
            this.mainPageBody.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.mainPageBody.Location = new System.Drawing.Point(2, 61);
            this.mainPageBody.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.mainPageBody.Name = "mainPageBody";
            this.mainPageBody.Size = new System.Drawing.Size(1024, 466);
            this.mainPageBody.TabIndex = 1;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.mainPageBody);
            this.Controls.Add(this.panel1);
            this.Name = "MainPage";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnanalytics;
        private System.Windows.Forms.Panel mainPageBody;
    }
}
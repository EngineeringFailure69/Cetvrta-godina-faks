namespace WcfClient
{
    partial class Chat
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
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.gbPrijava = new System.Windows.Forms.GroupBox();
            this.btnPrijava = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.lblTekst = new System.Windows.Forms.Label();
            this.lblKome = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.gbPrijem = new System.Windows.Forms.GroupBox();
            this.rtbPrijem = new System.Windows.Forms.RichTextBox();
            this.gbPrijava.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPrijem.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(6, 19);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 20);
            this.txtFrom.TabIndex = 0;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(6, 32);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 20);
            this.txtTo.TabIndex = 1;
            // 
            // gbPrijava
            // 
            this.gbPrijava.Controls.Add(this.btnPrijava);
            this.gbPrijava.Controls.Add(this.txtFrom);
            this.gbPrijava.Location = new System.Drawing.Point(12, 12);
            this.gbPrijava.Name = "gbPrijava";
            this.gbPrijava.Size = new System.Drawing.Size(194, 45);
            this.gbPrijava.TabIndex = 2;
            this.gbPrijava.TabStop = false;
            this.gbPrijava.Text = "Prijava na sistem";
            // 
            // btnPrijava
            // 
            this.btnPrijava.Location = new System.Drawing.Point(113, 17);
            this.btnPrijava.Name = "btnPrijava";
            this.btnPrijava.Size = new System.Drawing.Size(75, 23);
            this.btnPrijava.TabIndex = 1;
            this.btnPrijava.Text = "Prijava";
            this.btnPrijava.UseVisualStyleBackColor = true;
            this.btnPrijava.Click += new System.EventHandler(this.btnPrijava_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPosalji);
            this.groupBox1.Controls.Add(this.lblTekst);
            this.groupBox1.Controls.Add(this.lblKome);
            this.groupBox1.Controls.Add(this.txt);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 186);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slanje";
            // 
            // btnPosalji
            // 
            this.btnPosalji.Location = new System.Drawing.Point(113, 30);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(75, 23);
            this.btnPosalji.TabIndex = 1;
            this.btnPosalji.Text = "Posalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // lblTekst
            // 
            this.lblTekst.AutoSize = true;
            this.lblTekst.Location = new System.Drawing.Point(6, 55);
            this.lblTekst.Name = "lblTekst";
            this.lblTekst.Size = new System.Drawing.Size(34, 13);
            this.lblTekst.TabIndex = 0;
            this.lblTekst.Text = "Tekst";
            // 
            // lblKome
            // 
            this.lblKome.AutoSize = true;
            this.lblKome.Location = new System.Drawing.Point(6, 16);
            this.lblKome.Name = "lblKome";
            this.lblKome.Size = new System.Drawing.Size(34, 13);
            this.lblKome.TabIndex = 0;
            this.lblKome.Text = "Kome";
            // 
            // txt
            // 
            this.txt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt.Location = new System.Drawing.Point(6, 71);
            this.txt.Multiline = true;
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(182, 109);
            this.txt.TabIndex = 1;
            // 
            // gbPrijem
            // 
            this.gbPrijem.Controls.Add(this.rtbPrijem);
            this.gbPrijem.Location = new System.Drawing.Point(212, 12);
            this.gbPrijem.Name = "gbPrijem";
            this.gbPrijem.Size = new System.Drawing.Size(256, 237);
            this.gbPrijem.TabIndex = 4;
            this.gbPrijem.TabStop = false;
            this.gbPrijem.Text = "Prijem";
            // 
            // rtbPrijem
            // 
            this.rtbPrijem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrijem.Location = new System.Drawing.Point(3, 16);
            this.rtbPrijem.Name = "rtbPrijem";
            this.rtbPrijem.Size = new System.Drawing.Size(250, 218);
            this.rtbPrijem.TabIndex = 0;
            this.rtbPrijem.Text = "";
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 261);
            this.Controls.Add(this.gbPrijem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbPrijava);
            this.Name = "Chat";
            this.Text = "Form1";
            this.gbPrijava.ResumeLayout(false);
            this.gbPrijava.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPrijem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.GroupBox gbPrijava;
        private System.Windows.Forms.Button btnPrijava;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblKome;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.Label lblTekst;
        private System.Windows.Forms.TextBox txt;
        private System.Windows.Forms.GroupBox gbPrijem;
        private System.Windows.Forms.RichTextBox rtbPrijem;
    }
}


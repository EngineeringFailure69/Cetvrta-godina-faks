namespace CisternaKorisnik
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblRo = new System.Windows.Forms.Label();
            this.lblIspusti = new System.Windows.Forms.Label();
            this.tbxNaziv = new System.Windows.Forms.TextBox();
            this.tbxV = new System.Windows.Forms.TextBox();
            this.tbxRo = new System.Windows.Forms.TextBox();
            this.tbxKonzola = new System.Windows.Forms.TextBox();
            this.tbxIspustiV = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnIspusti = new System.Windows.Forms.Button();
            this.btnStanje = new System.Windows.Forms.Button();
            this.btnPromene = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblNaziv, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblRo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIspusti, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxNaziv, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxV, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxRo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxIspustiV, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnDodaj, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnIspusti, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnStanje, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPromene, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxKonzola, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 209);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNaziv.Location = new System.Drawing.Point(3, 0);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(124, 62);
            this.lblNaziv.TabIndex = 0;
            this.lblNaziv.Text = "Naziv";
            this.lblNaziv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblV.Location = new System.Drawing.Point(3, 62);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(124, 29);
            this.lblV.TabIndex = 1;
            this.lblV.Text = "V";
            this.lblV.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRo
            // 
            this.lblRo.AutoSize = true;
            this.lblRo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRo.Location = new System.Drawing.Point(3, 91);
            this.lblRo.Name = "lblRo";
            this.lblRo.Size = new System.Drawing.Size(124, 28);
            this.lblRo.TabIndex = 2;
            this.lblRo.Text = "Ro";
            this.lblRo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIspusti
            // 
            this.lblIspusti.AutoSize = true;
            this.lblIspusti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIspusti.Location = new System.Drawing.Point(3, 148);
            this.lblIspusti.Name = "lblIspusti";
            this.lblIspusti.Size = new System.Drawing.Size(124, 28);
            this.lblIspusti.TabIndex = 3;
            this.lblIspusti.Text = "Isputsti Zapreminu";
            this.lblIspusti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxNaziv
            // 
            this.tbxNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxNaziv.Location = new System.Drawing.Point(133, 3);
            this.tbxNaziv.Name = "tbxNaziv";
            this.tbxNaziv.Size = new System.Drawing.Size(100, 22);
            this.tbxNaziv.TabIndex = 4;
            // 
            // tbxV
            // 
            this.tbxV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxV.Location = new System.Drawing.Point(133, 65);
            this.tbxV.Name = "tbxV";
            this.tbxV.Size = new System.Drawing.Size(100, 22);
            this.tbxV.TabIndex = 5;
            // 
            // tbxRo
            // 
            this.tbxRo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxRo.Location = new System.Drawing.Point(133, 94);
            this.tbxRo.Name = "tbxRo";
            this.tbxRo.Size = new System.Drawing.Size(100, 22);
            this.tbxRo.TabIndex = 6;
            // 
            // tbxKonzola
            // 
            this.tbxKonzola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxKonzola.Location = new System.Drawing.Point(239, 94);
            this.tbxKonzola.Multiline = true;
            this.tbxKonzola.Name = "tbxKonzola";
            this.tableLayoutPanel1.SetRowSpan(this.tbxKonzola, 4);
            this.tbxKonzola.Size = new System.Drawing.Size(558, 112);
            this.tbxKonzola.TabIndex = 7;
            // 
            // tbxIspustiV
            // 
            this.tbxIspustiV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxIspustiV.Location = new System.Drawing.Point(133, 151);
            this.tbxIspustiV.Name = "tbxIspustiV";
            this.tbxIspustiV.Size = new System.Drawing.Size(100, 22);
            this.tbxIspustiV.TabIndex = 8;
            // 
            // btnDodaj
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnDodaj, 2);
            this.btnDodaj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDodaj.Location = new System.Drawing.Point(3, 122);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(230, 23);
            this.btnDodaj.TabIndex = 9;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnIspusti
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnIspusti, 2);
            this.btnIspusti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIspusti.Location = new System.Drawing.Point(3, 179);
            this.btnIspusti.Name = "btnIspusti";
            this.btnIspusti.Size = new System.Drawing.Size(230, 27);
            this.btnIspusti.TabIndex = 10;
            this.btnIspusti.Text = "Ispusti";
            this.btnIspusti.UseVisualStyleBackColor = true;
            this.btnIspusti.Click += new System.EventHandler(this.btnIspusti_Click);
            // 
            // btnStanje
            // 
            this.btnStanje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStanje.Location = new System.Drawing.Point(239, 3);
            this.btnStanje.Name = "btnStanje";
            this.btnStanje.Size = new System.Drawing.Size(558, 56);
            this.btnStanje.TabIndex = 11;
            this.btnStanje.Text = "Prikazi Stanje";
            this.btnStanje.UseVisualStyleBackColor = true;
            this.btnStanje.Click += new System.EventHandler(this.btnStanje_Click);
            // 
            // btnPromene
            // 
            this.btnPromene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPromene.Location = new System.Drawing.Point(239, 65);
            this.btnPromene.Name = "btnPromene";
            this.btnPromene.Size = new System.Drawing.Size(558, 23);
            this.btnPromene.TabIndex = 12;
            this.btnPromene.Text = "Prikazi Promene";
            this.btnPromene.UseVisualStyleBackColor = true;
            this.btnPromene.Click += new System.EventHandler(this.btnPromene_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 209);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblRo;
        private System.Windows.Forms.Label lblIspusti;
        private System.Windows.Forms.TextBox tbxNaziv;
        private System.Windows.Forms.TextBox tbxV;
        private System.Windows.Forms.TextBox tbxRo;
        private System.Windows.Forms.TextBox tbxKonzola;
        private System.Windows.Forms.TextBox tbxIspustiV;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnIspusti;
        private System.Windows.Forms.Button btnStanje;
        private System.Windows.Forms.Button btnPromene;
    }
}


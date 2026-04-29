namespace BankaKorisnik
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
            this.lblIznos = new System.Windows.Forms.Label();
            this.lblNaziv = new System.Windows.Forms.Label();
            this.lblKurs = new System.Windows.Forms.Label();
            this.lblIsplata = new System.Windows.Forms.Label();
            this.lblPromeniKurs = new System.Windows.Forms.Label();
            this.btnUplati = new System.Windows.Forms.Button();
            this.btnIsplati = new System.Windows.Forms.Button();
            this.btnPromeniKurs = new System.Windows.Forms.Button();
            this.btnPrikaziPromene = new System.Windows.Forms.Button();
            this.tbxIznos = new System.Windows.Forms.TextBox();
            this.tbxNaziv = new System.Windows.Forms.TextBox();
            this.tbxKurs = new System.Windows.Forms.TextBox();
            this.tbxIsplata = new System.Windows.Forms.TextBox();
            this.tbxPromeniKurs = new System.Windows.Forms.TextBox();
            this.tbxPromene = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblIznos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNaziv, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblKurs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIsplata, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPromeniKurs, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnUplati, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnIsplati, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnPromeniKurs, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnPrikaziPromene, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxIznos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxNaziv, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxKurs, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxIsplata, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxPromeniKurs, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbxPromene, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIznos.Location = new System.Drawing.Point(3, 0);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(49, 29);
            this.lblIznos.TabIndex = 0;
            this.lblIznos.Text = "Iznos";
            this.lblIznos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNaziv
            // 
            this.lblNaziv.AutoSize = true;
            this.lblNaziv.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lblNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNaziv.Location = new System.Drawing.Point(3, 29);
            this.lblNaziv.Name = "lblNaziv";
            this.lblNaziv.Size = new System.Drawing.Size(49, 28);
            this.lblNaziv.TabIndex = 1;
            this.lblNaziv.Text = "Naziv";
            this.lblNaziv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKurs
            // 
            this.lblKurs.AutoSize = true;
            this.lblKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblKurs.Location = new System.Drawing.Point(3, 57);
            this.lblKurs.Name = "lblKurs";
            this.lblKurs.Size = new System.Drawing.Size(49, 28);
            this.lblKurs.TabIndex = 2;
            this.lblKurs.Text = "Kurs";
            this.lblKurs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIsplata
            // 
            this.lblIsplata.AutoSize = true;
            this.lblIsplata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIsplata.Location = new System.Drawing.Point(3, 114);
            this.lblIsplata.Name = "lblIsplata";
            this.lblIsplata.Size = new System.Drawing.Size(49, 28);
            this.lblIsplata.TabIndex = 3;
            this.lblIsplata.Text = "Isplata";
            this.lblIsplata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPromeniKurs
            // 
            this.lblPromeniKurs.AutoSize = true;
            this.lblPromeniKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPromeniKurs.Location = new System.Drawing.Point(3, 171);
            this.lblPromeniKurs.Name = "lblPromeniKurs";
            this.lblPromeniKurs.Size = new System.Drawing.Size(49, 28);
            this.lblPromeniKurs.TabIndex = 4;
            this.lblPromeniKurs.Text = "Kurs";
            this.lblPromeniKurs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUplati
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnUplati, 2);
            this.btnUplati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUplati.Location = new System.Drawing.Point(3, 88);
            this.btnUplati.Name = "btnUplati";
            this.btnUplati.Size = new System.Drawing.Size(155, 23);
            this.btnUplati.TabIndex = 5;
            this.btnUplati.Text = "Uplati";
            this.btnUplati.UseVisualStyleBackColor = true;
            this.btnUplati.Click += new System.EventHandler(this.btnUplati_Click);
            // 
            // btnIsplati
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnIsplati, 2);
            this.btnIsplati.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIsplati.Location = new System.Drawing.Point(3, 145);
            this.btnIsplati.Name = "btnIsplati";
            this.btnIsplati.Size = new System.Drawing.Size(155, 23);
            this.btnIsplati.TabIndex = 6;
            this.btnIsplati.Text = "Isplati";
            this.btnIsplati.UseVisualStyleBackColor = true;
            this.btnIsplati.Click += new System.EventHandler(this.btnIsplati_Click);
            // 
            // btnPromeniKurs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnPromeniKurs, 2);
            this.btnPromeniKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPromeniKurs.Location = new System.Drawing.Point(3, 202);
            this.btnPromeniKurs.Name = "btnPromeniKurs";
            this.btnPromeniKurs.Size = new System.Drawing.Size(155, 185);
            this.btnPromeniKurs.TabIndex = 7;
            this.btnPromeniKurs.Text = "Promeni";
            this.btnPromeniKurs.UseVisualStyleBackColor = true;
            this.btnPromeniKurs.Click += new System.EventHandler(this.btnPromeniKurs_Click);
            // 
            // btnPrikaziPromene
            // 
            this.btnPrikaziPromene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPrikaziPromene.Location = new System.Drawing.Point(164, 3);
            this.btnPrikaziPromene.Name = "btnPrikaziPromene";
            this.btnPrikaziPromene.Size = new System.Drawing.Size(633, 23);
            this.btnPrikaziPromene.TabIndex = 8;
            this.btnPrikaziPromene.Text = "Prikazi Promene";
            this.btnPrikaziPromene.UseVisualStyleBackColor = true;
            this.btnPrikaziPromene.Click += new System.EventHandler(this.btnPrikaziPromene_Click);
            // 
            // tbxIznos
            // 
            this.tbxIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxIznos.Location = new System.Drawing.Point(58, 3);
            this.tbxIznos.Name = "tbxIznos";
            this.tbxIznos.Size = new System.Drawing.Size(100, 22);
            this.tbxIznos.TabIndex = 9;
            // 
            // tbxNaziv
            // 
            this.tbxNaziv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxNaziv.Location = new System.Drawing.Point(58, 32);
            this.tbxNaziv.Name = "tbxNaziv";
            this.tbxNaziv.Size = new System.Drawing.Size(100, 22);
            this.tbxNaziv.TabIndex = 10;
            // 
            // tbxKurs
            // 
            this.tbxKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxKurs.Location = new System.Drawing.Point(58, 60);
            this.tbxKurs.Name = "tbxKurs";
            this.tbxKurs.Size = new System.Drawing.Size(100, 22);
            this.tbxKurs.TabIndex = 11;
            // 
            // tbxIsplata
            // 
            this.tbxIsplata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxIsplata.Location = new System.Drawing.Point(58, 117);
            this.tbxIsplata.Name = "tbxIsplata";
            this.tbxIsplata.Size = new System.Drawing.Size(100, 22);
            this.tbxIsplata.TabIndex = 12;
            // 
            // tbxPromeniKurs
            // 
            this.tbxPromeniKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPromeniKurs.Location = new System.Drawing.Point(58, 174);
            this.tbxPromeniKurs.Name = "tbxPromeniKurs";
            this.tbxPromeniKurs.Size = new System.Drawing.Size(100, 22);
            this.tbxPromeniKurs.TabIndex = 13;
            // 
            // tbxPromene
            // 
            this.tbxPromene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPromene.Location = new System.Drawing.Point(164, 32);
            this.tbxPromene.Multiline = true;
            this.tbxPromene.Name = "tbxPromene";
            this.tableLayoutPanel1.SetRowSpan(this.tbxPromene, 7);
            this.tbxPromene.Size = new System.Drawing.Size(633, 355);
            this.tbxPromene.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 390);
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
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.Label lblNaziv;
        private System.Windows.Forms.Label lblKurs;
        private System.Windows.Forms.Label lblIsplata;
        private System.Windows.Forms.Label lblPromeniKurs;
        private System.Windows.Forms.Button btnUplati;
        private System.Windows.Forms.Button btnIsplati;
        private System.Windows.Forms.Button btnPromeniKurs;
        private System.Windows.Forms.Button btnPrikaziPromene;
        private System.Windows.Forms.TextBox tbxIznos;
        private System.Windows.Forms.TextBox tbxNaziv;
        private System.Windows.Forms.TextBox tbxKurs;
        private System.Windows.Forms.TextBox tbxIsplata;
        private System.Windows.Forms.TextBox tbxPromeniKurs;
        private System.Windows.Forms.TextBox tbxPromene;
    }
}


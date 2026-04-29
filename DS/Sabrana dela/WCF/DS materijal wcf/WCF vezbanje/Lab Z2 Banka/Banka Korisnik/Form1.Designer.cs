namespace Banka_Korisnik
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
            this.lblUplataIznos = new System.Windows.Forms.Label();
            this.lblUplataValuta = new System.Windows.Forms.Label();
            this.lblUplataKoef = new System.Windows.Forms.Label();
            this.lblIsplataIznos = new System.Windows.Forms.Label();
            this.lblEurKurs = new System.Windows.Forms.Label();
            this.tbxUplataIznos = new System.Windows.Forms.TextBox();
            this.tbxUplataValuta = new System.Windows.Forms.TextBox();
            this.tbxUplataKurs = new System.Windows.Forms.TextBox();
            this.tbxIsplataIznos = new System.Windows.Forms.TextBox();
            this.tbxEurKurs = new System.Windows.Forms.TextBox();
            this.tbxPromene = new System.Windows.Forms.TextBox();
            this.btnUplata = new System.Windows.Forms.Button();
            this.btnIsplata = new System.Windows.Forms.Button();
            this.btnEurKurs = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.lblUplataIznos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUplataValuta, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUplataKoef, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIsplataIznos, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblEurKurs, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbxUplataIznos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxUplataValuta, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxUplataKurs, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbxIsplataIznos, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxEurKurs, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbxPromene, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUplata, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnIsplata, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnEurKurs, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnPromene, 2, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(589, 233);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblUplataIznos
            // 
            this.lblUplataIznos.AutoSize = true;
            this.lblUplataIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUplataIznos.Location = new System.Drawing.Point(3, 0);
            this.lblUplataIznos.Name = "lblUplataIznos";
            this.lblUplataIznos.Size = new System.Drawing.Size(48, 29);
            this.lblUplataIznos.TabIndex = 0;
            this.lblUplataIznos.Text = "Iznos";
            this.lblUplataIznos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUplataValuta
            // 
            this.lblUplataValuta.AutoSize = true;
            this.lblUplataValuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUplataValuta.Location = new System.Drawing.Point(3, 29);
            this.lblUplataValuta.Name = "lblUplataValuta";
            this.lblUplataValuta.Size = new System.Drawing.Size(48, 28);
            this.lblUplataValuta.TabIndex = 1;
            this.lblUplataValuta.Text = "Valuta";
            this.lblUplataValuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUplataKoef
            // 
            this.lblUplataKoef.AutoSize = true;
            this.lblUplataKoef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUplataKoef.Location = new System.Drawing.Point(3, 57);
            this.lblUplataKoef.Name = "lblUplataKoef";
            this.lblUplataKoef.Size = new System.Drawing.Size(48, 28);
            this.lblUplataKoef.TabIndex = 2;
            this.lblUplataKoef.Text = "Kurs";
            this.lblUplataKoef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIsplataIznos
            // 
            this.lblIsplataIznos.AutoSize = true;
            this.lblIsplataIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIsplataIznos.Location = new System.Drawing.Point(3, 114);
            this.lblIsplataIznos.Name = "lblIsplataIznos";
            this.lblIsplataIznos.Size = new System.Drawing.Size(48, 28);
            this.lblIsplataIznos.TabIndex = 3;
            this.lblIsplataIznos.Text = "Iznos";
            this.lblIsplataIznos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEurKurs
            // 
            this.lblEurKurs.AutoSize = true;
            this.lblEurKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEurKurs.Location = new System.Drawing.Point(3, 171);
            this.lblEurKurs.Name = "lblEurKurs";
            this.lblEurKurs.Size = new System.Drawing.Size(48, 28);
            this.lblEurKurs.TabIndex = 4;
            this.lblEurKurs.Text = "Kurs";
            this.lblEurKurs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxUplataIznos
            // 
            this.tbxUplataIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxUplataIznos.Location = new System.Drawing.Point(57, 3);
            this.tbxUplataIznos.Name = "tbxUplataIznos";
            this.tbxUplataIznos.Size = new System.Drawing.Size(100, 22);
            this.tbxUplataIznos.TabIndex = 5;
            // 
            // tbxUplataValuta
            // 
            this.tbxUplataValuta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxUplataValuta.Location = new System.Drawing.Point(57, 32);
            this.tbxUplataValuta.Name = "tbxUplataValuta";
            this.tbxUplataValuta.Size = new System.Drawing.Size(100, 22);
            this.tbxUplataValuta.TabIndex = 6;
            // 
            // tbxUplataKurs
            // 
            this.tbxUplataKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxUplataKurs.Location = new System.Drawing.Point(57, 60);
            this.tbxUplataKurs.Name = "tbxUplataKurs";
            this.tbxUplataKurs.Size = new System.Drawing.Size(100, 22);
            this.tbxUplataKurs.TabIndex = 7;
            // 
            // tbxIsplataIznos
            // 
            this.tbxIsplataIznos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxIsplataIznos.Location = new System.Drawing.Point(57, 117);
            this.tbxIsplataIznos.Name = "tbxIsplataIznos";
            this.tbxIsplataIznos.Size = new System.Drawing.Size(100, 22);
            this.tbxIsplataIznos.TabIndex = 8;
            // 
            // tbxEurKurs
            // 
            this.tbxEurKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxEurKurs.Location = new System.Drawing.Point(57, 174);
            this.tbxEurKurs.Name = "tbxEurKurs";
            this.tbxEurKurs.Size = new System.Drawing.Size(100, 22);
            this.tbxEurKurs.TabIndex = 9;
            // 
            // tbxPromene
            // 
            this.tbxPromene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbxPromene.Location = new System.Drawing.Point(163, 32);
            this.tbxPromene.Multiline = true;
            this.tbxPromene.Name = "tbxPromene";
            this.tableLayoutPanel1.SetRowSpan(this.tbxPromene, 7);
            this.tbxPromene.Size = new System.Drawing.Size(423, 198);
            this.tbxPromene.TabIndex = 10;
            // 
            // btnUplata
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnUplata, 2);
            this.btnUplata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUplata.Location = new System.Drawing.Point(3, 88);
            this.btnUplata.Name = "btnUplata";
            this.btnUplata.Size = new System.Drawing.Size(154, 23);
            this.btnUplata.TabIndex = 11;
            this.btnUplata.Text = "Uplati";
            this.btnUplata.UseVisualStyleBackColor = true;
            this.btnUplata.Click += new System.EventHandler(this.btnUplata_Click);
            // 
            // btnIsplata
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnIsplata, 2);
            this.btnIsplata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIsplata.Location = new System.Drawing.Point(3, 145);
            this.btnIsplata.Name = "btnIsplata";
            this.btnIsplata.Size = new System.Drawing.Size(154, 23);
            this.btnIsplata.TabIndex = 12;
            this.btnIsplata.Text = "Isplata";
            this.btnIsplata.UseVisualStyleBackColor = true;
            this.btnIsplata.Click += new System.EventHandler(this.btnIsplata_Click);
            // 
            // btnEurKurs
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnEurKurs, 2);
            this.btnEurKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEurKurs.Location = new System.Drawing.Point(3, 202);
            this.btnEurKurs.Name = "btnEurKurs";
            this.btnEurKurs.Size = new System.Drawing.Size(154, 28);
            this.btnEurKurs.TabIndex = 13;
            this.btnEurKurs.Text = "Podesi Kurs";
            this.btnEurKurs.UseVisualStyleBackColor = true;
            this.btnEurKurs.Click += new System.EventHandler(this.btnEurKurs_Click);
            // 
            // btnPromene
            // 
            this.btnPromene.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPromene.Location = new System.Drawing.Point(163, 3);
            this.btnPromene.Name = "btnPromene";
            this.btnPromene.Size = new System.Drawing.Size(423, 23);
            this.btnPromene.TabIndex = 14;
            this.btnPromene.Text = "Prikazi Promene";
            this.btnPromene.UseVisualStyleBackColor = true;
            this.btnPromene.Click += new System.EventHandler(this.btnPromene_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 233);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUplataIznos;
        private System.Windows.Forms.Label lblUplataValuta;
        private System.Windows.Forms.Label lblUplataKoef;
        private System.Windows.Forms.Label lblIsplataIznos;
        private System.Windows.Forms.Label lblEurKurs;
        private System.Windows.Forms.TextBox tbxUplataIznos;
        private System.Windows.Forms.TextBox tbxUplataValuta;
        private System.Windows.Forms.TextBox tbxUplataKurs;
        private System.Windows.Forms.TextBox tbxIsplataIznos;
        private System.Windows.Forms.TextBox tbxEurKurs;
        private System.Windows.Forms.TextBox tbxPromene;
        private System.Windows.Forms.Button btnUplata;
        private System.Windows.Forms.Button btnIsplata;
        private System.Windows.Forms.Button btnEurKurs;
        private System.Windows.Forms.Button btnPromene;
    }
}


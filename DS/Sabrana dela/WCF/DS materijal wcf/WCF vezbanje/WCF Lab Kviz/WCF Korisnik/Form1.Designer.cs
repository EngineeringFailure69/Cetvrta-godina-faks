namespace WCF_Korisnik
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
            this.btnInicijalizuj = new System.Windows.Forms.Button();
            this.gbxOdgovori = new System.Windows.Forms.GroupBox();
            this.rbtnA = new System.Windows.Forms.RadioButton();
            this.rbtnB = new System.Windows.Forms.RadioButton();
            this.rbtnC = new System.Windows.Forms.RadioButton();
            this.btnOdgovori = new System.Windows.Forms.Button();
            this.btnBrojPoena = new System.Windows.Forms.Button();
            this.tbxBrojPoena = new System.Windows.Forms.TextBox();
            this.tbxPitanje = new System.Windows.Forms.TextBox();
            this.gbxOdgovori.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInicijalizuj
            // 
            this.btnInicijalizuj.Location = new System.Drawing.Point(23, 12);
            this.btnInicijalizuj.Name = "btnInicijalizuj";
            this.btnInicijalizuj.Size = new System.Drawing.Size(110, 43);
            this.btnInicijalizuj.TabIndex = 0;
            this.btnInicijalizuj.Text = "Test";
            this.btnInicijalizuj.UseVisualStyleBackColor = true;
            this.btnInicijalizuj.Click += new System.EventHandler(this.btnInicijalizuj_Click);
            // 
            // gbxOdgovori
            // 
            this.gbxOdgovori.Controls.Add(this.btnOdgovori);
            this.gbxOdgovori.Controls.Add(this.rbtnC);
            this.gbxOdgovori.Controls.Add(this.rbtnB);
            this.gbxOdgovori.Controls.Add(this.rbtnA);
            this.gbxOdgovori.Location = new System.Drawing.Point(23, 78);
            this.gbxOdgovori.Name = "gbxOdgovori";
            this.gbxOdgovori.Size = new System.Drawing.Size(212, 166);
            this.gbxOdgovori.TabIndex = 1;
            this.gbxOdgovori.TabStop = false;
            this.gbxOdgovori.Text = "Odgovori";
            // 
            // rbtnA
            // 
            this.rbtnA.AutoSize = true;
            this.rbtnA.Location = new System.Drawing.Point(6, 21);
            this.rbtnA.Name = "rbtnA";
            this.rbtnA.Size = new System.Drawing.Size(38, 21);
            this.rbtnA.TabIndex = 0;
            this.rbtnA.TabStop = true;
            this.rbtnA.Text = "A";
            this.rbtnA.UseVisualStyleBackColor = true;
            // 
            // rbtnB
            // 
            this.rbtnB.AutoSize = true;
            this.rbtnB.Location = new System.Drawing.Point(6, 48);
            this.rbtnB.Name = "rbtnB";
            this.rbtnB.Size = new System.Drawing.Size(38, 21);
            this.rbtnB.TabIndex = 1;
            this.rbtnB.TabStop = true;
            this.rbtnB.Text = "B";
            this.rbtnB.UseVisualStyleBackColor = true;
            // 
            // rbtnC
            // 
            this.rbtnC.AutoSize = true;
            this.rbtnC.Location = new System.Drawing.Point(6, 75);
            this.rbtnC.Name = "rbtnC";
            this.rbtnC.Size = new System.Drawing.Size(38, 21);
            this.rbtnC.TabIndex = 2;
            this.rbtnC.TabStop = true;
            this.rbtnC.Text = "C";
            this.rbtnC.UseVisualStyleBackColor = true;
            // 
            // btnOdgovori
            // 
            this.btnOdgovori.Location = new System.Drawing.Point(102, 33);
            this.btnOdgovori.Name = "btnOdgovori";
            this.btnOdgovori.Size = new System.Drawing.Size(104, 51);
            this.btnOdgovori.TabIndex = 2;
            this.btnOdgovori.Text = "Odgovori";
            this.btnOdgovori.UseVisualStyleBackColor = true;
            this.btnOdgovori.Click += new System.EventHandler(this.btnOdgovori_Click);
            // 
            // btnBrojPoena
            // 
            this.btnBrojPoena.Location = new System.Drawing.Point(29, 281);
            this.btnBrojPoena.Name = "btnBrojPoena";
            this.btnBrojPoena.Size = new System.Drawing.Size(200, 23);
            this.btnBrojPoena.TabIndex = 2;
            this.btnBrojPoena.Text = "Broj Poena";
            this.btnBrojPoena.UseVisualStyleBackColor = true;
            this.btnBrojPoena.Click += new System.EventHandler(this.btnBrojPoena_Click);
            // 
            // tbxBrojPoena
            // 
            this.tbxBrojPoena.Location = new System.Drawing.Point(29, 321);
            this.tbxBrojPoena.Name = "tbxBrojPoena";
            this.tbxBrojPoena.Size = new System.Drawing.Size(200, 22);
            this.tbxBrojPoena.TabIndex = 3;
            // 
            // tbxPitanje
            // 
            this.tbxPitanje.Location = new System.Drawing.Point(303, 78);
            this.tbxPitanje.Multiline = true;
            this.tbxPitanje.Name = "tbxPitanje";
            this.tbxPitanje.Size = new System.Drawing.Size(404, 166);
            this.tbxPitanje.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxPitanje);
            this.Controls.Add(this.tbxBrojPoena);
            this.Controls.Add(this.btnBrojPoena);
            this.Controls.Add(this.gbxOdgovori);
            this.Controls.Add(this.btnInicijalizuj);
            this.Name = "Form1";
            this.Text = "Form1";
            this.gbxOdgovori.ResumeLayout(false);
            this.gbxOdgovori.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInicijalizuj;
        private System.Windows.Forms.GroupBox gbxOdgovori;
        private System.Windows.Forms.Button btnOdgovori;
        private System.Windows.Forms.RadioButton rbtnC;
        private System.Windows.Forms.RadioButton rbtnB;
        private System.Windows.Forms.RadioButton rbtnA;
        private System.Windows.Forms.Button btnBrojPoena;
        private System.Windows.Forms.TextBox tbxBrojPoena;
        private System.Windows.Forms.TextBox tbxPitanje;
    }
}


using CisternaKorisnik.ServiceReferenceCisterna;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CisternaKorisnik
{
    public partial class Form1 : Form
    {
        CisternaClient proxy;

        public Form1()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click_1(object sender, EventArgs e)
        {
            Materijal nov = new Materijal
            {
                Naziv = tbxNaziv.Text,
                Ro = float.Parse(tbxGustina.Text),
                V = float.Parse(tbxZapremina.Text)
            };
            proxy.Dodaj(nov);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new CisternaClient();
        }

        private void btnIsprazni_Click(object sender, EventArgs e)
        {
            proxy.Ispusti(float.Parse(tbxIspazniZapreminu.Text));
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            Materijal stanje=proxy.Stanje();
            tbxPrikaziGustinu.Text = stanje.Ro.ToString("0.00");
            tbxPrikaziZapreminu.Text = stanje.V.ToString("0.00");
        }

        private void btnPromene_Click(object sender, EventArgs e)
        {
            var promene = proxy.SvePromene();
            txtPromene.Text = string.Join(Environment.NewLine, promene);
        }
    }
}

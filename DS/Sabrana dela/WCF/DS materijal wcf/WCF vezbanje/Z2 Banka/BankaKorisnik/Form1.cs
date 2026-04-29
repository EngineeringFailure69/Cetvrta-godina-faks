using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankaKorisnik
{
    public partial class Form1 : Form
    {
        private ServiceReferenceRacun.RacunClient proxy;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new ServiceReferenceRacun.RacunClient();
        }
        private void btnUplati_Click(object sender, EventArgs e)
        {
            decimal iznos = decimal.Parse(tbxIznos.Text);
            string naziv = tbxKurs.Text;
            decimal koef = decimal.Parse(tbxKurs.Text);
            proxy.Uplata(iznos, naziv, koef);
        }

        private void btnIsplati_Click(object sender, EventArgs e)
        {
            decimal isplata = decimal.Parse(tbxIsplata.Text);
            proxy.Isplata(isplata);
        }

        private void btnPromeniKurs_Click(object sender, EventArgs e)
        {
            decimal kurs = decimal.Parse(tbxPromeniKurs.Text);
            proxy.SetKurs(kurs);
        }

        private void btnPrikaziPromene_Click(object sender, EventArgs e)
        {
            List<string> promene = proxy.GetPromene();
            tbxPromene.Text = string.Join(Environment.NewLine, promene);
        }
    }
}

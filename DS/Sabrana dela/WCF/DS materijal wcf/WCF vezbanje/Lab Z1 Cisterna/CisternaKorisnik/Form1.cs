using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CisternaKorisnik.ServiceReferenceCisterna;
namespace CisternaKorisnik
{
    public partial class Form1 : Form
    {
        CisternaClient proxy;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            proxy.DodajMateriju(tbxNaziv.Text, float.Parse(tbxV.Text), float.Parse(tbxRo.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            proxy = new CisternaClient();
        }

        private void btnIspusti_Click(object sender, EventArgs e)
        {
            proxy.Ispusti(float.Parse(tbxIspustiV.Text));
        }

        private void btnStanje_Click(object sender, EventArgs e)
        {
            Stanje s = proxy.GetStanje();
            tbxKonzola.Text = $"Stanje [ V = {s.V} Ro = {s.Ro} ]";
        }

        private void btnPromene_Click(object sender, EventArgs e)
        {
            List<string> s = proxy.GetPromene();
            tbxKonzola.Text = String.Join(Environment.NewLine, s);
        }
    }
}

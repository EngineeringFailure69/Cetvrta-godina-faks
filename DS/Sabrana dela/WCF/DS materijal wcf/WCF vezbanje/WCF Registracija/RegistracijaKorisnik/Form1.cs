using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistracijaKorisnik.ServiceReferenceRegistracija;
namespace RegistracijaKorisnik
{
    public partial class Form1 : Form
    {
        RegistracijaClient proxy;

        public Form1()
        {
            InitializeComponent();
            proxy = new RegistracijaClient();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Vozac vozac = new Vozac
            {
                Ime = tbxIme.Text,
                Prezime = tbxPrezime.Text,
                JMBG = tbxJMBG.Text
            };
            Vozilo vozilo = new Vozilo
            {
                Marka = tbxMarka.Text,
                Model = tbxModel.Text,
                Tip = tbxBoja.Text
            };

            proxy.Add(vozilo, vozac);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Vozac> vozacs = proxy.VratiVozace(tbxVratiModel.Text);
            string prikaz = "";
            foreach (Vozac v in vozacs)
            {
                prikaz += v.Ime + " " + v.Prezime + " " + v.JMBG + Environment.NewLine;
            }
            tbxPrikaz.Text = prikaz;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Vozilo> vozilos = proxy.VratiVozila(new Vozac { JMBG = tbxVratiZaVozaca.Text });
            string prikaz = "";
            foreach (Vozilo v in vozilos)
            {
                prikaz += v.Marka + " " + v.Model + " " + v.Tip + Environment.NewLine;
            }
            tbxPrikaz.Text = prikaz;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<Vozac, List<Vozilo>> s = proxy.VratiSve();
            string prikaz = "";
            foreach (Vozac v in s.Keys)
            {
                prikaz += v.Ime + " " + v.Prezime + " " + v.JMBG + Environment.NewLine;
                List<Vozilo> vozilos = s[v];
                foreach (Vozilo j in vozilos)
                {
                    prikaz += j.Marka + " " + j.Model + " " + j.Tip + Environment.NewLine;
                }
            }
            tbxPrikaz.Text = prikaz;
        }
    }
}

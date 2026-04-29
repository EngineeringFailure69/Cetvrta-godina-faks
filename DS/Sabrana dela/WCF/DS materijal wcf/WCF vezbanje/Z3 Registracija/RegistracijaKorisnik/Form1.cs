using RegistracijaKorisnik.ServiceReferenceRegistracija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistracijaKorisnik
{
    public partial class Form1 : Form
    {
        private RegistracijaClient proxy=new RegistracijaClient();


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDodajRegistraciju_Click(object sender, EventArgs e)
        {
            Vlasnik vlasnik = new Vlasnik
            {
                Ime = tbxImeVlasnika.Text,
                Prezime = tbxPrezimeVlasnika.Text,
                JMBG = tbxJmbgVlasnika.Text
            };
            Vozilo vozilo = new Vozilo
            {
                Vlasnik=vlasnik,
                Model = tbxModel.Text,
                Marka = tbxMarka.Text,
                Boja = tbxBoja.Text
            };
            proxy.DodajRegistraciju(vlasnik, vozilo);
        }

        private void btnVratiVOzilaIVlasnike_Click(object sender, EventArgs e)
        {
            List<Vozilo> vozila = proxy.vratiVozila();
            String zaPrikaz = "";
            foreach(Vozilo v in vozila)
            {
                zaPrikaz += $"[ Vozilo: {v.Marka} , {v.Model} , {v.Boja} Vozac: {v.Vlasnik.Ime} , {v.Vlasnik.Prezime} , {v.Vlasnik.JMBG} ]" + Environment.NewLine;
            }
            tbxPrikaz.Text = zaPrikaz;
        }

        private void btnPosedujeModel_Click(object sender, EventArgs e)
        {
            List<Vlasnik> vlasnici = proxy.PosedujeModel(tbxModel.Text);
            String zaPrikaz = "Model : "+tbxModel.Text;
            foreach (Vlasnik v in vlasnici)
            {
                zaPrikaz += $"[ Vozac: {v.Ime} , {v.Prezime} , {v.JMBG} ]";
            }
            tbxPrikaz.Text = zaPrikaz;
        }

        private void btnVratiVozilaVlasnika_Click(object sender, EventArgs e)
        {
            List<Vozilo> vozila = proxy.VratiVozilaVlasnika(new Vlasnik { JMBG = tbxJmbgVlasnika.Text });
            String zaPrikaz = "";
            foreach (Vozilo v in vozila)
            {
                zaPrikaz += $"[ Vozilo: {v.Marka} , {v.Model} , {v.Boja} Vozac: {v.Vlasnik.Ime} , {v.Vlasnik.Prezime} , {v.Vlasnik.JMBG} ]"+Environment.NewLine;
            }
            tbxPrikaz.Text = zaPrikaz;
        }
    }
}

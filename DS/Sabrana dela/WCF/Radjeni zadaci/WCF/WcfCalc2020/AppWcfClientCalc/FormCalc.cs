using AppWcfClientCalc.CalcServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWcfClientCalc
{
    public partial class FormCalc : Form
    {
        bool clear = true;
        CalcClient proxy;
        public FormCalc()
        {
            InitializeComponent();

            CalcCallbackImplementation implementation = new CalcCallbackImplementation(txtRezultat, txtIzraz);

            InstanceContext instance = new InstanceContext(implementation);

            proxy = new CalcClient(instance);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;

            if (b == null)
                return;
            if (clear)
                txtRezultat.Text = string.Empty;

            txtRezultat.Text += b.Text;
            clear = false;
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            clear = true;
            proxy.Obrisi();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            clear = true;
            double d;
            if (double.TryParse(txtRezultat.Text, out d))
                proxy.Dodaj(d);
            else
                txtIzraz.Text = "Nije broj";
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {

            clear = true;
            double d;
            if (double.TryParse(txtRezultat.Text, out d))
                proxy.Oduzmi(d);
            else
                txtIzraz.Text = "Nije broj";
        }

        private void btnPuta_Click(object sender, EventArgs e)
        {

            clear = true;
            double d;
            if (double.TryParse(txtRezultat.Text, out d))
                proxy.Pomnozi(d);
            else
                txtIzraz.Text = "Nije broj";
        }

        private void btnPodeli_Click(object sender, EventArgs e)
        {

            clear = true;
            double d;
            if (double.TryParse(txtRezultat.Text, out d))
                proxy.Podeli(d);
            else
                txtIzraz.Text = "Nije broj";
        }
    }
}

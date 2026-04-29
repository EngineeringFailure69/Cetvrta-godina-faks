using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCF_Korisnik.ServiceReferenceKviz;
namespace WCF_Korisnik
{
    public partial class Form1 : Form
    {
        KvizClient proxy;
        int id = 1;
        public Form1()
        {
            InitializeComponent();
            proxy = new KvizClient();

        }

        private void btnInicijalizuj_Click(object sender, EventArgs e)
        {
            proxy.Inicijalizuj(id);
            int f = proxy.VratiBrojPoena(id);
            
            Pitanje p=proxy.VratiPitanje(id);
        
            prikaziPitanje(p);
        }

        private void prikaziPitanje(Pitanje p)
        {
            string ret = "";
            ret += p.PostavkaPitanja + Environment.NewLine;
            ret += $"A) {p.A}"+Environment.NewLine;
            ret += $"B) {p.B}"+Environment.NewLine;
            ret += $"C) {p.C}"+Environment.NewLine;
            tbxPitanje.Text = ret;
        }

        private void btnOdgovori_Click(object sender, EventArgs e)
        {
            char odgovor;
            if (rbtnA.Checked == true)
                odgovor = 'a';
            else
                if (rbtnB.Checked == true)
                odgovor = 'b';
            else
                odgovor = 'c';
            proxy.Odgovor(id, odgovor);
            prikaziPitanje(proxy.VratiPitanje(id));
        }

        private void btnBrojPoena_Click(object sender, EventArgs e)
        {
            int poena = proxy.VratiBrojPoena(id);
            tbxBrojPoena.Text = poena.ToString();
        }
    }
}

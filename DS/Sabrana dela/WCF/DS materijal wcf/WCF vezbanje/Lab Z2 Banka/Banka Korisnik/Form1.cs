using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Banka_Korisnik.ServiceReferenceBanka;
namespace Banka_Korisnik
{
    public partial class Form1 : Form
    {
        private BankaClient proxy;
        public Form1()
        {
            InitializeComponent();
            proxy = new BankaClient();
        }

        private void btnUplata_Click(object sender, EventArgs e)
        {
            this.proxy.Uplati(decimal.Parse(tbxUplataIznos.Text), tbxUplataValuta.Text, decimal.Parse(tbxUplataKurs.Text));

        }

        private void btnIsplata_Click(object sender, EventArgs e)
        {
            this.proxy.Isplati(decimal.Parse(tbxIsplataIznos.Text));
        }

        private void btnEurKurs_Click(object sender, EventArgs e)
        {
            this.proxy.PostaviEur(decimal.Parse(tbxEurKurs.Text));
        }

        private void btnPromene_Click(object sender, EventArgs e)
        {
            List<string> promene = this.proxy.VratiPromene();
            tbxPromene.Text = String.Join(Environment.NewLine, promene);
        }
    }
}

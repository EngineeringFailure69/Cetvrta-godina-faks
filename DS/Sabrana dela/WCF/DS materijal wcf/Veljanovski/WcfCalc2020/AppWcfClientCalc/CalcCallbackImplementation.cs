using AppWcfClientCalc.CalcServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppWcfClientCalc
{
    public class CalcCallbackImplementation : ICalcCallback
    {
        TextBox rez;
        TextBox izr;
        
        public CalcCallbackImplementation(TextBox txtRezultat, TextBox txtIzraz)
        {
            rez = txtRezultat;
            izr = txtIzraz;
        }

        public void Promena(double rezultat, string izraz)
        {
            SetTextToTextBox(rez, rezultat.ToString());
            SetTextToTextBox(izr, izraz);
        }

        private void SetTextToTextBox(TextBox txt, string v)
        {
            txt.Invoke( new MethodInvoker( delegate { txt.Text = v; }));
        }
    }
}

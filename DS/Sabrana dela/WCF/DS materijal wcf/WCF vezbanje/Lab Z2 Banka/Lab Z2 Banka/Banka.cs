using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab_Z2_Banka
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Banka : IBanka
    {
        public decimal Isplati(decimal iznos)
        {
            if (iznos > Racun.Instance.Stanje)
                iznos = Racun.Instance.Stanje;
            Racun.Instance.Stanje -= iznos;
            Racun.Instance.Promene.Add($"[{DateTime.Now} :: Podignuto {iznos} RSD ]");
            return iznos;
        }

        public void PostaviEur(decimal koef)
        {
            Racun.Instance.EUR2DIN = koef;
            Racun.Instance.Promene.Add($"[{DateTime.Now} :: Kurs evra = {koef}]");
        }

        public void Uplati(decimal iznos, string valuta, decimal koef)
        {
            Racun.Instance.Stanje = iznos * koef;
            Racun.Instance.Promene.Add($"[{DateTime.Now} :: Uplaceno {iznos} {valuta}]");
        }

        public List<string> VratiPromene()
        {
            return Racun.Instance.Promene;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _6.WCF__Sep_2018
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Bank : IBank
    {
        public List<string> GetPromene()
        {
            return Repository.Instance.Promene;

        }

        public double isplatiDinare(double iznos)
        {
            if (iznos > Repository.Instance.Dinar)
            {
                iznos = Repository.Instance.Dinar;
            }
            Repository.Instance.Dinar -= iznos;
            Repository.Instance.Evro -= iznos / Repository.Instance.E2D;
            Repository.Instance.Promene.Add($"{DateTime.Now}: Podignuto {iznos} din");
            return iznos;

        }

        public void namestiKoef(double koef)
        {
            Repository.Instance.E2D = koef;
            Repository.Instance.Promene.Add($"{DateTime.Now}: Promenjen koef na {koef} ");

        }

        public void uplati(double iznos, string valuta, double kursPremaEvru)
        {
            Repository.Instance.Evro += iznos * kursPremaEvru;
            Repository.Instance.Dinar += iznos * kursPremaEvru * Repository.Instance.E2D;
            Repository.Instance.Promene.Add($"{DateTime.Now}: Uplaceno {iznos} {valuta} kurs: {kursPremaEvru}");
        }
    }
}

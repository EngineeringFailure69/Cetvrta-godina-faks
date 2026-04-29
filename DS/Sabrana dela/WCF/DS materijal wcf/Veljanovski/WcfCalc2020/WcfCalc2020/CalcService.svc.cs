using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCalc2020
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CalcService.svc or CalcService.svc.cs at the Solution Explorer and start debugging.
    public class CalcService : ICalc
    {
        string izraz = "";
        double rezultat = 0;

        ICalcCallback calback;

        public CalcService()
        {
            calback = OperationContext.Current.GetCallbackChannel<ICalcCallback>();
        }

        public void Dodaj(double a)
        {
            if (string.IsNullOrEmpty(izraz))
                izraz = a.ToString();
            else
                izraz += $" + {a}";
            rezultat += a;

            calback.Promena(rezultat, izraz);
        }

        public void Obrisi()
        {
            izraz = string.Empty;
            rezultat = 0;
            calback.Promena(rezultat, izraz);
        }

        public void Oduzmi(double a)
        {
            izraz += $" - {a}";
            rezultat -= a;
            calback.Promena(rezultat, izraz);
        }

        public void Podeli(double a)
        {
            izraz += $" / {a}";
            rezultat /= a;
            calback.Promena(rezultat, izraz);
        }

        public void Pomnozi(double a)
        {
            izraz += $" * {a}";
            rezultat *= a;
            calback.Promena(rezultat, izraz);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab_2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Banka : IBanka
    {
        public double isplati(double dinara)
        {
            if (dinara > Repository.Instance.Dinari)
            {
                dinara = Repository.Instance.Dinari;
            }
            Repository.Instance.Dinari -= dinara;
            Repository.Instance.Promene.Add($"{DateTime.Now} : Isplaceno: {dinara} din | Stanje: {Repository.Instance.Dinari}");
            return dinara;
        }

        public void prebaciEurUDinar(double vrednost, double koef)
        {
            Repository.Instance.KoefDinara = koef;
            if (Repository.Instance.Evri < vrednost)
                vrednost = Repository.Instance.Evri;
            Repository.Instance.Evri -= vrednost;
            Repository.Instance.Dinari += vrednost * koef;
            Repository.Instance.Promene.Add($"{DateTime.Now} : Prebaceno na dinarski: {vrednost} eur po koef: {koef} | Stanje: Din: {Repository.Instance.Dinari} Eur: {Repository.Instance.Evri}");

        }

        public List<string> Promene()
        {
            return Repository.Instance.Promene;
        }

        public void uplati(double iznos, string naziv, double koefEur)
        {
            Repository.Instance.Evri += iznos * koefEur;
            Repository.Instance.Promene.Add($"{DateTime.Now}: Na devizni racun uplaceno: {iznos} {naziv} po {koefEur}");

        }
    }
}

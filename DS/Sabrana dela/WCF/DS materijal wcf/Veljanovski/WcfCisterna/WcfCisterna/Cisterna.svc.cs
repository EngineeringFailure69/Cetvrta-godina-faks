using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfCisterna
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Cisterna" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Cisterna.svc or Cisterna.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Cisterna : ICisterna
    {
        static Stanje trenutnoStanje = new Stanje();
        static IList<string> promene = new List<string>();

        //dodavanja određenog materijala koji je opisan zapreminom koja je dodata i svojom gustinom.
        //ispusti određenu zapreminu.
        //prikazati trenutno zauzeće cisterne i njenu gustinu.
        //izlistati sve promene nad cisternom
        public void DodajMaterijal(string materijal, double V, double r)
        {
            double m = trenutnoStanje.Gustina * trenutnoStanje.Zapremina;

            m += V * r;

            trenutnoStanje.Zapremina += V;

            trenutnoStanje.Gustina = m / trenutnoStanje.Zapremina;

            promene.Add($"{DateTime.Now} :: Dodat {materijal} [Zapremina = {V}, Gustina = {r}], Stanje Cisterne [Zapremina = {trenutnoStanje.Zapremina}, Gustina = {trenutnoStanje.Gustina}]");
        }

        public void Ispusti(double V)
        {
            trenutnoStanje.Zapremina -= V;
            promene.Add($"{DateTime.Now} :: Ispusteno {V}, Stanje Cisterne [Zapremina = {trenutnoStanje.Zapremina}, Gustina = {trenutnoStanje.Gustina}]");
        }

        public Stanje TrenutnoStanje()
        {
            return trenutnoStanje;
        }

        public IList<string> VratiPromene()
        {
            return promene;
        }
    }
}

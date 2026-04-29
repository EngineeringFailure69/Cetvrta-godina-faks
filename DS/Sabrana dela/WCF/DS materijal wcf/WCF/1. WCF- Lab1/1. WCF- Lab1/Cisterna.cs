using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _1.WCF__Lab1
{
    public class Cisterna : ICisterna
    {
        public void dodajMaterijal(string naziv, float v, float ro)
        {
            float masa = Repositorium.Instance.Ro * Repositorium.Instance.V + v * ro;
            Repositorium.Instance.V += v;
            Repositorium.Instance.Ro = masa / Repositorium.Instance.V;
            Repositorium.Instance.Promene.Add($"{DateTime.Now} : Dodat nov materijal: {naziv} {v} {ro}");
        }

        public void ispustiZapreminu(float v)
        {
            if (v > Repositorium.Instance.V)
            {
                v = Repositorium.Instance.V;
                Repositorium.Instance.V = 0;
                
            }

            Repositorium.Instance.Promene.Add($"{DateTime.Now} : Ispraznjeno V={v}");

        }

        public Stanje trenutnoZauzece()
        {

            return new Stanje
            {
                Ro = Repositorium.Instance.Ro,
                V = Repositorium.Instance.V
            };

        }

        public List<string> vratiPromene()
        {
            return Repositorium.Instance.Promene;
        }
    }
}

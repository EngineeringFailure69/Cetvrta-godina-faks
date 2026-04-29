using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Z1_Cisterna
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Cisterna : ICisterna
    {
        public void Dodaj(Materijal m)
        {
            float masa = Repository.Instance.Ro * Repository.Instance.V + m.V * m.Ro;
            Repository.Instance.V += m.V;
            Repository.Instance.Ro = masa / Repository.Instance.V;
            Repository.Instance.Promene.Add($"{DateTime.Now}:: Dodata je materijal {m.Naziv} sa Ro = {m.Ro} zapreminie {m.V}");
        }

        public void Ispusti(float v)
        {
            if (Repository.Instance.V > v)
            {
                Repository.Instance.V -= v;
                Repository.Instance.Promene.Add($"{DateTime.Now} :: Ispusteno je {v} tecnosti, nova zapremina je {Repository.Instance.V} ");
            }
            else
            {
                Repository.Instance.V = 0;
                Repository.Instance.Promene.Add($"{DateTime.Now}:: Cisterna je prazna");
            }
        }

        public Materijal Stanje()
        {
            return new Materijal
            {
                V = Repository.Instance.V,
                Ro = Repository.Instance.Ro
            };
        }

        public List<string> SvePromene()
        {
            return Repository.Instance.Promene;
        }
    }
}

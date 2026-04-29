using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab_Z1_Cisterna
{
    public class Cisterna : ICisterna
    {
        public void DodajMateriju(string naziv, float v, float ro)
        {
            float masa = v * ro + Repository.Instance.Ro * Repository.Instance.V;
            Repository.Instance.V += v;
            Repository.Instance.Ro = Repository.Instance.V / masa;
            Repository.Instance.Promene.Add($"{DateTime.Now} :: U Sisternu dodato {naziv} zapremine {v} i gustine {ro}");
        }

        public List<string> GetPromene()
        {
            return Repository.Instance.Promene;
        }

        public Stanje GetStanje()
        {
            Stanje ret = new Stanje
            {
                V = Repository.Instance.V,
                Ro = Repository.Instance.Ro
            };
            return ret;
        }

        public void Ispusti(float v)
        {
            if (v > Repository.Instance.V)
                v = Repository.Instance.V;
            Repository.Instance.V -= v;
            Repository.Instance.Promene.Add($"{DateTime.Now} :: Ispusteno {v} ");

        }
    }
}

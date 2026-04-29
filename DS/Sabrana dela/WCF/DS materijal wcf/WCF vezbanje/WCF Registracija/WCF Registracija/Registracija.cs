using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Registracija
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Registracija : IRegistracija
    {
        public void Add(Vozilo vozilo, Vozac vozac)
        {
            if (Repository.Instance.Vozaci.ContainsKey(vozac.JMBG))
            {
                Repository.Instance.Vozila[Repository.Instance.Vozaci[vozac.JMBG]].Add(vozilo);
            }
            else
            {
                Repository.Instance.Vozaci.Add(vozac.JMBG, vozac);
                List<Vozilo> a = new List<Vozilo>();
                a.Add(vozilo);
                Repository.Instance.Vozila.Add(vozac, a);
            }
        }

        public Dictionary<Vozac, List<Vozilo>> VratiSve()
        {
            return Repository.Instance.Vozila;
        }

        public List<Vozac> VratiVozace(string model)
        {
            List<Vozac> ret = new List<Vozac>();
            foreach(Vozac v in Repository.Instance.Vozaci.Values)
            {
                foreach(Vozilo vozilo in Repository.Instance.Vozila[v])
                {
                    if (vozilo.Model.Equals(model))
                    {
                        ret.Add(v);
                        break;
                    }
                }
            }
            return ret;
        }

        public List<Vozilo> VratiVozila(Vozac v)
        {
            return Repository.Instance.Vozila[Repository.Instance.Vozaci[v.JMBG]];
        }
    }
}

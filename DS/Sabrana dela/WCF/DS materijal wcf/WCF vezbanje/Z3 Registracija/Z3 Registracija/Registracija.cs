using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Z3_Registracija
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Registracija : IRegistracija
    {
        public void DodajRegistraciju(Vlasnik vlasnik, Vozilo vozilo)
        {
            if (Repository.Instance.Vlasnici.ContainsKey(vlasnik.JMBG))
            {
                Repository.Instance.Vlasnici[vlasnik.JMBG].Add(vozilo);
            }
            else
            {
                List<Vozilo> dodaj = new List<Vozilo>();
                dodaj.Add(vozilo);
                Repository.Instance.Vlasnici.Add(vlasnik.JMBG,dodaj );
            }
        }

        public List<Vlasnik> PosedujeModel(string model)
        {
            List<Vlasnik> ret = new List<Vlasnik>();
            foreach(string v in Repository.Instance.Vlasnici.Keys)
            {
                foreach(Vozilo vozilo in Repository.Instance.Vlasnici[v])
                    if (vozilo.Marka.Equals(model))
                    {
                        ret.Add(vozilo.Vlasnik);
                        break;
                    }
            }
            return ret;
        }

        public List<Vozilo> vratiVozila()
        {
            List<Vozilo> ret = new List<Vozilo>();
            foreach(string v in Repository.Instance.Vlasnici.Keys)
            {
                ret.AddRange(Repository.Instance.Vlasnici[v]);
            }
            return ret;
        }

        public List<Vozilo> VratiVozilaVlasnika(Vlasnik vlasnik)
        {
            return Repository.Instance.Vlasnici[vlasnik.JMBG];
        }
    }
}

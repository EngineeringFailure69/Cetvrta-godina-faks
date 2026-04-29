using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _7.WCF__Dec_2018
{
    public class Registracija : IRegistracija
    {
        public void dodajRegistraciju(Vlasnik vlasnik, Vozilo vozilo)
        {
            if (Repository.Instance.Vlasnici.ContainsKey(vlasnik.JMBG))
            {
                Vlasnik v = Repository.Instance.Vlasnici[vlasnik.JMBG];
                Repository.Instance.Registracije[v].Add(vozilo);
            }
            else
            {
                List<Vozilo> vozila = new List<Vozilo>();
                vozila.Add(vozilo);
                Repository.Instance.Registracije.Add(vlasnik, vozila);
                Repository.Instance.Vlasnici.Add(vlasnik.JMBG, vlasnik);
            }
        }

        public List<Vlasnik> posedujeVozilo(string model)
        {
            List<Vlasnik> ret = new List<Vlasnik>();
            foreach(Vlasnik i in Repository.Instance.Vlasnici.Values)
            {
                foreach(Vozilo j in Repository.Instance.Registracije[i])
                {
                    if (j.Model.Equals(model))
                    {
                        ret.Add(i);
                        break;
                    }
                }
            }

            return ret;

        }

        public Dictionary<Vlasnik, List<Vozilo>> vratiRegistracije()
        {
            return Repository.Instance.Registracije;

        }

        public List<Vozilo> vratiVozilaVlasnika(Vlasnik v)
        {
            Vlasnik vlasnik = Repository.Instance.Vlasnici[v.JMBG];
            return Repository.Instance.Registracije[vlasnik];
        }
    }
}

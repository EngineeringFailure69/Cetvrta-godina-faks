using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _3.WCF__Lab3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Registracija : IRegistracija
    {
        public void dodajRegistraciju(Vlasnik vlasnik, Vozilo vozilo)
        {
            if (Repository.Insance.Vlasnici.ContainsKey(vlasnik.JMBG))
            {
                Repository.Insance.VlasnikovaVozila[Repository.Insance.Vlasnici[vlasnik.JMBG]].Add(vozilo);
            }
            else
            {
                Repository.Insance.Vlasnici.Add(vlasnik.JMBG, vlasnik);
                List<Vozilo> novo = new List<Vozilo>();
                novo.Add(vozilo);
                Repository.Insance.VlasnikovaVozila.Add(vlasnik, novo);
            }

        }

        public List<Vlasnik> posedujeModel(string model)
        {
            List<Vlasnik> ret = new List<Vlasnik>();
            foreach (Vlasnik v in Repository.Insance.Vlasnici.Values)
            {
                foreach (Vozilo vozilo in Repository.Insance.VlasnikovaVozila[v])
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

        public Dictionary<Vlasnik, List<Vozilo>> vratiRegistracije()
        {
            return Repository.Insance.VlasnikovaVozila;
        }

        public List<Vozilo> vratiVozilaVlasnike(Vlasnik vlasnik)
        {
            return Repository.Insance.VlasnikovaVozila[Repository.Insance.Vlasnici[vlasnik.JMBG]];
        }
    }
}

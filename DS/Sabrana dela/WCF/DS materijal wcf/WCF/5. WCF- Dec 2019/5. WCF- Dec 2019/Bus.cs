using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _5.WCF__Dec_2019
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Bus : IBus
    {
        public void RegistrujLiniju(int sifra, Dictionary<string, DateTime> stanice)
        {
            Linija linija = new Linija
            {
                Sifra = sifra,
                Stanice = stanice
            };
            if(Repositroy.Instance.BusLinije.Keys.Contains(sifra))
            {
                Repositroy.Instance.BusLinije.Remove(sifra);
            }
            Repositroy.Instance.BusLinije.Add(sifra, linija);

        }

        public List<int> vratiLinije(string stanica)
        {
            List<int> ret = new List<int>();
            foreach(Linija l in Repositroy.Instance.BusLinije.Values)
            {
                foreach(string s in l.Stanice.Keys)
                {
                    if (s.Equals(stanica))
                    {
                        ret.Add(l.Sifra);
                        break;
                    }
                }
                
            }

            return ret;
        }

        public List<int> vratiLinijeKojeStaju(string stanica, string staje)
        {
            List<int> ret = new List<int>();
            foreach (Linija l in Repositroy.Instance.BusLinije.Values)
            {
                if (l.Stanice.Keys.Contains(stanica)&&l.Stanice.Keys.Contains(staje))
                {
                    ret.Add(l.Sifra);
                }
            }

            return ret;
        }

        public Dictionary<string, DateTime> vratiStanice(int kod, string stanica)
        {
            Dictionary<string, DateTime> stanice = new Dictionary<string, DateTime>();
            Linija l = Repositroy.Instance.BusLinije[kod];
            DateTime s = l.Stanice[stanica];
            foreach (string i in l.Stanice.Keys)
            {
                DateTime m = l.Stanice[i];
                if (DateTime.Compare(m, s) > 0)
                {
                    stanice.Add(i, m);
                }
            }


            return stanice;
        }
    }
}

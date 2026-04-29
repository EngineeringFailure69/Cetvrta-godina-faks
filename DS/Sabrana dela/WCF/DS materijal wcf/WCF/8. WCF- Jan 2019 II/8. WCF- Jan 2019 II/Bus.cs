using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _8.WCF__Jan_2019_II
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Bus : IBus
    {
        public List<string> LinijeNaStanice(string stanica)
        {
            List<String> ret = new List<string>();
            foreach(String i in Repositroy.Instance.Linije.Keys)
            {
                foreach(Stanica j in Repositroy.Instance.Linije[i])
                    if(j.Ime.Equals(stanica))
                    {
                        ret.Add(i);
                        break;
                    }
            }
            return ret;
        }

        public List<string> OdDo(string s1, string s2)
        {
            List<String> ret = new List<string>();
            foreach (String i in Repositroy.Instance.Linije.Keys)
            {
                foreach (Stanica j in Repositroy.Instance.Linije[i])
                    if (j.Ime.Equals(s1))
                    {
                        ret.Add(i);
                        break;
                    }
            }
            return ret;
        }

        public void RegistrujLiniju(string sifra, List<Stanica> linije)
        {
            if(!Repositroy.Instance.Linije.ContainsKey(sifra))
            {
                Repositroy.Instance.Linije.Add(sifra, linije);
            }
        }

        public List<Stanica> vratiStanice(string sifra, string sta)
        {
            throw new NotImplementedException();
        }
    }
}

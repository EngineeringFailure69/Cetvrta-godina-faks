using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.WCF__Lab3
{
    public class Repository
    {
        private static Repository instance=null;
        private static object locker=true;
        public static Repository Insance
        {
            get
            {
                lock(locker)
                {
                    if (instance == null)
                        instance = new Repository();
                    return instance;
                }
            }
        }

        public Dictionary<string,Vlasnik> Vlasnici { get; set; }
        public Dictionary<Vlasnik, List<Vozilo>> VlasnikovaVozila { get; set; }
        protected Repository()
        {
            Vlasnici = new Dictionary<string, Vlasnik>();
            VlasnikovaVozila = new Dictionary<Vlasnik, List<Vozilo>>();
        }
    }
}

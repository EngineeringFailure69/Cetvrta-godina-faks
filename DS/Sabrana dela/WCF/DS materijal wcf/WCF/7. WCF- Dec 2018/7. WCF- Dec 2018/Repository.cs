using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.WCF__Dec_2018
{
    public class Repository
    {
        private static Repository instance;
        private static object locker = true;
        public static Repository Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Repository();
                    return instance;
                }
            }
        }
        public  Dictionary<Vlasnik,List<Vozilo>> Registracije { get; set; }
        public  Dictionary<string,Vlasnik> Vlasnici { get; set; }
        protected Repository()
        {
            Registracije = new Dictionary<Vlasnik, List<Vozilo>>();
            Vlasnici = new Dictionary<string, Vlasnik>();
        }
    }
}

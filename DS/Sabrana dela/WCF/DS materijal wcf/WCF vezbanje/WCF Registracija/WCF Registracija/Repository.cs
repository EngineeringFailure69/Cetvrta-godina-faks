using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Registracija
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


        public Dictionary<string,Vozac> Vozaci { get; set; }
        public Dictionary<Vozac,List<Vozilo>> Vozila { get; set; }

        protected Repository()
        {
            Vozaci = new Dictionary<string, Vozac>();
            Vozila = new Dictionary<Vozac, List<Vozilo>>();
        }

    }
}

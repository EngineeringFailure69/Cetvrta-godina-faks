using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z3_Registracija
{
    public class Repository
    {
        private static Repository instance;
        private static object locker = true;

        public static Repository Instance
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

        public Dictionary<string,List<Vozilo>> Vlasnici;
    
        protected Repository()
        {
            this.Vlasnici = new Dictionary<string, List<Vozilo>>();
        }

    }
}

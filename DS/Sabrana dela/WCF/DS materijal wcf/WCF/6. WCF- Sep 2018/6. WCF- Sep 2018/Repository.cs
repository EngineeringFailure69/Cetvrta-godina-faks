using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.WCF__Sep_2018
{
    public class Repository
    {
        private static Repository instance;
        private static object locker = true;

        public static Repository Instance {
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

        public double Dinar { get; set; }
        public double Evro { get; set; }
        public double E2D { get; set; }
        public List<String> Promene { get; set; }
        protected Repository()
        {
            Dinar = 0;
            Evro = 0;
            E2D = 119;
            Promene = new List<String>();
        }

    }
}

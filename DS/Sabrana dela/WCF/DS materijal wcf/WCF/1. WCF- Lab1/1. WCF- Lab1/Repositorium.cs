using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.WCF__Lab1
{
    public class Repositorium
    {
        private static Repositorium instance;
        private static object locker = true;

        public static Repositorium Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Repositorium();
                    return instance;
                }
            }
        }

        public float V { get; set; }
        public float Ro { get; set; }
        public List<string> Promene { get; set; }

        protected Repositorium()
        {
            V = 0;
            Ro = 0;
            Promene = new List<string>();
        }
    }
}

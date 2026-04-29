using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.WCF__Dec_2019
{
    public class Repositroy
    {
        private static Repositroy instance;
        private static object locker = true;

        public static Repositroy Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Repositroy();
                    return instance;
                }
            }
        }

        public Dictionary<int,Linija> BusLinije { get; set; }

        protected Repositroy()
        {
            BusLinije = new Dictionary<int, Linija>();
        }

    }
}

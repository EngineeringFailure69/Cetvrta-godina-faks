using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.WCF__Jan_2019_II
{
   public  class Repositroy
    {
        private static Repositroy instance;
        private static object locker=true;
        public static Repositroy Instance {
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

        public Dictionary<string,List<Stanica>> Linije { get; set; }
        protected Repositroy()
        {
            Linije = new Dictionary<string, List<Stanica>>();
        }
    }
}

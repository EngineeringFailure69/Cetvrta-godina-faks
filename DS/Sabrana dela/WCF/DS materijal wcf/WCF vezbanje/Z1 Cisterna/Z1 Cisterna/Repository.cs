using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1_Cisterna
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
                    {
                        instance = new Repository();
                    }
                    return instance;
                }
            }
        }

        public float V { get; set; }
        public float Ro { get; set; }
        public List<string> Promene { get; set; }

        protected Repository()
        {
            this.V = 0;
            this.Ro = 0;
            this.Promene = new List<string>();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
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

        public double Dinari { get; set; }
        public double Evri { get; set; }
        public double KoefDinara { get; set; }
        public List<String> Promene { get; set; }
        protected Repository()
        {
            Dinari = 0;
            Evri = 0;
            KoefDinara = 120;
            Promene = new List<string>();
        }
    }
}

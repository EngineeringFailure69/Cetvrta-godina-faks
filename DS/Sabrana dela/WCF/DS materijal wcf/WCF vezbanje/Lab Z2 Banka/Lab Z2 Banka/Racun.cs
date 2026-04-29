using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Z2_Banka
{
    public class Racun
    {
        private static Racun instance;
        private static object locker = true;
        public static Racun Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Racun();
                    return instance;
                }
            }
        }

        public decimal Stanje { get; set; }
        public decimal EUR2DIN { get; set; }
        public List<string> Promene { get; set; }
        protected Racun()
        {
            Stanje = 0;
            EUR2DIN = 120;
            Promene = new List<string>();
        }
    }
}

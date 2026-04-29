using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z2_Banka
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

        public decimal EUR2RSD { get; set; }
        public decimal StanjeEur { get; set; }
        public decimal StanjeDin { get; set; }
        public List<string> Promene { get; set; }
        protected Repository()
        {
            this.EUR2RSD = 118;
            this.StanjeDin = 0;
            this.StanjeEur = 0;
            this.Promene = new List<string>();
        }
    }
}

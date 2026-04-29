using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Lab_Kviz
{
    public class Repositery
    {
        private static Repositery instance;
        private static object locker = true;
        public static Repositery Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                        instance = new Repositery();
                    return instance;
                }
            }

        }

        public Dictionary<int, Pitanje> Pitanja { get; set; }
        public Dictionary<int, char> Odgovori { get; set; }
        public Dictionary<int,int> TrenutnoPitanje { get; set; }
        public Dictionary<int,int> BrojPoena { get; set; }
        public int BrojPitanja { get; set; }

        protected Repositery()
        {
            this.Pitanja = new Dictionary<int,Pitanje > ();
            this.Odgovori=new Dictionary<int, char> ();
            this.TrenutnoPitanje = new Dictionary<int, int>();
            this.BrojPoena = new Dictionary<int, int>();
            Pitanje a = new Pitanje {
                PostavkaPitanja = "Glavni Grad Srbije",
                A = "Beograd",
                B = "Nis",
                C = "Novi Sad"
            };
            this.Pitanja.Add(0, a);
            this.Odgovori.Add(0, 'a');
            a = new Pitanje
            {
                PostavkaPitanja = "Glavni Grad Madjarske",
                A = "Budimpesta",
                B = "Milan",
                C = "Bec"
            };
            this.Pitanja.Add(1, a);
            this.Odgovori.Add(1, 'a');
            a = new Pitanje
            {
                PostavkaPitanja = "Glavni Grad Engleske",
                A = "Budimpesta",
                B = "London",
                C = "Nis"
            };
            this.Pitanja.Add(2, a);
            this.Odgovori.Add(2, 'b');
            a = new Pitanje
            {
                PostavkaPitanja = "Glavni Grad Italije",
                A = "Budimpesta",
                B = "Milan",
                C = "Rim"
            };
            this.Pitanja.Add(3, a);
            this.Odgovori.Add(3, 'c');
            this.BrojPitanja = 4;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Lab_Kviz
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Kviz : IKviz
    {
        public void Inicijalizuj(int id)
        {
            if (Repositery.Instance.TrenutnoPitanje.ContainsKey(id))
            {
                Repositery.Instance.TrenutnoPitanje[id] = 0;
                Repositery.Instance.BrojPoena[id] = 0;
            }
            else
            {
               
                Repositery.Instance.TrenutnoPitanje.Add(id, 0);
                Repositery.Instance.BrojPoena.Add(id, 0);
            }
        }

        public void Odgovor(int id,char odgovor)
        {
          
          if(Repositery.Instance.Odgovori[Repositery.Instance.TrenutnoPitanje[id]]==odgovor)
            {
                Repositery.Instance.BrojPoena[id]++;
            }
            Repositery.Instance.TrenutnoPitanje[id]++;
            if (Repositery.Instance.TrenutnoPitanje[id] ==Repositery.Instance.BrojPitanja)
                Repositery.Instance.TrenutnoPitanje[id] = 0;
        }

        public int VratiBrojPoena(int id)
        {
            return Repositery.Instance.BrojPoena[id];

        }

        public Pitanje VratiPitanje(int id)
        {
            return Repositery.Instance.Pitanja[Repositery.Instance.TrenutnoPitanje[id]];
        }

     
    }
}

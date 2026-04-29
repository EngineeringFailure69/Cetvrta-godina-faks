using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Z2_Banka
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Racun : IRacun
    {
        public List<string> GetPromene()
        {
            return Repository.Instance.Promene;
        }

        public void Isplata(decimal inzosRsd)
        {
            if (inzosRsd > Repository.Instance.StanjeDin)
                inzosRsd = Repository.Instance.StanjeDin;
            Repository.Instance.StanjeEur -= inzosRsd / Repository.Instance.EUR2RSD;
            Repository.Instance.StanjeDin -= inzosRsd;
            Repository.Instance.Promene.Add($"{DateTime.Now} :: Iplaceno {inzosRsd} RSD,  Stanje dinarskog {Repository.Instance.StanjeDin} dinara || Stanje deviznog {Repository.Instance.StanjeEur}");
        }

        public void SetKurs(decimal eur2rsd)
        {
            Repository.Instance.EUR2RSD = eur2rsd;
            Repository.Instance.Promene.Add($"{DateTime.Now} :: Kurs promenjen na {eur2rsd}");
        }

        public void Uplata(decimal iznos, string Naziv, decimal k)
        {
            Repository.Instance.StanjeEur += iznos * k;
            Repository.Instance.StanjeDin += iznos * k * Repository.Instance.EUR2RSD;

            Repository.Instance.Promene.Add(
                $"{DateTime.Now} :: Uplaceno {iznos} {Naziv}, koeficijent prema EUR = {k}");
        }
    
    }
}

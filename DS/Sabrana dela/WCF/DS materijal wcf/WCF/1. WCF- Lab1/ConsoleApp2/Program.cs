using ConsoleApp2.ServiceReferenceCisterna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
    
        static void Main(string[] args)
        {
            CisternaClient cisternaClient = new CisternaClient();
            cisternaClient.dodajMaterijal("Voda", 100, 1);
          cisternaClient.dodajMaterijal("Secer",10,4);
          cisternaClient.dodajMaterijal("Mleko",80,0.56f);
            cisternaClient.dodajMaterijal("Sirup",5,0.32f);

            cisternaClient.ispustiZapreminu(13);

            Stanje s = cisternaClient.trenutnoZauzece();

            Console.Out.WriteLine(s.V + " " + s.Ro);

            List<string> promene = cisternaClient.vratiPromene();
            foreach (string i in promene)
                Console.Out.WriteLine(i);

        }
    }
}

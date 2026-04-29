using AppCisternaClient.CisternaServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCisternaClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CisternaClient proxy = new CisternaClient();

            var stanje = proxy.TrenutnoStanje();
            Console.WriteLine($"V = {stanje.Zapremina} Ro = {stanje.Gustina}");

            proxy.DodajMaterijal("voda", 5, 1000);
            proxy.DodajMaterijal("kakao", 0.4, 500);
            proxy.DodajMaterijal("mleko", 5, 1100);
            proxy.DodajMaterijal("secer", 1, 2000);

            stanje = proxy.TrenutnoStanje();
            Console.WriteLine($"V = {stanje.Zapremina} Ro = {stanje.Gustina}");

            Console.WriteLine("------------------------------------------");
            var promene = proxy.VratiPromene();
            foreach(var p in promene)
            {
                Console.WriteLine(p);
            }

            proxy.Ispusti(0.5);

            Console.WriteLine("------------------------------------------");

            promene = proxy.VratiPromene();
            foreach (var p in promene)
            {
                Console.WriteLine(p);
            }

            System.Console.ReadLine();
        }
    }
}

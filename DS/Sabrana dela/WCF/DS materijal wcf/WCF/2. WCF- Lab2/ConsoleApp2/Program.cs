using ConsoleApp2.ServiceReferenceBanka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            BankaClient proxy = new BankaClient();
            proxy.uplati(1000, "Funti", 1.5);
            proxy.uplati(1000, "Maraka",0.9);
            proxy.uplati(1000, "Franaka",0.97);

       
            proxy.prebaciEurUDinar(1400, 119.43);
            proxy.isplati(104234);
            List<string> promene = proxy.Promene();
            foreach (string i in promene)
                Console.WriteLine(i);

        }
    }
}

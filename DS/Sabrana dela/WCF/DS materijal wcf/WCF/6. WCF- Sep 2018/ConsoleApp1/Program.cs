using ConsoleApp1.ServiceReferenceBanka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankClient proxy = new BankClient();
            proxy.uplati(100, "funta", 1.4);
            proxy.uplati(100, "franka", 0.9);
            proxy.uplati(100, "Dolar",0.99 );
            proxy.isplatiDinare(1000);
            proxy.namestiKoef(120.32);
            List<String> promene = proxy.GetPromene();
            foreach (String i in promene)
                Console.WriteLine(i);

        }
    }
}

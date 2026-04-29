using ConsoleApp1.ServiceReferenceBus;
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
            BusClient proxy = new BusClient();
            Dictionary<string, DateTime> stanice = new Dictionary<string, DateTime>();
            stanice.Add("stanica1", DateTime.Now);
            stanice.Add("stanica2", DateTime.Now.AddMinutes(15));
            stanice.Add("stanica3", DateTime.Now.AddMinutes(35));
            proxy.RegistrujLiniju(1, stanice);
            stanice.Add("stanica4", DateTime.Now.AddMinutes(45));
            proxy.RegistrujLiniju(2, stanice);
            stanice = new Dictionary<string, DateTime>();
            stanice.Add("stanica5", DateTime.Now);
            proxy.RegistrujLiniju(3, stanice);

            List<int> r = proxy.vratiLinije("stanica5");
            foreach(int i in r)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("SSSSSSSSSSSSSS");
            r = proxy.vratiLinijeKojeStaju("stanica1", "stanica4");
            foreach (int i in r)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("SSSSSSSSSSSSSS");

            stanice = proxy.vratiStanice(1, "stanica2");
            foreach(string i in stanice.Keys)
            {
                Console.WriteLine(i);
            }

        }
    }
}

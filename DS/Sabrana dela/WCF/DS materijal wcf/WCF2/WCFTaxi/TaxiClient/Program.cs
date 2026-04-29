using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace TaxiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TaxiServis.Service1Client proxy;

                TaxiCallback callback = new TaxiCallback();

                InstanceContext instanceContext = new InstanceContext(callback);

                proxy = new TaxiServis.Service1Client(instanceContext);
                Console.WriteLine("Unesi 1 ako si vozac, 2 ako si korisnik");
                String opcija = Console.ReadLine();
                String id="";
                switch (opcija)
                {
                    case "1":
                        {
                            Console.WriteLine("Unesi id");
                            id = Console.ReadLine();
                            proxy.RegisterTaxi(id);
                           
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Unesite adresu");
                            String adresa = Console.ReadLine();
                            proxy.RequestTaxi(adresa);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                while (opcija == "1")
                {                    
                    if (opcija == "1")
                    {
                        proxy.SetTaxiStatus(id,true);
                        Console.WriteLine("Unesi 1 kada zavrsite sa voznjom");
                        opcija = Console.ReadLine();
                    }
                }


                Console.ReadLine();
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

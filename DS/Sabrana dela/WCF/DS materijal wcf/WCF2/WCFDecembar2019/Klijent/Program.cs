using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Klijent
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chat.Service1Client proxy = null;

                MessageCallback callback = new MessageCallback();

                InstanceContext instanceContext = new InstanceContext(callback);

                proxy = new Chat.Service1Client(instanceContext);

                Console.WriteLine("Registruj ime");
                string name = Console.ReadLine();
                proxy.registerName(name);
                Console.WriteLine("Za slanje poruke 1, za pribavljivanje poruka 2, za kraj bilo sta");
                string op = Console.ReadLine();
                while(op=="1" || op == "2")
                {
                    switch (op)
                    {
                        case "1":
                            {
                                Console.WriteLine("Unesi ime korisnika ili SVI");
                                string to = Console.ReadLine();
                                Console.WriteLine("Unesi tekst poruke");
                                string text = Console.ReadLine();
                                proxy.sendMessage(name,to,text);
                                break;
                            }
                        case "2":
                            {
                                List<Chat.Message> messages = proxy.requestMessageHistory(DateTime.MinValue, DateTime.MaxValue, name).ToList();
                                messages.ForEach(x => {
                                    Console.WriteLine(x.from + ": " + x.text +"\n sent to " +x.to+"\n" +"\n" + x.time.ToString());
                                });
                                break;
                            }
                        default:
                            {
                                break;
                            }

                    }
                    Console.WriteLine("Za slanje poruke 1, za pribavljivanje poruka 2, za kraj bilo sta");
                    op = Console.ReadLine();
                }
                Console.ReadLine();
            }
            catch(Exception e)
            {

            }
        }
    }
}

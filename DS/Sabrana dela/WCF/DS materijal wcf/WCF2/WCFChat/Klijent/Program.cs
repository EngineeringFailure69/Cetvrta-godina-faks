using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

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

                Console.WriteLine("Dobrodosli. Unesite Vas username :");

                string username = Console.ReadLine();

                if (proxy.Login(username))
                {
                    Console.WriteLine("Unesite : 1) nove poruke 2) posalji poruku 3) logout");
                    String op = Console.ReadLine();

                    while(op=="1" || op == "2")
                    {
                        switch (op)
                        {
                            case "1":
                                {
                                    List<Chat.Message> poruke = proxy.ReadNew(username).ToList();
                                    poruke.ForEach(x =>
                                    {
                                        Console.WriteLine(x.from+" :"+x.text+"\n"+x.time.ToString()+"\n");
                                    });
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Unesite username korisnika kome zelite da posaljete poruku ili SVI");
                                    string to = Console.ReadLine();
                                    Console.WriteLine("Unesite tekst poruke");
                                    string text = Console.ReadLine();
                                    proxy.SendMessage(username,to,text);
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                               
                        }
                        Console.WriteLine("Unesite : 1) nove poruke 2) posalji poruku 3) logout");
                        op = Console.ReadLine();
                    }
                    proxy.Logout(username);
                }
                Console.ReadLine();
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

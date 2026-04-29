using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFChat
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        public bool Login(string username)
        {
            IMessageCallback c = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            if (!Store.Instanca.callbacks.Any(x => x.Key == username) && Store.Instanca.usernames.Exists(x => x == username))
            {
                Store.Instanca.callbacks.Add(username, c);
                c.ReceiveMessage(new Message("Admin", username, "Ulogovani ste."));
                return true;
            }
            else if(Store.Instanca.callbacks.Any(x => x.Key == username))
            {
                c.ReceiveMessage(new Message("Admin", username, "Vec je ulogovan korisnik sa unesenim usernameom"));
            }
            return false;

        }

        public bool Logout(string username)
        {
            IMessageCallback c = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            if (Store.Instanca.callbacks.Any(x => x.Key == username))
            {
                if(Store.Instanca.callbacks.Remove(username))
                {
                    c.ReceiveMessage(new Message("Admin", username, "Izlogovani ste"));
                    return true;
                }
                else
                {
                    c.ReceiveMessage(new Message("Admin", username, "Neuspelo brisanje iz callback liste"));
                }
                
            }
            else
            {
                c.ReceiveMessage(new Message("Admin", username, "Ne postoji ulogovan user sa tim usernameom"));

            }
            return false;

        }

        public List<Message> ReadNew(string username)
        {
            List<Message> poruke = new List<Message>();
            Store.Instanca.messages.
                Where(x => x.to == username).ToList().ForEach(x=> 
                                                                {
                                                                    poruke.Add(x);// <string,Message> x ---> x.Value = Message
                                                                });
            return poruke;
        }

        public void SendMessage(string from, string to, string text)
        {
            Message m = new WCFChat.Message(from, to, text);
            IMessageCallback c = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            if (m.to == "SVI")
            {
                Store.Instanca.usernames.ForEach(x=> 
                        {
                            if (x != from) {
                                if (Store.Instanca.callbacks.Any(y => y.Key == x))
                                {
                                    Store.Instanca.callbacks.Where(y => y.Key == x).First().Value.ReceiveMessage(m);
                                }
                                else
                                {
                                    Store.Instanca.messages.Add( m);
                                    c.ReceiveMessage(new WCFChat.Message("Admin", m.from, "Trazeni korisnik trenutno nije online. Poruka je dodata u listu."));
                                }
                            }
                        });
            }
            else
            {
                if (Store.Instanca.callbacks.Any(x => x.Key == m.to))
                {
                    Store.Instanca.callbacks.Where(x => x.Key == m.to).First().Value.ReceiveMessage(m);
                }
                else if(Store.Instanca.usernames.Any(x=>x==m.to))
                {
                    Store.Instanca.messages.Add( m);
                    c.ReceiveMessage(new WCFChat.Message("Admin",m.from,"Trazeni korisnik trenutno nije online. Poruka je dodata u listu."));
                }
            }
        }
    }
}

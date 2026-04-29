using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFDecembar2019
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        public void registerName(string name)
        {
            IMessageCallback c = OperationContext.Current.GetCallbackChannel<IMessageCallback>();
            if (Store.Instanca.callbacks.Any(x => x.Key == name))
            {

                Store.Instanca.callbacks.Remove(Store.Instanca.callbacks.Where(x => x.Key == name).First().Key);
            }
            Store.Instanca.callbacks.Add(name, c);

        }

        public List<Message> requestMessageHistory(DateTime from, DateTime to, string name)
        {
            List<Message> ret = Store.Instanca.messages.Where(x => (x.time > from && x.time < to && (x.to=="SVI" || x.to==name))).ToList();
            return ret;
        }

        public void sendMessage(string from, string to, string text)
        {
            Message m = new Message(text, from, to);
            if (to != "SVI") {
                Store.Instanca.callbacks.Where(x => x.Key == to).First().Value.ReceiveMessage(m);
                Store.Instanca.messages.Add(m);
            }
            else
            {
                foreach(KeyValuePair<string,IMessageCallback> c in Store.Instanca.callbacks)
                {
                    Message msg = new Message(text, from, to);
                    c.Value.ReceiveMessage(msg);
                    Store.Instanca.messages.Add(msg);

                }
            }
        }
    }

}

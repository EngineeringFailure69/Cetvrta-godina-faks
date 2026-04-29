using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFChat
{
    public class Store
    {
        public List<string> usernames { get; set; }
        public List<Message> messages { get; set; }
        public Dictionary<string,IMessageCallback> callbacks { get; set; }
        private static object locker = true;
        private static Store _instanca = null;
        public static Store Instanca
        {
            get
            {
                lock (locker)
                {
                    if(_instanca==null)
                    {
                        _instanca = new Store();
                    }
                    return _instanca;
                }
            }
        }

        private Store()
        {
            usernames = new List<string>();
            usernames.Add("joka");
            usernames.Add("kica");
            usernames.Add("ceca");
            messages = new List<Message>();
            callbacks = new Dictionary<string, IMessageCallback>();
        }
    }
}
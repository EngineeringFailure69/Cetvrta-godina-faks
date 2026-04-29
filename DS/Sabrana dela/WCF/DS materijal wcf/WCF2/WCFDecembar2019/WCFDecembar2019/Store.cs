using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFDecembar2019
{
    public class Store
    {
        private static object locker = true;
        private static Store instanca = null;
        public static Store Instanca
        {
            get
            {
                lock (locker)
                {
                    if (instanca == null)
                        instanca = new Store();
                    return instanca;
                }
            }
        }

        public Dictionary<string, IMessageCallback> callbacks { get; set; }
        public List<Message> messages { get; set; }

        private Store()
        {
            callbacks = new Dictionary<string, IMessageCallback>();
            messages = new List<Message>();
        }
    }
}
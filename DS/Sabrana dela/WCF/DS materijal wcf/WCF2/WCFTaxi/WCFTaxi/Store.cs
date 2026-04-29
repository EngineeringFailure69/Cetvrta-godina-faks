using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFTaxi
{
    public class Store
    {
        public List<Taxi> cars { get; set; }
        public Dictionary<String,ITaxiCallback> callbacks { get; set; }
        public List<String> addresses { get; set; }
        private static object locker = true;
        private static Store _instance = null;
        public static Store Instanca
        {
            get
            {
                lock (locker)
                {
                    if(_instance==null)
                    {
                        _instance = new Store();
                        return _instance;
                    }
                    return _instance;
                }
            }
        }

        private Store()
        {
            cars = new List<Taxi>();
            cars.Add(new WCFTaxi.Taxi("1","",true));
            //cars.Add(new WCFTaxi.Taxi("2", "", true));
            //cars.Add(new WCFTaxi.Taxi("3", "", true));
            addresses = new List<String>(1);
            callbacks = new Dictionary<String, ITaxiCallback>();
        }
    }
}
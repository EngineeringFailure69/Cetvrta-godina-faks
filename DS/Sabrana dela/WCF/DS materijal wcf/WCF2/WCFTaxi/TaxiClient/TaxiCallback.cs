using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using TaxiClient.TaxiServis;

namespace TaxiClient
{
    public class TaxiCallback : TaxiServis.IService1Callback
    {
        public void notifyTaxi(string address)
        {
            Console.WriteLine(address);
        }

        public void notifyUser(string s)
        {
            Console.WriteLine(s);
        }
    }
}

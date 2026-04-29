using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTaxi
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service1 : IService1
    {
        public void RegisterTaxi(String id)
        {
            ITaxiCallback c = OperationContext.Current.GetCallbackChannel<ITaxiCallback>();
            if (Store.Instanca.cars.Any(x=>x.id==id))
            {
                if (!Store.Instanca.callbacks.ContainsValue(c))
                {
                    Store.Instanca.callbacks.Add(id, c);
                }
                c.notifyTaxi("Uskoro ce Vam biti dodeljena adresa.");
            }
            else
            {
                c.notifyTaxi("Ne postoji uneti id taksija.");
            }
        }

        public void RequestTaxi(string address)
        {
            ITaxiCallback c = OperationContext.Current.GetCallbackChannel<ITaxiCallback>();
            if (Store.Instanca.cars.Any(x => x.isFree == true) == true)//ovo ne valja jer se smatra u ovom slucaju da svi taksisti voze, treba da se resi nekako
            {
                Taxi t = Store.Instanca.cars.Where(x => x.isFree == true).First();
                Store.Instanca.cars.Remove(t);
                t.address = address;
                Store.Instanca.cars.Add(t);
                SetTaxiStatus(t.id,false);
                Store.Instanca.callbacks.Where(x => x.Key == t.id).First().Value.notifyTaxi("Idite na adresu: "+address);
                c.notifyUser("Vozilo je iza ugla, stize za minut.");
            }
            else if (Store.Instanca.addresses.Count < 1)
            {
                Store.Instanca.addresses.Add(address);
                c.notifyUser("Vozilo stize za 5 minuta");
            }
            else
            {
                c.notifyUser("Trenutno nista slobodno. Pozovite ponovo za 10 minuta.");
            }


        }

        public void SetTaxiStatus(String id, bool status)
        {
            if(status=true && Store.Instanca.addresses.Count > 0)
            {
                Store.Instanca.cars.Where(x => x.id == id).First().address = Store.Instanca.addresses.First();
                Store.Instanca.callbacks.Where(x => x.Key == id).First().Value.notifyTaxi(Store.Instanca.addresses.First());
                Store.Instanca.addresses.RemoveAt(0);
            }
            else
            {
              
                Store.Instanca.callbacks.Where(x => x.Key == id).First().Value.notifyTaxi("Trenutno nema adresa na cekanju. Pauza 5 minuta.");
                Store.Instanca.cars.Where(x => x.id == id).First().isFree = status;
                
            }
        }
    }
}

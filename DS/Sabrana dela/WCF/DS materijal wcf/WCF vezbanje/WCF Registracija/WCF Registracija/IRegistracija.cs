using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Registracija
{
    [ServiceContract]
    public interface IRegistracija
    {
        [OperationContract]
        void Add(Vozilo vozilo, Vozac vozac);
        [OperationContract]
        List<Vozac> VratiVozace(string model);
        [OperationContract]
        List<Vozilo> VratiVozila(Vozac v);
        [OperationContract]
        Dictionary<Vozac, List<Vozilo>> VratiSve();
        
    }


    [DataContract]
    public class Vozilo
    {
        [DataMember]
        public string Marka { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Tip { get; set; }

    }

    [DataContract]
    public class Vozac
    {
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string JMBG { get; set; }
    }

}

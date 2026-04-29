using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _7.WCF__Dec_2018
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRegistracija
    {
        [OperationContract]
        void dodajRegistraciju(Vlasnik vlasnik,Vozilo vozilo);
        [OperationContract]
        List<Vozilo> vratiVozilaVlasnika(Vlasnik v);
        [OperationContract]
        List<Vlasnik> posedujeVozilo(String model);
        [OperationContract]
        Dictionary<Vlasnik, List<Vozilo>> vratiRegistracije();
    }

    [DataContract]
    public class Vlasnik
    {
        [DataMember]
        public String Ime { get; set; }
        [DataMember]
        public String Prezime { get; set; }
        [DataMember]
        public String JMBG { get; set; }
    }
    [DataContract]
    public class Vozilo
    {
        [DataMember]
        public String Model { get; set; }
        [DataMember]
        public String Marka { get; set; }
        [DataMember]
        public String Boja { get; set; }
    }

}

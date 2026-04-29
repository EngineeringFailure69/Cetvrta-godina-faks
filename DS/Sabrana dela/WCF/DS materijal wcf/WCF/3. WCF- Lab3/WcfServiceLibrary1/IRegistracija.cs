using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _3.WCF__Lab3
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRegistracija
    {
        [OperationContract]
        void dodajRegistraciju(Vlasnik vlasnik, Vozilo vozilo);
        [OperationContract]
        List<Vozilo> vratiVozilaVlasnike(Vlasnik vlasnik);
        [OperationContract]
        List<Vlasnik> posedujeModel(String model);
        [OperationContract]
        Dictionary<Vlasnik, List<Vozilo>> vratiRegistracije();

    }
    [DataContract]
    public class Vlasnik
    {
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public string JMBG { get; set; }
    }

    [DataContract]
    public class Vozilo
    {
        [DataMember]
        public string Marka { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Boja { get; set; }
    }
}

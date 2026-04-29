using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Z3_Registracija
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRegistracija
    {
        [OperationContract]
        void DodajRegistraciju(Vlasnik vlasnik, Vozilo vozilo);
        [OperationContract]
        List<Vozilo> VratiVozilaVlasnika(Vlasnik vlasnik);
        [OperationContract]
        List<Vlasnik> PosedujeModel(String model);
        [OperationContract]
        List<Vozilo> vratiVozila();
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Z3_Registracija.ContractType".
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
        public Vlasnik Vlasnik { get; set; }
        [DataMember]
        public string Marka { get; set; }
        [DataMember]
        public string Model { get; set; }
        [DataMember]
        public string Boja { get; set; }
    }
}

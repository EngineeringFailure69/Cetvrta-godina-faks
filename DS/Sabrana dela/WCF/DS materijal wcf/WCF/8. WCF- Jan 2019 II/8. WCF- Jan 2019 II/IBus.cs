using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _8.WCF__Jan_2019_II
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IBus
    {
        [OperationContract]
        void RegistrujLiniju(String sifra, List<Stanica> linije);
        [OperationContract]
        List<String> LinijeNaStanice(String stanica);
        [OperationContract]
        List<String> OdDo(String s1, String s2);
        [OperationContract]
        List<Stanica> vratiStanice(String sifra, String sta);
    }

    [DataContract]
    public class Stanica {
        [DataMember]
        public String Ime { get; set; }
        [DataMember]
        public DateTime Vreme { get; set; }
    }

}

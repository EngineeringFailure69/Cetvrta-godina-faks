using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _5.WCF__Dec_2019
{
    [ServiceContract]
    public interface IBus
    {
        [OperationContract]
        void RegistrujLiniju(int sifra, Dictionary<String, DateTime> stanice);
        [OperationContract]
        List<int> vratiLinije(string stanica);
        [OperationContract]
        List<int> vratiLinijeKojeStaju(string stanica,string staje);
        [OperationContract]
        Dictionary<String, DateTime> vratiStanice(int kod, string stanica);

    }


    [DataContract]
    public class Linija
    {
        [DataMember]
        public int Sifra { get; set; }
        [DataMember]
        public Dictionary<String,DateTime> Stanice { get; set; }
    }
}

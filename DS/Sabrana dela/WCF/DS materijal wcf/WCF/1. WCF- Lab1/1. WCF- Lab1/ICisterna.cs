using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _1.WCF__Lab1
{
    [ServiceContract]
    public interface ICisterna
    {
        [OperationContract]
        void dodajMaterijal(string naziv, float v, float ro);
        [OperationContract]
        void ispustiZapreminu(float v);
        [OperationContract]
        Stanje trenutnoZauzece();
        [OperationContract]
        List<string> vratiPromene();


    }
    [DataContract]
    public class Stanje
    {
        [DataMember]
        public float V { get; set; }
        [DataMember]
        public float Ro { get; set; }
    }
    
}

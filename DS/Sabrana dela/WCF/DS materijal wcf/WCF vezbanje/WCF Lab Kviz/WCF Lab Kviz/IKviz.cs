using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_Lab_Kviz
{
    [ServiceContract]
    public interface IKviz
    {
        [OperationContract]
        void Inicijalizuj(int id);
        [OperationContract]
        int VratiBrojPoena(int id);
        [OperationContract]
        Pitanje VratiPitanje(int id);
        [OperationContract]
        void Odgovor(int id,char odgovor);
        // TODO: Add your service operations here
    }

    [DataContract]
    public class Pitanje
    {
        [DataMember]
        public string PostavkaPitanja { get; set; }
        [DataMember]
         public string A { get; set; }
        [DataMember]
         public string B { get; set; }
        [DataMember]
         public string C { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab_Z1_Cisterna
{
    [ServiceContract]
    public interface ICisterna
    {
        [OperationContract]
        void DodajMateriju(string naziv, float v, float ro);
        [OperationContract]
        void Ispusti(float v);
        [OperationContract]
        Stanje GetStanje();
        [OperationContract]
        List<String> GetPromene();
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

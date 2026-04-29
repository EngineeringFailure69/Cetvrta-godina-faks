using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFTaxi
{
    [Serializable]
    [DataContract]
    public class Taxi
    {

        [DataMember]
        public String id { get; set; }

        [DataMember]
        public String address { get; set; }

        [DataMember]
        public bool isFree { get; set; }

        public Taxi(String i,String a, bool f)
        {
            id = i;
            address = a;
            isFree = f;
        }
    }
}
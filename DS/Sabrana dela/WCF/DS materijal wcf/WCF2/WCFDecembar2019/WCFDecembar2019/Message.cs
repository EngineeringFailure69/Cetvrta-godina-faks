using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFDecembar2019
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember]
        public string text { get; set; }

        [DataMember]
        public string from { get; set; }

        [DataMember]
        public string to { get; set; }

        [DataMember]
        public DateTime time { get; set; }

        public Message(string t, string fr, string towho)
        {
            text = t;
            from = t;
            to = towho;
            time = DateTime.Now;
        }
    }
}
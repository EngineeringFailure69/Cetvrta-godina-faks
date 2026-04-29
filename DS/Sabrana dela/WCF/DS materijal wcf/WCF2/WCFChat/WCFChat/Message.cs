using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace WCFChat
{
    [Serializable]
    [DataContract]
    public class Message
    {
        [DataMember]
        public string from { get; set; }

        [DataMember]
        public string to { get; set; }

        [DataMember]
        public string text { get; set; }

        [DataMember]
        public DateTime time { get; set; }

        public Message(string f,string t, string m)
        {
            from = f;
            to = t;
            text = m;
            time = DateTime.Now;
        }
    }
}
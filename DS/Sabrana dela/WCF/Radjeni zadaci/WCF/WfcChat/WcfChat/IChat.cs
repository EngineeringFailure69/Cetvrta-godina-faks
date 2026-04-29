using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfChat
{
    [ServiceContract(CallbackContract =typeof(IChatCallback),SessionMode =SessionMode.Required)]
    public interface IChat
    {
        [OperationContract]
        void ClockIn(string user);

        [OperationContract]
        bool SendMessage(ChatMessage message);
    }

    
    [DataContract]
    public class ChatMessage
    {
        [DataMember]
        public string From { get; set; }

        [DataMember]
        public string To { get; set; }

        [DataMember]
        public string Text { get; set; }
    }
}

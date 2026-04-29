using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFChat
{
    [ServiceContract(Namespace = "http://WCFChat.Service1", SessionMode = SessionMode.Required,
                 CallbackContract = typeof(IMessageCallback))]
    public interface IService1
    {

        [OperationContract]
        bool Login(string username);

        [OperationContract]
        bool Logout(string username);

        [OperationContract(IsOneWay = true)]
        void SendMessage(string from, string to, string text);

        [OperationContract]
        List<Message> ReadNew(string username);


    }

    
}

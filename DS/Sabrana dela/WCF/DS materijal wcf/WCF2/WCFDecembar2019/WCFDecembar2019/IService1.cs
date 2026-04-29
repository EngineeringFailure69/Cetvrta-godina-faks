using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFDecembar2019
{
    [ServiceContract(Namespace="http://WCFDecembar2019.Service1", SessionMode =SessionMode.Required,
        CallbackContract = typeof(IMessageCallback))]
    public interface IService1
    {

        [OperationContract(IsOneWay = true)]
        void registerName(string name);

        [OperationContract(IsOneWay = true)]
        void sendMessage(string from, string to, string text);

        [OperationContract]
        List<Message> requestMessageHistory(DateTime from, DateTime to, string name);
        
    }

    
}

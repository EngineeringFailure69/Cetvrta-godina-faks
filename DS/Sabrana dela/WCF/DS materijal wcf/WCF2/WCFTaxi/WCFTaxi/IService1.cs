using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFTaxi
{
    [ServiceContract(Namespace = "http://WXFTaxi.Service1", SessionMode = SessionMode.Required,
                 CallbackContract = typeof(ITaxiCallback))]
    public interface IService1
    {
        [OperationContract(IsOneWay = true)]
        void RequestTaxi(String address);

        [OperationContract(IsOneWay = true)]
        void SetTaxiStatus(String id, bool status);

        [OperationContract(IsOneWay = true)]
        void RegisterTaxi(String id);

    }

    
}

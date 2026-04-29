using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFTaxi
{
    public interface ITaxiCallback
    {
        [OperationContract(IsOneWay = true)]
        void notifyTaxi(String address);

        [OperationContract(IsOneWay = true)]
        void notifyUser(String s);
    }
}

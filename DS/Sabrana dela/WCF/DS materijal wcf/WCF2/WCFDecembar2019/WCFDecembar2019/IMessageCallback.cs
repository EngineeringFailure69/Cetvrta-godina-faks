using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WCFDecembar2019
{
    public interface IMessageCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(Message m);
    }
}

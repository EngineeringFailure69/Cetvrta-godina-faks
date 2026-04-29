using System.ServiceModel;

namespace WcfChat
{
    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void ReceiveMessage(ChatMessage message);
    }
}
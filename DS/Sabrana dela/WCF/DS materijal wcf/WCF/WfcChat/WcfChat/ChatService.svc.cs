using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfChat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class ChatService : IChat
    {
        Dictionary<string, List<IChatCallback>> users = new Dictionary<string, List<IChatCallback>>();

        public void ClockIn(string user)
        {
            if (!users.ContainsKey(user))
                users.Add(user, new List<IChatCallback>());
            users[user].Add(OperationContext.Current.GetCallbackChannel<IChatCallback>());
            //OperationContext.Current.Channel.Closing += Channel_Closing;
        }

        //private void Channel_Closing(object sender, EventArgs e)
        //{
            
        //}

        public bool SendMessage(ChatMessage message)
        {
            if (!users.ContainsKey(message.To))
                return false;

            users[message.To].ForEach(x => x.ReceiveMessage(message));

            return true;
        }
    }
}

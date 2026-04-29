using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klijent.Chat;

namespace Klijent
{
    class MessageCallback : Chat.IService1Callback
    {
        public void ReceiveMessage(Message m)
        {
            Console.WriteLine(m.from+": "+m.text+"\n"+m.time.ToString());
        }
    }
}

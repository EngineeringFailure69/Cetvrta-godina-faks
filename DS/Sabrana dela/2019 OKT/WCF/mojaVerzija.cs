[ServiceContract]
public interface IChatService{
    [OperationContract(IsOneWay=true)]
    void SendMessage(ChatMessage msg);
    [OperationContract(IsOneWay=true)]
    List<ChatMessage> ReadNew(string username);
}

[DataContract]
public class ChatMessage{
    [DataMember]
    public string To{get; set;}
    [DataMember]
    public string From{get; set;}
    [DataMember]
    public string Msg{get; set;}
    [DataMember]
    public bool Seen{get; set;}
    [DataMember]
    public DateTime Time{get; set;} 
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)]
public class ChatService : IChatService{
    Dictionary<string, List<ChatMessage>> messages = new Dictionary<string, List<ChatMessage>>();

    public void SendMessage(ChatMessage msg){
        msg.Sent = DateTime.Now;
        msg.Seen = false;

        if(string.Equals(msg.to, "SVI")){
            foreach(List<ChatMessage> msgs in messages.Values){
               msgs.Add(msg);
            }
        }else{
            messages[msg.To] = msg;
        }
            
    }

    public List<ChatMessage> ReadNew(string username){
        List<ChatMessage> msgs = new List<ChatMessage>();
        foreach(ChatMessage msg in msgs){
            if(msg.Seen==false){
                msg.Seen = true;
                msgs.Add(msg);
            }
        }
        return msgs;
    }
}

public class User{
    static void Main(){
        ChatServiceClient proxy = new ChatServiceClient();

        ChatMessage m = new ChatMessage{
            From = "Ja";
            To = "Ti";
            Msg = "Poruka";
        }

        proxy.SendMessage(m);

        List<ChatMessage> msgs = proxy.ReadNew();
        foreach(ChatMessage msg in poruke)
            Console.WriteLine($"{msg.from}");
    }
}

<configuration>
    <system.serviceModel>
        <services>
            <service name="ChatApp.ChatService">
                <endpoint binding="BasicHttpBinding"
                          contract="IChatService"
                />
            </service>
        </service>
    </system.serviceModel>
</configuration>


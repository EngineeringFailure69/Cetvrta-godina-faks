[ServiceContract]
public interface IChatService{
    [OperationContract(IsOneWay=true)]
    void SendMessage(ChatMessage msg);
    [OperationContract]
    List<ChatMessage> ReadNew(string username);
}

[DataContract]
public class ChatMessage{
    [DataMember] 
    public string To{get;set;}
    [DataMember]
    public string From{get; set;}
    [DataMember]
    public string Msg{get; set;}
    [DataMember]
    public bool Seen{get; set;}
    [DataMember]
    public DateTime Sent{get; set;}
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Signle)]
public class ChatService : IChatService{
    Dictionary<string, List<ChatMessage>> messages= new Dictionary<string, List<ChatMessage>>();


    public void SendMessage(ChatMessage msg){
        msg.Sent = DateTime.Now;
        msg.Seen = false;

        if(string.Equals(msg.To, "svi")){
            foreach(List<ChatMessage> msgs in messagess){
                msgs.Add(msg);
            }
        }
        else if(messages.ContainsKey(msg.To))
            messages[msg.To].Add(msg);
        else{
            List<ChatMessage> msgs = new List<ChatMessage>();
            msgs.Add(msg);

            messages.Add(msg.To, msgs);
        }  
    } 

    public List<ChatMessage> ReadNew(string user){
        List<ChatMessage> notSeen = new List<ChatMessage>();
        foreach(ChatMessage msg in messages[user]){
            if(msg.Seen==false){
                msg.Seen=true;
                notSeen.Add(msg);
            }
        }
        return notSeen;
    } 
}

public class User{
    static void Main(){
        ChatServiceClient proxy = new ChatServiceClient();

        ChatMessage m = new ChatMessage(){
            From = "Ja",
            To="Ti",
            Msg="Poruka"
        };

        proxy.SendMessage(m);

        List<ChatMessage> poruke = proxy.ReadNew(nadimak);
        foreach(ChatMessage msg in poruke)
        Console.WriteLine($"Poslao {msg.From}: {msg.Msg");

    }
}

<configuraton>
    <system.serviceModel>
        <services>
            <service name="ChatApp.ChatService">
                <endpoint binding="BasicHttpBinding"
                    contract="IChatService"
                />
            </serivec>
        </services>
    </system.serviceModel>
</configuration>    
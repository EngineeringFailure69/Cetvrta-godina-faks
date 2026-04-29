[ServiceContract]
public interface IChatService{
    [OperationContract(IsOneWay=true)]
    void SendMessage(ChatMessage msg);

    [OperationContract]
    List<ChatMessage> ReadNew();
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
    public DateTime Time{get; set;}
    [DataMember]
    public boole Seen{get; set;}
}

public class ChatService : IChatService{
    Dictionary<string, List<ChatMessage>> messages = new Dictionary<string, List<ChatMessage>>();
    
    void SendMessage(ChatMessage msg){
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

    List<ChatMessage> ReadNew(){
        List<ChatMessage> newMessages= new List<ChatMessage>();

    }
}


public class User{
    static void Main(){
        ChatServiceClient proxy = new ChatServiceClient();

        ChatMessage m = new ChatMessage(){
            To = "Ti",
            From = "Me",
            MSG = "Poruka"
        };
    }
}

<configuration>
    <system.ServiceModel>
        <services>
            <service name="App.ChatService">
                <endpoint binding="BasicHttpBinding"
                          contract="IChatService"
                />
            </service>
        </services>
    </system.ServiceModel>
</configuration>
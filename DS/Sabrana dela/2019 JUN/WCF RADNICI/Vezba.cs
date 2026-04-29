[ServiceContract(CallbackContract=typeof(ICallback))]
public interface IEvidentionService{
    [OperationCotract(IsOneWay=true)]
    void Login(string name);
    [OperationContract(IsOneWay=true)]
    void Logout(string name);
    [OperationContext(IsOneWay=true)]
    List<WorkSession> getSessions(string name);
}

[DataContract]
public class WorkSession{
    [DataMember]
    public DateTime Login{get; set;}
    [DataMember]
    public DateTime Logout{get; set;}
}

public interface ICallback{
    [OperationContract(IsOneWay=true)]
    void LoginError();
    [OperationContract(IsOneWay=true)]
    void LogoutError();
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)]
public class EvidentionService : IEvidentionService{
    Dictionary<string, List<WorkSession>> sessions = new Dictionary<string, <WorkSession>>();
    Dictionary<string, WorkSession> dailySessions = new Dictionary<string, WorkSession>();
    Dictionary<string, ICallback> clbs = new Dictionary<string, ICallback>();

    public void Login(string name){
        if(dailySessions.ContainsKey(name)){
            clbs[name].LoginError();
        }else{
            WorkSession w = new WorkSession{
                Login = DateTime.Now()
            };

            dailySessions.Add(name, w);

            if(!clbs.ContainsKey(name))
                clbs.Add(name, OperationContext.Context.GetCallbackChannel<ICallback>());
        }
    }

    public void Logout(string name){
        if(!dailySessions.ContainsKey(name))
            clbs[name].LogoutError();
        else{
            WorkSession w = dailySessions[name];
            w.Logout = DateTime.Now();

            if(sessions.ContainsKey(name)){
                dailySessions[name].Add(w);
            }else{
                List<WorkSession> wrokerSessions= new List<WorkSession>();
                wrokerSessions.Add(w);
                sessions.Add(wrokerSessions);
            }

            dailySessions.Remove(name);
        }
    }

    public List<WorkSession> getSessions(string name){
        return sessions[name];
    }
}

public class Callback : ICallback{
    void LoginError(){
        Console.WriteLine("LoginError");
    }

    void LogoutError(){
        Console.WriteLine("LogoutError");
    }
}

public class User{
    public static void Main(){
        Callback clb = new Callback();
        InstanceContext i = new InstanceContext(clb);
        EvidentionServiceClient proxy = new EvidentionServiceClient(i);

        proxy.Login("Ja");
        proxy.Login("Ja");
        proxy.Logout("Ja");
    }
}

<configuration>
    <system.serviceModel>
        <services>
            <service name="JobApp.EvidentionService">
                <endpoint binding="WSDualHttpBinding"
                          contract="IEvidentionService"
                />
            </service>
        </services>
    </system.serviceModel>
</configuration>
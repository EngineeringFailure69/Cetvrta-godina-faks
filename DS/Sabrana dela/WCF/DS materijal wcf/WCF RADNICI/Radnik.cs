[ServiceContract(CallbackContract=typeof(ICallback))]
public interface ILogService{
    [OperationContract(IsOneWay=true)]
    void Login(string name);
    [OperationContract(IsOneWay=true)]
    void Logout(string name);
    [OperationContract]
    List<WorkSession> getSessions(string name);
}

[DataContract]
public class WorkSession{
    [DataMember]
    public DateTime Login{get;set;}
    [DataMember]
    public DateTime Logout{get;set;}
}

public interface ICallback{
    [OperationContract(IsOneWay=true)]
    void LogoutError(string name);
    [OperationContract(IsOneWay=true)]
    void LoginError(string name);
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)]
public class LogService : ILogService{
    Dictionary<string,List<WorkSession>> radnici;
    Dictionary<string,WorkSession> dnevniRadnici;
    Dictionary<string, ICallback> clbs;
    

    public LogService(){
        radnici=new Dictionary<string,List<WorkSession>>();
        dnevniRadnici=new Dictionary<string,WorkSession>();
        clbs = new Dictionary<string, ICallback>();
    }
    
    public void Login(string name){
        if(dnevniRadnici.ContainsKey(name)){
            clbs[name].LoginError(); 
        }else{
            WorkSession session=new WorkSession(){
                Login = DateTime.Now()
            };
            dnevniRadnici.Add(name,session);

            if(!clbs.ContainsKey(name))
               clbs.Add(name,OperationContext.Context.GetCallbackChannel<ICallback>());
        }
    }

    public void Logout(string name){
        if(dnevniRadnici.ContainsKey(name)){
            if(radnici.ContainsKey(name))
            {
                radnici[name].Add(dnevniRadnici[name]);
            }else{
                List<WorkSession> sessions=new List<WorkSession>();
                sessions.Add(dnevniRadnici[name]);
                radnici.Add(name,sessions);
            }

            dnevniRadnici.Remove(name);
        }else
           clbs[name].LogoutError(name);
    }

    public List<WorkSession> getSessions(string name){
        return radnici[name];
    }

}


public class Callback : ICallback{

   public void LogoutError(string name){
      Console.WriteLine(name);
   }
   public void LoginError(string name){
      Console.WriteLine(name);
   }
}

public class User{
    public static void Main(){
        Callback clb=new Callback();
        InstanceContext i=new InstanceContext(clb);
        LogServiceClient proxy=new LogServiceClient(i);
        ....

    }
}

//webConfig
<configuration>
 <system.serviceModel>
    <services>
       <service name="LogApp.LogService">
            <endpoint   binding="WSDualHttpBinding"
                        contract="ILogService"
            />
        </service>
    </services>     
 </system.serviceModel>
<configuration>
               
                
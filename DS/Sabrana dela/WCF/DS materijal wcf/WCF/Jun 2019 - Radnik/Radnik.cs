[ServiceContract(CallbackContract=typeof(ISalterCallback))]
public interface ISalter{

    [OperationContract(IsOneWay=true)]
    void Login(string ime);

    [OperationContrart(IsOneWay=true)]
    void Logout(string ime);

    [OperationContract(IsOneWay=true)]
    List<Log> ProvedenoVreme(string ime);

}

[DataContract]
public class Log
{
    [DataMember]
    public DateTime Timestamp{get; set;}
    [DataMember]
    public string Type { get; set; }
    [DataMember]
    public bool IsSuccessful { get; set; }

}

public interface ISalterCallback
{
    [OperationContract(IsOneWay=true)]
    void NeuspeloLogovanje();
    [OperationContract(IsOneWay=true)]
    void GreskaPriLogoutu();

}

[ServiceBehaviour(InstanceContexMode=InstanceContextMode.PerSession)]
public class Salter : ISalter
{
    Dictionary<string,List<Log>> logs = new Dictionary<string, List<Log>>();
    Dictionary<string, ISalterCallback> clbs = new Dictionary<string, ISalterCallback>();

    public void Login(string ime)
    {
        if(logs[ime].Count == 0 && !clbs.ContainsKey(ime)) //kreiram log i clbs kad se prvi put loguje
        {
            clbs.Add(ime,OperationContext.Current.GetCallbackChannel<ISalterCallback>());
            Log log = new Log()
            {
                Timestamp = DateTime.Now,
                Type = "Login",
                IsSuccessful = true
            };
            logs[ime].Add(log);
        }

        Log last = logs[ime][logs[ime].Count -1];
        
        if((last.Type == "Login" && last.IsSuccessful) || 
        (last.Type == "Logout" && !last.IsSuccessful))
        {
            Log log = new Log()
            {
                Timestamp = DateTime.Now,
                Type = "Login",
                IsSuccessful = false
            };
            logs[ime].Add(log);
            clbs[ime].NeuspeloLogovanje();
        }
        else
        {
            Log log = new Log()
            {
                Timestamp = DateTime.Now,
                Type = "Login",
                IsSuccessful = true
            };
            logs[ime].Add(log); 
        } 
    }

    public void Logout(string ime)
    {
        if(logs[ime].Count == 0 || !clbs.ContainsKey(ime))
        {
            clbs.Add(ime,OperationContext.Context.GetCallbackChannel<ISalterCallback>());
            clbs[ime].GreskaPriLogoutu(); 
        }

        Log last = logs[ime][logs[ime].Count -1];
        
        if((last.Type == "Logout" && last.IsSuccessful) || 
        (last.Type == "Login" && !last.IsSuccessful))
        {
            Log log = new Log()
            {
                Timestamp = DateTime.Now,
                Type = "Logout",
                IsSuccessful = false
            };
            logs[ime].Add(log);
            clbs[ime].GreskaPriLogoutu();
        }
        else
        {
            Log log = new Log()
            {
                Timestamp = DateTime.Now,
                Type = "Logout",
                IsSuccessful = true
            };
            logs[ime].Add(log); 
        } 

    }

    public List<Log> ProvedenoVreme(string ime)
    {
        List<Log> scfulLogs = new List<Log>();
        foreach(Log log in logs[ime])
        {
            if(log.IsSuccessful)
                scfulLogs.Add(log);
        }

        return scfulLogs;
    }
}

/******KLIJENT*******/
public class SalterCallback : ISalterCallback
{
    public  void NeuspeloLogovanje()
    {
        Console.WriteLine("Neuspesan Login!");
    }
    void GreskaPriLogoutu()
    {
        Console.WriteLine("Neuspesan Logout!");
    }

}


public class Client
{
    static void main(string[] args)
    {
        SalterCallback clb = new SalterCallback();
        InstanceContext i=new InstanceContext(clb);
        SalterClient proxy = new SalterClient(i);

        proxy.Login("Voja");
        proxy.Logout("Voja");
        proxy.Logout("Voja");
        proxy.Logout("Voja");
        proxy.Login("Voja");
        proxy.Logout("Voja");
        proxy.Login("Voja");
        proxy.Login("Voja");
        proxy.Logout("Voja");

        List<Log> logovi = proxy.ProvedenoVreme("Voja");
        Log last = logovi[logovi.Count-1];
        
        for(int i=0; i<logovi.Count;i++)
        {
            if(!(i==logovi.Count-1 && logovi[i].Type=="Login"))
                Console.WriteLine($"{logovi[i].Type}: {logovi[i].Timestamp}");
        }
    }
}

// <configuraton>
//     <system.serviceModel>
//         <services>
//             <service name="Radnik.Salter">
//                 <endpoint binding="BasicHttpBinding"
//                     contract="ISalter"
//                 />
//             </serivec>
//         </services>
//     </system.serviceModel>
// </configuration>  



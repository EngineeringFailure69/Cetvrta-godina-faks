[ServiceContract]
public interface IChatApp{

    [OperationContrart(IsOneWay=true)]
    void PosaljiPoruku(Poruka poruka);
    [OperationContract(IsOneWay=true)]
    List<Poruka> ReadNew();
}

[DataContract]
public class Poruka{

    [DataMember]
    public string From{get; set;}
    [DataMember]
    public string To { get; set; }
    [DataMember]
    public DateTime Vreme { get; set; }
    [DataMember]
    public string Sadrzaj { get; set; }
    [DataMember]
    public bool Vidjena { get; set; }
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)]
public class ChatApp : IChatApp{

    Dictionary<string, List<Poruka>> chats = new Dictionary<string, List<Poruka>>();

    public void PosaljiPoruku(Poruka poruka)
    {
        if(p.To == "SVI")
        {
            foreach(List<Poruka> chat in chats.Values)
            {
                chat.Add(poruka);
            }
        }
        else if(chats.ContainsKey(poruka.To))
        {
            chats[poruka.To].Add(poruka);
        }
        else
        {
            List<Poruka> poruke = new List<Poruka>();
            poruke.Add(poruka);
            chats.Add(poruka.To,poruke);
        }
    }

    public List<Poruka> ReadNew(string klijent)
    {
        List<Poruka> notSeen = new List<Poruka>();
        foreach(Poruka p in chats[klijent])
        {
            if(p.Vidjena==false)
            {
                p.Vidjena=true;
                notSeen.Add(p);
            }
        }
        return notSeen;
    }

}

public class User
{
    static void Main()
    {
        ChatAppClient proxy = new ChatAppClient();

        Poruka p = new Poruka()
        {
            From = "Pera",
            To="Zika",
            Sadrzaj = "Bla bla bla",
            Vreme = DateTime.Now,
            Vidjena = false
        };

        proxy.PosaljiPoruku(p);

        List<Poruka> poruke = proxy.ReadNew("Zika");
        foreach(Poruka p in poruke)
            Console.WriteLine($"Poslao {p.From} u {p.Vreme} sadrzaj: {p.Sadrzaj}");
    }
}
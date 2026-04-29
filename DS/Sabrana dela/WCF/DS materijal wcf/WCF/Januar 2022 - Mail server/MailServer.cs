[ServiceContract(CallbackContract=typeof(IMailCallback))]
public interface IMailServer
{
    [OperationContract(IsOneWay=true)]
    void Login(string nadimak);
    [OperationContract(IsOneWay=true)]
    void PosaljiPoruku(string from,List<string> to,string title,string text);
    [OperationContract(IsOneWay=true)]
    void GetMsgByPosiljalac(string nadimak);
    [OperationContract(IsOneWay=true)]
    void GetMsgByNaslov(string nadimak);
}

[DataContract]
public class Poruka
{
    [DataMember]
    public string From { get; set; }
    [DataMember]
    public DateTime Time { get; set; }
    [DataMember]
    public List<string> To { get; set; }
    [DataMember]
    public string Title { get; set; }
    [DataMember]
    public string Text { get; set; }
    [DataMember]
    public bool Seen { get; set; }
}

public interface IMailCallback
{
    [OperationContract(IsOneWay=true)]
    void Notify(Poruka poruka);
}

[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)] //ako se opet log sa istim nadimkom nova i sve ostale sesije i dalje vaze
public class MailServer : IMailServer
{
    Dictionary<string, List<Poruka>> users = new Dictionary<string, List<Poruka>>();
    Dictionary<string, IMailCallback> clbs = new Dictionary<string, IMailCallback>();

    public void Login(string nadimak)
    {
        if(!users.ContainsKey(nadimak))
        {
            List<Poruka> p = new List<Poruka>();
            users.Add(nadimak,p);
        }

        clbs.Add(nadimak,OperationContext.Contex.GetCallbackChannel<IMailCallback>());
        
        if(users[nadimak].Count != 0)
        {
            print("Imate sledecu neprocitane poruke");
            foreach(Poruka poruka in users[nadimak])
            {
                if(poruka.Seen == false)
                {
                    print("Poslao " + poruka.From + " Vreme: " + poruka.Time + " Naslov: " + poruka.Title + " Sadrzaj: " + poruka.Text);
                    foreach(string s in poruka.To)
                        print("Poslao " + s);
                    poruka.Seen = true;
                }
            }
        }
    }

    public void PosaljiPoruku(string from,List<string> to,string title,string text)
    {
        //ne ispitujem nista pretpostavljam da primaoci vec postoje
        foreach(string primalac in to)
        {
            if(clbs.ContainsKey(primalac)) // ako imamo clb za primaoca to znaci da je AKTIVAN
            {
                Poruka poruka = new Poruka()
                {
                    From = from,
                    To = to,
                    Title = title,
                    Text = text,
                    Time = DateTime.Now(),
                    Seen = true
                };

                users[primalac].Add(poruka);
                clbs[primalac].Notify(poruka); // stize obavestenje aktivnom korisniku o poruci koju je primio
            }
            else
            {
                Poruka poruka = new Poruka()
                {
                    From = from,
                    To = to,
                    Title = title,
                    Text = text,
                    Time = DateTime.Now(),
                    Seen = false
                };

                users[primalac].Add(poruka); // neaktivnom ne zovem clb jer ne treba da bude obavesten
            }
        }
    }
    public  List<Poruka> GetMsgByPosiljalac(string nadimak, string posiljalac) // nadimak je za user-a koji poziva f-ju
    {
        if(users.ContainsKey(nadimak))
        {
            List<Poruka> filteredList = new List<Poruka>();
            foreach(Poruka p in users[nadimak])
            {
                if(p.From.Contains(posiljalac))
                    filteredList.Add(p);
            }
            return filteredList;
        }
        else
        {
            print("User sa nadimkom " + nadimak + " ne postoji");
        }
        return null;
    }

    public  List<Poruka> GetMsgByNaslov(string nadimak, string naslov) // nadimak je za user-a koji poziva f-ju
    {
        if(users.ContainsKey(nadimak))
        {
            List<Poruka> filteredList = new List<Poruka>();
            foreach(Poruka p in users[nadimak])
            {
                if(p.Title.Contains(naslov))
                    filteredList.Add(p);
            }
            return filteredList;
        }
        else
        {
            print("User sa nadimkom " + nadimak + " ne postoji");
        }
        return null;
    }


    /******KLIJENT*******/
    public class MailCallback : IMailCallback
    {
        public void Notify(Poruka poruka)
        {
            print("Primili ste poruku:\n");
            print("Poslao " + poruka.From + " Vreme" + poruka.Time + " Naslov" + poruka.Title + " Sadrzaj" + poruka.Text);
            foreach(string s in poruka.To)
                print("Poslao " + s);
        }
    }

    public class Client
    {
        static void main(string[] args)
        {
            MailCallback clb = new MailCallback();
            InstanceContext i=new InstanceContext(clb);
            MailServerClient proxy = new MailServerClient();

            proxy.Login("Mile");
            
            List<string> to = {"Pera","Slavica"};
            proxy.PosaljiPoruku("Mile",to,"Sastanak","Vidimo se veceras.");
            List<Poruka> porukeByNaslov = proxy.GetMsgByNaslov("Mile","Sas");
            //print
            List<Poruka> porukeByPosiljalac = proxy.GetMsgByPosiljalac("Mile","Sla");
            //print
        }
    }

}
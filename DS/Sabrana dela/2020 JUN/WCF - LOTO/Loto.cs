/***************************SERVER***************************/
[ServiceContract(CallbackContract=typeof(ILotoCallback))]
public interface ILotoService{
    [OperationContract(IsOneWay=true)]
    void DodajKombinaciju(Kombinacija k);
    [OperationContract(IsOneWay=true)]
    void ObrisiKombinaciju(Kombinacija k);
}

[DataContract]
public class Kombinacija{
    [DataMember]
    public string Nadimak{get;set;}
    [DataMember]
    public List<int> Brojevi{get;set;}
}

public interface ILotoCallback{
    [OperationContract(IsOneWay=true)]
    void IzvuceniBroj(int x);
    [OperationContract(IsOneWay=true)]
    void Dobitnici(int petica,int sestica,int sedmica);
    [OperationContract(IsOneWay=true)]
    void Cestitka(string cestitka);
}


[ServiceBehaviour(InstanceContextMode=InstanceContextMode.Single)]
public class LotoService : ILotoService{
    bool izvlacenje=false;
    Dictionary<string,List<Kombinacija>> kombinacije=new Dictionary<string,List<Kombinacija>>();
    Dictionary<string,ILotoCallback> clbs=new Dictionary<string,ILotoCallback>();
    List<int> izvuceniBrojevi=new List<int>();
    
    public void DodajKombinaciju(Kombinacija k){
        if(izvlacenje==false){
            if(kombinacije.ContainsKey(k.Nadimak))
                   kombinacije[k.Nadimak].Add(k);
            else{
                List<Kombinacija> komb=new List<Kombinacija>();
                komb.Add(k);
                kombinacije.Add(k.Nadimak,komb);
            }
            if(!clbs.ContainsKey(k.Nadimak))
                 clbs.Add(k.Nadimak,OperationContext.Context.GetCallbackChannel<ILotoCallback>());
        }   
    }
    public void ObrisiKombinaciju(Kombinacija k){
     if(izvlacenje==false){
        if(kombinacije.ContainsKey(k.Nadimak)){
            for(int i=0;i<kombinacije[k.Nadimak].Count;i++){
                Kombinacija item=kombinacije[k.Nadimak][i];
                 int hits=0;
                foreach(int broj in item.Brojevi){
                    foreach(int broj2 in k.Brojevi){
                        if(broj==broj2)
                          hits++;
                    }
                }
                if(hits==7)
                 kombinacije[k.Nadimak].RemoveAt(i);
            }
            if(kombinacije[k.Nadimak].Count==0){
                kombinacije.Remove(k.Nadimak);
                clbs.Remove(k.Nadimak);
            }
        }    
    }}
   public void izvuceniBroj(int x){
        izvuceniBrojevi.Add(x);
        foreach(string key in clbs.Keys)
           clbs[key].IzvuceniBroj(x);
        
        int petice=0,sestice=0,sedimce=0;
        if(izvuceniBrojevi.Count==7){
            List<string> winners=new List<String>();
            foreach(string key in kombinacije.Keys){
                foreach(Kombinacija kombinacija in kombinacije[key]){
                    int hits=0;
                    foreach(int broj in kombinacija.Brojevi){
                       foreach(int broj2 in izvuceniBrojevi){
                           if(broj==broj2)
                           hits++;
                       }
                    }
                    if(hits==7){
                          sedimce++;
                          winners.Add(key);
                    }
                    else if(hits==6)
                      sestice++;
                    else if(hits==5)
                      petice++;
                }
            }
            foreach(var key in clbs.Keys)
                 clbs[key].Dobitnici(petice,sestice,sedimce);
            foreach(string user in winners)
                  clbs[user].Cestitka();
        }
   }

}
/***************************KLIJENT***************************/
public class LotoCallback : ILotoCallback{
    public void IzvuceniBroj(int x){
        Console.WriteLine($"Izvucen je broj {x}");
    }
    public void Dobitnici(int petica,int sestica,int sedmica){
        Console.WriteLine($"Broj izvucenih petica je: {petica}, broj izvucenih sestica je {sestica} i broj izvucenih sedmica je {sedmica}");
    }
    public void Cestitka(string cestitka){
        Console.WriteLine(cestitka);
    }
}

public class User{
    static void Main(string[] args){
        LotoCallback clb=new LotoCallback();
        IntsanceContext i=new InstanceContext(clb);
        LotoserviceClient proxy=new LotoServiceClient(i);

        Kombinacija k=new Kombinacija();
        k.Name="ja";
        List<int>br ....
        k.Brojevi=br;

        proxy.DodajKombinaciju(k);
       ....
    }
}
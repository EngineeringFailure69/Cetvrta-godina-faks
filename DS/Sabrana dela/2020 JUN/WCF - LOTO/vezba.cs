[ServiceContract(CallbackContract=typeof(ILotoCallback))]
public interface ILotoService{
    [OperationContract(IsOneWay=true)]
    void Dodaj(Kombinacija k);
    [OperationContract(IsOneWay=true)]
    void Obrisi(Kombinacija k);
}

[DataContract]
public class Kombinacija{
    [DataMember]
    public string Nadimak{get; set;}
    [DataMember]
    public List<int> Brojevi{get; set;}
}

public interface ILotoCallback{
    [OperationContract]
    void Dobitnici(int petice, int sestice, int sedmice);
    [OperationContract]
    void IzvuceniBroj(int broj);
    [OperationContract]
    void Cestitka(string cestitka);
}

[ServiceBehaviour(InstanceContext=InstanceContext.Single)]
public class LotoService{
    Dictionary<string, ILotoCallback> clbs = new Dictionary<string, ILotoCallback>();
    Dictionary<string, List<Kombinacija>> kombinacije = new Dictionary<string, List<Kombinacija>>(); 
    List<int> izvuceniBrojevi = new List<int>();
    bool izvlacenje=false;

    public void izvlacenje(int broj){
        izvlacenje = true;
        izvuceniBrojevi.Add(broj);

        foreach(ILotoCallback clb in clbs)
            clb.IzvuceniBroj(broj);

        if(izvuceniBrojevi.Count==7){
            int petice=0, sestice=0, sedmice=0;
            List<string> winners = new List<string>();
            foreach(List<Kombinacija> kombs in kombinacije.Values){
                foreach(Kombinacija k in kombs){
                    int hits=0;
                    
                    foreach(int br in k.Brojevi){
                        foreach(int br2 in izvuceniBrojevi)
                            if(br==br2)
                                hits++;
                    }

                    if(hits==5)
                        petice++;
                    else if(hits==6)
                        sestice++;
                    else if(hits==7){
                        sedmice++;
                        winners.Add(k.Nadimak);
                    }
                }
            }

            foreach(ILotoCallback clb in clbs){
                clbs.Dobitnici(petice, sestice, sedmice);
            }

            foreach(string winner in winners){
                clbs[winner].Cestitka("bravo");
            }

        }
    }
}

public class LotoCallback : ILotoCallback{
    void Dobitnici(int petice, int sestice, int sedmice){

    }
    [OperationContract]
    void IzvuceniBroj(int broj){

    }
    [OperationContract]
    void Cestitka(string cestitka){

    }
}

public class User{
    static void Main(){
        

    }
}
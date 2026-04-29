[ServiceContract(CallbackContract=typeof(IGameCallback))]
public interface IGameService
{
    [OperationContract(IsOneWay=true)]
    void ZapocniIgru(string nadimak);
    [OperationContract(IsOneWay=true)]
    void BaciKocku(string nadimak);
    [OperationContract(IsOneWay=true)]
    void Statistika();
}

[DataContract]
public class Game
{
    List<Igrac> igraci;
    int[,] tabla= new int[10,10];
    public Game()
    {
        for(int i=0;i<10;i++)
            for(int j=0;j<10;j++)
                tabla[i][j]=0; //prazno polje
        igraci = new List<Igrac>();
    }   

    [Datamember]
    public List<Igrac> Igraci { get{return igraci;} set{igraci.Add(value);}}
    [Datamember]
    public tabla Tabla { get{return tabla;} set{return;}}
}

[DataContract]
public class Igrac
{
    [Datamember]
    public string Nadimak { get; set; }
    [Datamember]
    public int Pojeo { get; set; }
    [Datamember]
    public int Pojeden { get; set; }
}

public interface IGameCallback
{
    [OperationContract(IsOneWay=true)]
    void Promena(int[10,10] tabla);
}

[ServiceBehaviour(InstanceContextModel=InstanceContextMode.PerSession)]
public class GameService: IGameService
{
    List<Game> games = new List<Game>();
}
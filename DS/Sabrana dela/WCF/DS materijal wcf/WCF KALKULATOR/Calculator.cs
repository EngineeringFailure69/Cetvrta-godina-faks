/***************************SERVER***************************/
[ServiceContract(SessionMode=SessionMode.Required, CallbackContract=typeof(ICallback))]
public interface ICalculator {
    [OperationContract(IsOneWay=true)]
    void Resetuj();
    [OperationContract(IsOneWay=true)]
    void Dodaj(double x);
    [OperationContract(IsOneWay=true)]
    void Oduzmi(double x);
    [OperationContract(IsOneWay=true)]
    void Pomnozi(double x);
    [OperationContract(IsOneWay=true)]
    void Podeli(double x);
}

public interface ICallback{
    [OperationContract(IsOneWay=true)]
    void Obavesti(double rez,string izraz);
}
    
//[ServiceBehaviour...] se pise jedino ako treba samo jedna instanca 
//inace se ne pise nista 
public class CalculatorService : ICalculator{
    double rezultat=0;
    string izraz="";
    ICallback clb;

    public CalculatorService(){
        clb=OperationContext.Context.GetCallbackChannel<ICallback>();
    }

    public void Resetuj(){
        rezultal=0;
        izraz=string.Empty;
        clb.Obavesti(rezultat,izraz);
    }

    public void Dodaj(double x){
        if(string.IsNullOrEmpty(izraz))
            izraz=$"{x}";
        else
            izraz+=$"+ {x} ";
        rezultat+=x;
        clb.Obavesti(rezultat,izraz);
    }
     public void Oduzmi(double x){
        izraz+=$"-{x}";
        rezultat-=x;
        clb.Obavesti(rezultat,izraz);
    }
    public void Pomnozi(double x){
        izraz+=$"*{x}";
        rezultat*=x;
        clb.Obavesti(rezultat,izraz);
    }
    public void Podeli(double x){
        izraz+=$"/{x}";
        rezultat/=x;
        clb.Obavesti(rezultat,izraz);
    }
}
/***************************KLIJENT***************************/

public class Callback : ICallback{

    public void Obavesti(double rez,string izraz){
        Console.WriteLine($"{rez}"+izraz);
    }
}


public class User{
    static void Main(){
        Callback clb=new Callback();
        InstanceContext i=new InstanceContext(clb);
        CalculatorServiceClient proxy=new CalculatorServiceClient(i);
        proxy.Dodaj(2);
        proxy.Dodaj(3);
        proxy.Oduzmi(5);
        ..

    }
}

/***************************WEB CONFIG***************************/
<configuration>
  <system.serviceModel>
    <services>
      <service name="CalcApp.CalculatorService">
        <endpoint binding="WSDualHttpBinding"
                  contract="ICalculator"
        />
      </service>
    </services>
  </system.serviceModel>
</configuration>  


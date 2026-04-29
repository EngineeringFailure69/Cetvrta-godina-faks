[ServiceContract(SessionMode=SessionMode.Required, CallbackContract=typeof(ICallback))]
public interface ICalculatorService{
    [OperationContract(IsOneWay=true)]
    void Dodaj(double vrednost);
    [OperationContract(IsOneWay=true)]
    void Oduzmi(double vrednost);
    [OperationContract(IsOneWay=true)]
    void Obrisi();
}

public interface ICallback{
    [OperationContract(IsOneWay=true)]
    void Obavesti(double rez ,string izraz);
}

public class CalculatorService : ICalculatorService{
    ICallback clb;
    double rez=0;
    string izraz="";

    public CalculatorService(){
        clb = OperationContext.Context.GetCallbackChannel<ICallback>();
    }

    public void Dodaj(double vrednost){
        rez+=vrednost;

        if(string.equals("", izraz))
            izraz+=vrednost;
        else
            izraz+=$"+ {vrednost}";

        clb.Obavesti(rez, izraz);    
    }

    public void Oduzmi(double vrednost){

    }

    public void Obrisi(){

    }
}

public class Callback : ICallback{
    public void Obavesti(double rez ,string izraz){
        Consol.WriteLine(rez + " " + izraz);
    }
}

public class Klijent{
    Callback clb = new Callback();
    InstanceContext i = new InstanceContext(i);
    CalculatorServiceClient proxy = new CalculatorService(i);

    proxy.Dodaj(5);
}

<configuration>
    <system.ServiceModel>
        <services>
            <service name="App.CalcService">
                <endpoint contract="ICalculatorService"
                          endpoint="WSDualHttpBinding"
                />
            </service>
        </services>
    </system.ServiceModel>
</configuration>

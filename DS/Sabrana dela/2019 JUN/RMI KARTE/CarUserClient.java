import java.rmi.RemoteException;

public class CarUserClient {
    String address;
    CarManager m;

    public CarUserClient(String address){
        this.address=address;
        m=Naming.lookup("rmi//:locashost:1099/CarManager");
    }

    public void requestCar() throws RemoteException{
       if(m.requestCar(address)){
           System.out.println("Kola ce biti poslata na vasu adresu");
       }else{
        System.out.println("Velika guzva probajte kasnije");
       }
    }


    public static void main() throws RemoteException{
        CarUserClient c=new CarUserClient("mojaAdresa");
        c.requestCar();
    }
    
}

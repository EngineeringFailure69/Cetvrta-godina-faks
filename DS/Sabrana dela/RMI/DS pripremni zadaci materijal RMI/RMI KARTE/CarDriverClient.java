import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class CarDriverClient {
    Car myCar;
    CarCallback clb;
    CarManager m;

    public CarDriverClient() {
           m=Naming.lookup("rmi//:localhost:1099/CarManager");
           clb=new CarCallbackImpl();
           myCar=m.addCar(clb);
    }
    
    public void notifyDriver(String address){
        myCar.isFree=false;
        myCar.address=address;
        //vozi kola
    }
    public class CarCallbackImpl extends UnicastRemoteObject implements CarCallback{

        @Override
        public void notifyCar(String address) throws RemoteException {
            notifyDriver(address);
        }

    }

    public static void main(){
        new CarDriverClient();
    }
    
}

import java.rmi.Naming;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class CarDriverClient {
    Car car;
    ICarCallback clb;
    ICarManager iCarManager;

    public CarDriverClient(){
        iCarManager = Naming.lookup("rmi://localhost:1099/ICarManager");
        clb = new CarCallback();
        car = iCarManager.registerDriver(clb);
    }

    public void startDriving(String address){
        car.address = address;
        car.isFree = false;
        //vozi kola
    }

    public class CarCallback extends UnicastRemoteObject implements ICarCallback {

        public CarCallback() throws RemoteException{
            super();
        }

        public void notifyCar(String address) throws RemoteException{
            startDriving(address);
        }
    }
}

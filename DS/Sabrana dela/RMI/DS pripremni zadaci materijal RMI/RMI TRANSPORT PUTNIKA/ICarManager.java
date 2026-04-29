import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ICarManager extends Remote {
    boolean requestCar(String address) throws RemoteException;
    Car registerDriver(ICarCallback driver) throws RemoteException;
}

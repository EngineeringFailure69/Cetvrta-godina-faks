import java.rmi.RemoteException;

public interface ITaxiCallback extends Remote{
    void notifyTaxi(String address) throws RemoteException;
}
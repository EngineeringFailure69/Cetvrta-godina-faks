import java.rmi.RemoteException;

public interface IReservationCallback extends Remote {
    void notify(String msg) throws RemoteException;
}

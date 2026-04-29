import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IReservation extends Remote {
    public String getInfo() throws RemoteException;
}

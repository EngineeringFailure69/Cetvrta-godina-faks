import java.rmi.RemoteException;

public interface ITicketCallback extends Remote {
    void notify(String msg) throws RemoteException;
}

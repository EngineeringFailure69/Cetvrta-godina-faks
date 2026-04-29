import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ICitalac extends Remote {
    void iznajmiKnjigu(IKnjiga knjiga) throws RemoteException;
    String pribaviInformacije()throws RemoteException;
}

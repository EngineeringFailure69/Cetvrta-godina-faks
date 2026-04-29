import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IKnjiga extends Remote{
    public String pribaviInformacije() throws RemoteException;

    public boolean ispitajSlobodnost() throws RemoteException;

    public String pribaviNaziv() throws RemoteException;

    void izmeniSlobodnost() throws RemoteException;
}

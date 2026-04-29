import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface IBiblioteka extends Remote {

    List<IKnjiga> pribaviKnjige() throws RemoteException;

    boolean proveriDostupnost(String naziv) throws RemoteException;

    void iznajmiKnjigu(String ime, String prezime, String naziv) throws RemoteException;

}

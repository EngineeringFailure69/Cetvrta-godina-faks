import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;

public class Server {
    public static void main(String [] args) throws RemoteException, MalformedURLException {
        try{
            IBiblioteka biblioteka = new Biblioteka();
            Naming.rebind("rmi://localhost:1099/Biblioteka", biblioteka);
            System.out.println("Server osluskuje...");
        } catch (RemoteException e) {
            e.printStackTrace();
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }
    }
}

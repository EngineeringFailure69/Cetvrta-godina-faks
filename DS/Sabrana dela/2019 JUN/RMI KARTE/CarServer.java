import java.rmi.RemoteException;

public class CarServer {
    public static void main() throws RemoteException{
          CarManager m=(CarManager)new CarManagerImpl();
          LocalRegistry.createRegistry(1099);
          Naming.rebind("rmi://localhost:1099/CarManager",m);
          System.in.read();
    }
    
}

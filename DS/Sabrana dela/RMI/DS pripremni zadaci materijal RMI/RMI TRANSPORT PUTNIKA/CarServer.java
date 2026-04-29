import java.rmi.Naming;

public class CarServer {
    public static void main(String args[]){
        ICarManager m = new CarManager();
        LocalRegistry.createRegistry(1099);
        Naming.bind("rmi://localhost:1099/ICarManager", m);
        System.in.read();
    }
}

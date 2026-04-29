import java.rmi.Naming;

public class Server {
    public static void main(){
        IGymReservationManager m = (IGymReservationManager) new GymReservationManager();
        LocalRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost:1099/GymReservationManager", m);
        System.in.read();
    }
}

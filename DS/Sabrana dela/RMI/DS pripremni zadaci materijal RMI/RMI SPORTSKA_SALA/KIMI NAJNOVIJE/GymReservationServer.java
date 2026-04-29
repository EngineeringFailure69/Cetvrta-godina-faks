public class GymReservationServer{
    public static void main(){
        IGymReservationManager m=new GymReservationManagerImpl();
        LocalRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost:1099/Hym",m);
        System.in.read();
    }
}
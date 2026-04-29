import java.io.IOException;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.RemoteException;

public class Server {
    public static void main(String[] args) throws RemoteException, MalformedURLException {
        try {
            IReservationMenager reservationMenager = new ReservationMenager(5, 5);
            Naming.rebind("rmi://localhost:1099/ReservationMenager", reservationMenager);
        } catch (RemoteException e) {
            System.err.println("Failure during object export to RMI: " + e);
        } catch (MalformedURLException e) {
            System.err.println("Failure during Name registration: " + e);
        }
        System.out.println("Server pokrenut.");

        try {
            System.in.read();
        } catch (
                IOException e) {
            e.printStackTrace();
        }
    }
}
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.rmi.Naming;
import java.net.MalformedURLException;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;

public class Klijent {

    public static void main(String[] args) throws RemoteException, NotBoundException, MalformedURLException {
        IReservationMenager reservationMenager = (IReservationMenager) Naming.lookup("rmi://localhost:1099/ReservationMenager");
        System.out.println("Klijent pokrenut.");

        IReservation reservation = reservationMenager.makeReservation(1, 1, 2);
        IReservation reservation1 = reservationMenager.makeReservation(1, 1, 1);

        if (reservation != null)
         System.out.println(reservation.getInfo());
        else
            System.out.println("This reservation has already been created!");

        if(reservation1 != null)
            System.out.println(reservation.getInfo());
        else
            System.out.println("This reservation has already been created!");


    }
}

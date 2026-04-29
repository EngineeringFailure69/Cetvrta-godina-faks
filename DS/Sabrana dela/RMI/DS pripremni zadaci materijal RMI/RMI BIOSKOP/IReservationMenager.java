import java.rmi.Remote;
import java.rmi.RemoteException;

public interface IReservationMenager extends Remote {
    IReservation makeReservation(int seatRow, int seatNum, int numSeats) throws RemoteException;

    void cancelReservation(String id) throws RemoteException;
}

import java.rmi.RemoteException;

public interface IGymReservationManager extends Remote {
    Reservation makeReservation(int day, int month, int hour, int numHours) throws RemoteException;
    Reservation extendReservation(Reservation res, int numExtraHours) throws RemoteException;
    void cancelReservation(Reservation res) throws RemoteException;
    void addCallback(IReservationCallback clb, int reservationId) throws RemoteException;
}

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.List;

public class ReservationMenager extends UnicastRemoteObject implements IReservationMenager {
    Seat[][] seatMatrix;
    List<Reservation> reservations;

    public ReservationMenager(int rows, int seats) throws RemoteException {
        super();
        reservations = new ArrayList<Reservation>();
        seatMatrix = new Seat[rows][seats];
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 5; j++)
                seatMatrix[i][j] = new Seat(i, j);
    }

    @Override
    public IReservation makeReservation(int seatRow, int seatNum, int numSeats) throws RemoteException {
        System.out.println("Uso sam u rezervacije!");
        for (int j = seatNum; j < seatNum + numSeats; j++) {
            if (!seatMatrix[seatRow][j].takeSeat())
                return null;
        }
        return new Reservation(seatNum, seatRow, numSeats);
    }

    @Override
    public void cancelReservation(String id) throws RemoteException {
        Reservation reservation = getReservation(id);
        for (int i = reservation.seatNum; i < reservation.seatNum + reservation.numSeats; i++)
            seatMatrix[reservation.seatRow][i].freeSeat();
    }

    private Reservation getReservation(String id) {
        for (int i = 0; i < reservations.size(); i++) {
            if (reservations.get(i).id == id)
                return reservations.get(i);
        }
        return null;
    }
}

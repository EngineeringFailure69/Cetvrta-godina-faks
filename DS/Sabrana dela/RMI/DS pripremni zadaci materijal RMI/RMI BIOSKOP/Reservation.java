import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.UUID;

public class Reservation extends UnicastRemoteObject implements IReservation {
    int seatNum, seatRow, numSeats;
    String id;

    public Reservation() throws RemoteException {
        super();
    }

    public Reservation(int sNum, int sRow, int numOfSeats) throws RemoteException {
        super();
        id = UUID.randomUUID().toString();
        seatNum = sNum;
        seatRow = sRow;
        numSeats = numOfSeats;
    }

    public Reservation(String _id, int sNum, int sRow, int numOfSeats) throws RemoteException {
        super();
        id = _id;
        seatNum = sNum;
        seatRow = sRow;
        numSeats = numOfSeats;
    }

    public String getInfo() {
        String info = "Successful reservation at row " + Integer.toString(seatRow) +
                ", seat " + Integer.toString(seatNum) + "." + "\n" +
                "Number of seats: " + Integer.toString(numSeats);
        return  info;
    }


}

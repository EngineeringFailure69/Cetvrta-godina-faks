import java.rmi.*;

public class ReservationImpl extends UnicastRemoteObject implements Reservation
{
	String id;
	int seatRow, seatNum, numSeats;
	
	public ReservationImpl() throws Remote
}
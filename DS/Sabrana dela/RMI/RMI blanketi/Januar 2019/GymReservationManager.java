import java.rmi.*;

public interface GymReservationManager extends Remote
{
	Reservation makeReservation(int day, int month, int hour, int numHours) throws RemoteException;
	Reservation extendReservation(Reservation reservation, int numExtraHours) throws RemoteException;
	void cancelReservation(Reservation reservation) throws RemoteException;
	void addReservationCallback(int callbackId, ReservationCallback reservationCallback) throws RemoteException;
}
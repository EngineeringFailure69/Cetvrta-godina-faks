import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.rmi.*;

public class GymReservationManagerImpl extends UnicastRemoteObject implements GymReservationManager
{
	private static int reservationId = 0;
	ArrayList<Reservation> listaRezervacija;
	Map<Integer, ReservationCallback> listaCallbackova;
	
	public GymReservationManagerImpl() throws RemoteException
	{
		listaRezervacija = new ArrayList<Reservation>();
		listaCallbackova = new HashMap<Integer, ReservationCallback>();
	}
	
	public void addReservationCallback(int callbackId, ReservationCallback reservationCallback) throws RemoteException
	{
		listaCallbackova.put(callbackId, reservationCallback);
	}
	
	public Reservation makeReservation(int day, int month, int hour, int numHours) throws RemoteException
	{	
		if((hour + numHours) > 24)
		{
			return null;
		}
		
		for(Reservation res : listaRezervacija)
		{
			if(res.month == month && res.day == day)
				return null;
		}
		
		Reservation reservation = new Reservation(day, month, hour, numHours);
		reservation.id = reservationId++;
		
		listaRezervacija.add(reservation);
		return reservation;
	}
	
	public Reservation extendReservation(Reservation reservation, int numExtraHours) throws RemoteException
	{
		for(Reservation res : listaRezervacija)
		{
			if(reservation.hour + reservation.numHours + numExtraHours <= 24 && res.id == reservation.id)
			{
				res.numHours += numExtraHours;
				listaCallbackova.get(res.id).notify("Produzena");
				return res;
			}
			else if(reservation.hour + reservation.numHours + numExtraHours > 24 && res.id == reservation.id)
				listaCallbackova.get(res.id).notify("Nije produzena");
		}
		return null;
	}
	
	public void cancelReservation(Reservation reservation) throws RemoteException
	{
		for(int i = 0; i < listaRezervacija.size(); i++)
		{
			Reservation r = listaRezervacija.get(i);
			if(r.id == reservation.id)
			{
				listaRezervacija.remove(i);
				
				listaCallbackova.get(r.id).notify("Otkazana");
				listaCallbackova.remove(r.id);
				break;
			}
		}
	}
}
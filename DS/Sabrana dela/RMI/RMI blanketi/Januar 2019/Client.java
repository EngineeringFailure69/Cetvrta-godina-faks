import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;

public class Client
{
	Reservation reservation;
	GymReservationManager manager;
	ReservationCallback callback;
	
	public Client()
	{
		try
		{
			manager = (GymReservationManager) Naming.lookup("rmi://localhost:1099/GymReservationManagerService");
			callback = new ReservationCallbackImpl();
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
		catch(MalformedURLException e)
		{
			e.printStackTrace();
		}
		catch(NotBoundException e)
		{
			e.printStackTrace();
		}
	}
	
	public void rezervisi(int day, int month, int hour, int numHours)
	{
		try
		{
			reservation = manager.makeReservation(day, month, hour, numHours);
			if(reservation == null)
				System.out.println("Neuspesna rezervacija");
			else
			{
				System.out.println("Uspesna rezervacija");
				manager.addReservationCallback(reservation.id, callback);
			}
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public void extend(int numExtraHours)
	{
		try
		{
			Reservation rezervacija = manager.extendReservation(reservation, numExtraHours);
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public void cancel()
	{
		try
		{
			manager.cancelReservation(reservation);
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public class ReservationCallbackImpl extends UnicastRemoteObject implements ReservationCallback
	{
		public ReservationCallbackImpl() throws RemoteException
		{
			super();
		}
		public void notify(String akcija) throws RemoteException
		{
			if(akcija.equals("Rezervisano"))
				System.out.println("Uspesno rezervisano");
			else if(akcija.equals("Nije rezervisano"))
				System.out.println("Rezervacija nije rezervisana");
			else if(akcija.equals("Produzena"))
				System.out.println("Uspesno produzena rezervacija");
			else if(akcija.equals("Nije produzena"))
				System.out.println("Rezervacija nije produzena");
			else if(akcija.equals("Otkazana"))
				System.out.println("Uspesno otkazana rezervacija");
		}
	}
	
	public static void main(String[] args)
	{
		Client klijent = new Client();
		klijent.rezervisi(15, 12, 10, 10);
		klijent.extend(2);
		klijent.cancel();
	}
}
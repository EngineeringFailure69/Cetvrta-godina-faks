import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.registry.*; 
import java.net.MalformedURLException;

public class Server
{
	public static void main(String[] args)
	{
		try
		{
			LocateRegistry.createRegistry(1099);
			GymReservationManager gym = new GymReservationManagerImpl();
			Naming.rebind("rmi://localhost:1099/GymReservationManagerService", gym);
			System.out.println("Server startovan!\n");
		}
		catch(RemoteException e)
		{
			System.out.println("Greska tokom kreiranja RMI objekta: " + e);
		}
		catch(MalformedURLException e)
		{
			System.out.println("Greska tokom registracije RMI objekta: " + e);
		}
	}
}
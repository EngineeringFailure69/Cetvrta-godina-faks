import java.rmi.*;
import java.rmi.registry.*;
import java.net.MalformedURLException;

public class Server 
{
	public static void main(String[] args)
	{
		try
		{
			LocateRegistry.createRegistry(1099);
			HotelManager hotel = new HotelManagerImpl();
			Naming.rebind("rmi://localhost:1099/HotelService", hotel);
			System.out.println("Server started!\n");
		}
		catch(RemoteException e)
		{
			System.out.println("Failure during RMI object creation: " + e);
		}
		catch(MalformedURLException e)
		{
			System.out.println("Failure during Name registration: " + e);
		}
	}
}
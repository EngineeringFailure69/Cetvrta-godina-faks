import java.rmi.*;
import java.rmi.server.*;
import java.net.*;
import java.rmi.registry.*;

public class Server
{
	public static void main(String[] args)
	{
		try
		{
			LocateRegistry.createRegistry(1099);
			Hotel hotel = new HotelImpl();
			Naming.rebind("rmi://localhost:1099/HotelService", hotel);
			System.out.println("Server startovan");
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
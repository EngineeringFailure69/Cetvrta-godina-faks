import java.rmi.*;
import java.rmi.server.*;
import java.rmi.registry.*;
import java.net.*;

public class Server
{
	public static void main(String[] args)
	{
		try
		{
			LocateRegistry.createRegistry(1099);
			Licitacija licitacija  = new LicitacijaImpl();
			Naming.rebind("rmi://localhost:1099/LicitacijaService", licitacija);
			System.out.println("Server startovan!");
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
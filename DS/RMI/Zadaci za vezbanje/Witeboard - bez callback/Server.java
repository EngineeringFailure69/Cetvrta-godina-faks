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
			WhiteboardManager tabla = new WhiteboardManagerImpl();
			Naming.rebind("rmi://localhost:1099/WhiteboardService", tabla);
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
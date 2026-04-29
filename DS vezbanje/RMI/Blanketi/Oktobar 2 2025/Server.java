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
			MQTTBroker broker = new MQTTBrokerImpl();
			Naming.rebind("rmi://localhost:1099/MQTTBrokerService", broker);
			System.out.println("Server registrovan!");
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
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
			System.out.println("Java RMI registry kreiran.");
		}
		catch(RemoteException e)
		{
			System.out.println("Java RMI registry vec postoji.");
		}
		
		try
		{
			MQTTBroker broker = new MQTTBrokerImpl();
			Naming.rebind("rmi://localhost/MQTTBrokerService", broker);
			System.out.println("Server pokrenut...");
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
	}
}
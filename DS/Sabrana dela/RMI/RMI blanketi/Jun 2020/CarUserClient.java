import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;

public class CarUserClient
{
	String address;
	CarManager manager;
	
	public CarUserClient(String address)
	{
		try
		{
			this.address = address;
			manager = (CarManager) Naming.lookup("rmi://localhost:1099/CarManagerService");
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
	
	public void request()
	{
		try
		{
			boolean carRequest = manager.requestCar(address);
			if(carRequest)
			{
				System.out.println("Kola ce biti poslata na vasu adresu");
			}
			else
			{
				System.out.println("Velika guzva probajte kasnije");
			}
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args)
	{
		CarUserClient client = new CarUserClient("address");
		client.request();
	}
}
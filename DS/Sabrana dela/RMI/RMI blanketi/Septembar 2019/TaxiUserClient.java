import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;

public class TaxiUserClient
{
	TaxiManager taxiManager;
	
	public TaxiUserClient()
	{
		try
		{
			taxiManager = (TaxiManager) Naming.lookup("rmi://localhost:1099/TaxiManagerService");
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
	
	public void traziVoznju(String address)
	{
		try
		{
			boolean traziTaksi = taxiManager.requestTaxi(address);
			if(traziTaksi == true)
			{
				System.out.println("Poslato vozilo");
			}
			else
			{
				System.out.println("Pozovite kasnije");
			}
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args)
	{
		TaxiUserClient client  = new TaxiUserClient();
		client.traziVoznju("adresa");
	}
}
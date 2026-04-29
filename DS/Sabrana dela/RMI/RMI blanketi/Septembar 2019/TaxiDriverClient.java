import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;

public class TaxiDriverClient
{
	Taxi taxi;
	TaxiCallback taxiCallback;
	TaxiManager taxiManager;
	
	public TaxiDriverClient()
	{
		try
		{
			taxiManager = (TaxiManager) Naming.lookup("rmi://localhost:1099/TaxiManagerService");
			taxiCallback  = new TaxiCallbackImpl();
			taxi = taxiManager.addTaxiCallback(taxiCallback);
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
	
	public void zapocniVoznju(String address)
	{
		taxi.address = address;
		taxi.isFree  = false;
	}
	
	public class TaxiCallbackImpl extends UnicastRemoteObject implements TaxiCallback
	{
		public TaxiCallbackImpl() throws RemoteException
		{
			super();
		}
		public void notifyTaxi(String address) throws RemoteException
		{
			zapocniVoznju(address);
		}
	}
}
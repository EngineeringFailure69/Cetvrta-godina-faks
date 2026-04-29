import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;

public class CarDriverClient
{
	Car car;
	CarCallback callback;
	CarManager manager;
	
	public CarDriverClient()
	{
		try
		{
			manager = (CarManager) Naming.lookup("rmi://localhost:1099/CarManagerService");
			callback = new CarCallbackImpl();
			car = manager.registerDriver(callback);
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
	
	public void startDriving(String address)
	{
		car.address = address;
		car.isFree = false;
	}
	
	public class CarCallbackImpl extends UnicastRemoteObject implements CarCallback
	{
		public CarCallbackImpl() throws RemoteException
		{
			super();
		}
		
		public void notifyCar(String address) throws RemoteException
		{
			startDriving(address);
		}
	}
}
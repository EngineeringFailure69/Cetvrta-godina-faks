import java.rmi.*;
import java.util.*;
import java.rmi.server.*;
import java.net.*;

public class Client
{
	public static void main(String[] args)
	{
		try
		{
			Hotel manager = (Hotel) Naming.lookup("rmi://localhost:1099/HotelService");
			HotelCallback clb = new HotelCallbackImpl();
			
			Soba soba1 = new Soba(1000, 2, true);
			Soba soba2 = new Soba(2000, 1, true);
			Soba soba3 = new Soba(3000, 3, true);
			Soba soba4 = new Soba(5000, 1, true);
			Soba soba5 = new Soba(4000, 2, true);
			
			Putnik putnik = new Putnik("Lune", "Scekic", "1234345433134");
			
			manager.rezervisiSobu(soba1, clb, putnik);
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
	
	public static class HotelCallbackImpl extends UnicastRemoteObject implements HotelCallback
	{
		public HotelCallbackImpl() throws RemoteException
		{
			super();
		}
		public void notify(String rezultat) throws RemoteException
		{
			System.out.println("Soba " + rezultat);
		}
	}
}
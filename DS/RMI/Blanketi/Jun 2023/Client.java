import java.rmi.*;
import java.rmi.server.*;
import java.util.*;
import java.net.*;
import java.util.Random;

public class Client
{
	public static void main(String[] args)
	{
		try
		{
			Licitacija manager  = (Licitacija) Naming.lookup("rmi://localhost:1099/LicitacijaService");
			LicitacijaCallback clb = new LicitacijaCallbackImpl();
			Random random = new Random();
			int max = 3000, min  = 501;
			int novaCena = random.nextInt(max - min + 1) + min;
			manager.prijaviSeZaLicitaciju(1, clb);
			manager.licitiraj(1, novaCena);
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
	
	public static class LicitacijaCallbackImpl extends UnicastRemoteObject implements LicitacijaCallback
	{
		public LicitacijaCallbackImpl() throws RemoteException
		{
			super();
		}
		 public void notify(int id, int novaCena) throws RemoteException
		 {
			 System.out.println("Eksponat sa id vrednoscu: " + id + "\nIma novu cenu: " + novaCena + "\n");
		 }
	}
}
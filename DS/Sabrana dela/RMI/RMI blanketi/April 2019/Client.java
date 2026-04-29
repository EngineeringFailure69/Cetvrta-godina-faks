import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;
import java.util.*;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Client
{
	LotoManager manager;
	LotoCallback callback;
	Ticket listic;
	
	public Client()
	{
		try
		{
			callback = new LotoCallbackImpl();
			manager = (LotoManager) Naming.lookup("rmi://localhost:1099/LotoManagerService");
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
	
	public void igrajListic(Vector<Integer> brojevi)
	{
		try
		{
			listic = manager.playTicket(brojevi);
			if(listic == null)
				System.out.println("Listic je vec izvucen.");
			else
				manager.addCallback(listic.id, callback);
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public class LotoCallbackImpl extends UnicastRemoteObject implements LotoCallback
	{
		public LotoCallbackImpl() throws RemoteException
		{
			super();
		}
		public void winner() throws RemoteException
		{
			System.out.println("Cestitamo na pobedi!");
		}
		public void showAllWinners(Vector<Integer> pobednici) throws RemoteException
		{
			System.out.println("Svi pobednici: ");
			for(Integer i : pobednici)
				System.out.println(i + "\n");
		}
		public void youLost() throws RemoteException
		{
			System.out.println("Izgubili ste :(");
		}
	}
	
	public static void main(String[] args)
	{
		try
		{
			Vector<Integer> brojevi = new Vector<Integer>();
			while(brojevi.size() < 7){
				System.out.println("Unesite broj izmedju 7 i 39");
				BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
				int broj=Integer.parseInt(br.readLine());
				if(broj >= 7 && broj <= 39 && !brojevi.contains(broj))
				  brojevi.add(broj);
			}
			Client klijent = new Client();
			klijent.igrajListic(brojevi);
		}
		catch (IOException e) 
		{
			e.printStackTrace();
		}
	}
}
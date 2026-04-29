import java.rmi.*;
import java.util.*;
import java.rmi.server.*;
import java.lang.Math;
import java.util.Random;

public class LotoManagerImpl extends UnicastRemoteObject implements LotoManager
{
	private static int ticketId = 0;
	Map<Integer, LotoCallback> callbackovi;
	ArrayList<Ticket> listici;
	Vector<Integer> izvuceniBrojevi;
	boolean izvucenListic;
	
	public LotoManagerImpl() throws RemoteException
	{
		callbackovi = new HashMap<Integer, LotoCallback>();
		listici = new ArrayList<Ticket>();
		izvuceniBrojevi = new Vector<Integer>();
		izvucenListic = false;
	}
	
	public Ticket playTicket(Vector<Integer> numbers) throws RemoteException
	{
		if(izvucenListic)
			return null;
		Ticket listic = new Ticket();
		listic.id = ticketId++;
		listic.numbers = numbers;
		listici.add(listic);
		
		return listic;
	}
	
		
	public Vector<Integer> getWinners() throws RemoteException
	{
		Vector<Integer> pobednici = new Vector<Integer>();
		for(Ticket t : listici)
		{
			int brojPogodaka = t.brojPogodaka(izvuceniBrojevi);
			if(brojPogodaka == 7)
			{
				callbackovi.get(t.id).winner();
				pobednici.add(t.id);
			}
			else if(brojPogodaka >= 5)
				pobednici.add(t.id);
			else if(brojPogodaka < 5)
				callbackovi.get(t.id).youLost();
		}
		return pobednici;
	}
	
	public void drawNumbers() throws RemoteException
	{
		izvucenListic = true;
		int broj;
		while(izvuceniBrojevi.size()<7)
		{
			broj = (int)(Math.random()*32+7);
			if(!izvuceniBrojevi.contains(broj))
				izvuceniBrojevi.add(broj);
		}
		Vector<Integer> pobednici = getWinners();
		
		for(Ticket t : listici)
			callbackovi.get(t.id).showAllWinners(pobednici);
	}
	
		public void addCallback(int clbId, LotoCallback clb) throws RemoteException
	{
		callbackovi.put(clbId, clb);
		
		if(listici.size() == 1)
			drawNumbers();
	}
}
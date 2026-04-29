import java.rmi.*;
import java.rmi.server.*;
import java.util.*;
import java.util.ArrayList;

public class LicitacijaImpl extends UnicastRemoteObject implements Licitacija
{
	private Map<Integer, List<LicitacijaCallback>> licitacije;
	
	private Eksponat[] eksponati = 
	{
		new Eksponat(1, 500),
		new Eksponat(2, 1000),
		new Eksponat(3, 1500),
		new Eksponat(4, 2000)
	};
	
	public LicitacijaImpl() throws RemoteException
	{
		licitacije = new HashMap<Integer, List<LicitacijaCallback>>();
	}
	
	public void prijaviSeZaLicitaciju(int id, LicitacijaCallback callback) throws RemoteException
	{
		if(!licitacije.containsKey(id))
			for(int i=0; i<eksponati.length; i++)
				if(eksponati[i].id  == id)
					licitacije.put(id, new ArrayList<>());
		licitacije.get(id).add(callback);
		System.out.println("Prijavljen za eksponat: " + id);
	}
	
	public void licitiraj(int id, int novaCena) throws RemoteException
	{
		int ukupnaCena = 0;
		if(licitacije.containsKey(id))
			for(int i=0; i<eksponati.length; i++)
					if(eksponati[i].id == id)
					{
						if(novaCena > eksponati[i].cena)
						{
							eksponati[i].cena=novaCena;
							ukupnaCena = novaCena;	
						}
						else
							ukupnaCena =  eksponati[i].cena;
					}
		List<LicitacijaCallback> lista = licitacije.get(id);
		for(LicitacijaCallback cb : lista)
			cb.notify(id, ukupnaCena);
	}
}
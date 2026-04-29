import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class TaxiManagerImpl extends UnicastRemoteObject implements TaxiManager
{
	ArrayList<Taxi> listaSvihVozila;
	ArrayList<String> listaZahtevanihAdresaUReduCekanja;
	Map<Integer, TaxiCallback> taxiCallbackList;
	
	private static int globalniTaxiID =  0;
	int maksimalanBrojZahteva = 10;
	
	public TaxiManagerImpl() throws RemoteException
	{
		listaSvihVozila = new ArrayList<Taxi>();
		listaZahtevanihAdresaUReduCekanja = new ArrayList<String>();
		taxiCallbackList = new HashMap<Integer, TaxiCallback>();
	}
	
	public Taxi addTaxiCallback(TaxiCallback taxiCallback) throws RemoteException
	{
		Taxi taxi = new Taxi();
		taxi.id = globalniTaxiID++;
		listaSvihVozila.add(taxi);
		taxiCallbackList.put(taxi.id, taxiCallback);
		return taxi;
	}
	
	public boolean requestTaxi(String address) throws RemoteException
	{
		for(Taxi taxi : listaSvihVozila)
		{
			if(taxi.isFree == true)
			{
				taxi.isFree = false;
				taxiCallbackList.get(taxi.id).notifyTaxi(address);
				taxi.address = address;
				return true;
			}
		}
		if(maksimalanBrojZahteva > listaZahtevanihAdresaUReduCekanja.size())
		{
			listaZahtevanihAdresaUReduCekanja.add(address);
			return true;
		}
		return false;
	}
	
	public void setTaxiStatus(int id, boolean isFree) throws RemoteException
	{
		for(Taxi taxi : listaSvihVozila)
		{
			if(taxi.id == id)
				taxi.isFree = isFree;
		}
	}
}
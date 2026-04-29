import java.rmi.*;
import java.rmi.server.*;

public class HotelManagerImpl extends UnicastRemoteObject implements HotelManager
{
	private Soba[] sobe = {
		new SobaImpl(500, 3), 
		new SobaImpl(200, 4), 
		new SobaImpl(600, 5),
		new SobaImpl(100, 2)
	};
	
	public HotelManagerImpl() throws RemoteException
	{
		super();
	}
	
	public Soba nadjiSobu(int maxCena, int brojKreveta) throws RemoteException
	{
		int i = 0;
		while(i < sobe.length && !(sobe[i].vratiRezervisana() == false && sobe[i].vratiCenu() <= maxCena && sobe[i].vratiBrojKreveta() == brojKreveta)) i++;
		if(i < sobe.length) return (Soba) this.sobe[i];
		else return null;
	}
}
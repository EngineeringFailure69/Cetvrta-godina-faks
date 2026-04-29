import java.rmi.*;
import java.rmi.server.*;

public class SobaImpl extends UnicastRemoteObject implements Soba
{
	private boolean rezervisana;
	private int brojKreveta;
	private int cena;
	private Putnik putnik;
	
	public SobaImpl(int cena, int brojKreveta) throws RemoteException
	{
		this.cena = cena;
		this.brojKreveta = brojKreveta;
		rezervisana = false;
	}
	
	public int vratiCenu()
	{
		return cena;
	}
	
	public int vratiBrojKreveta()
	{
		return brojKreveta;
	}
	
	public boolean vratiRezervisana()
	{
		return rezervisana;
	}
	
	public void rezervacija(Putnik slepiPutnik)
	{
		rezervisana = true;
		putnik = slepiPutnik;
	}
}
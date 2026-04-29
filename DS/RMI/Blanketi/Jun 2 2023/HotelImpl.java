import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

public class HotelImpl extends UnicastRemoteObject implements Hotel
{
	
	public HotelImpl() throws RemoteException{}
	
	public void rezervisiSobu(Soba soba, HotelCallback callback, Putnik putnik) throws RemoteException
	{
		if(soba.raspolozivost == true)
		{
			soba.raspolozivost = false;
			putnik.soba = soba;
			callback.notify("uspesno rezervisana");
		}
		else
		{
			callback.notify("neuspesno rezervisana");
		}
	}
}
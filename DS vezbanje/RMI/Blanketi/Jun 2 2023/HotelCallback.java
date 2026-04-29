import java.rmi.*;

public interface HotelCallback extends Remote
{
	void notify(String rezultat) throws RemoteException;
}
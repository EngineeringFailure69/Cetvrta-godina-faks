import java.rmi.*;

public interface TaxiCallback extends Remote
{
	void notifyTaxi(String address) throws RemoteException;
}
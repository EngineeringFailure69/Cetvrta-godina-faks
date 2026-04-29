import java.rmi.*;

public interface TaxiManager extends Remote
{
	boolean requestTaxi(String address) throws RemoteException;
	void setTaxiStatus(int id, boolean isFree) throws RemoteException;
	Taxi addTaxiCallback(TaxiCallback taxiCallback) throws RemoteException;
}
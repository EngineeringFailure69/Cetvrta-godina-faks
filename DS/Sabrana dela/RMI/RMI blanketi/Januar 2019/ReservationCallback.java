import java.rmi.*;

public interface ReservationCallback extends Remote
{
	void notify(String akcija) throws RemoteException;
}
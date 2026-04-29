import java.rmi.*;

public interface CarCallback extends Remote
{
	void notifyCar(String address) throws RemoteException;
}
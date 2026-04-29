import java.rmi.*;

public interface LicitacijaCallback extends Remote
{
	void notify(int id, int cena) throws RemoteException;
}
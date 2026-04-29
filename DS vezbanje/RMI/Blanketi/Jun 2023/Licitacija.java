import java.rmi.*;

public interface Licitacija extends Remote
{
	void prijaviSeZaLicitaciju(int id, LicitacijaCallback callback) throws RemoteException;
	void licitiraj(int id, int novaCena) throws RemoteException;
}
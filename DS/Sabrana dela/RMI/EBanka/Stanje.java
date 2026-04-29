package eBanka;
import java.rmi.*;

public interface Stanje extends Remote{

	public float vratiDinarskiIznos() throws RemoteException;
	public float vratiDevizniIznos() throws RemoteException;
	public void azurirajDinarskiIznos(float dinari) throws RemoteException;
	public void azurirajDevizniIznos(float devize) throws RemoteException;
	public void stampajStanje()  throws RemoteException;
}

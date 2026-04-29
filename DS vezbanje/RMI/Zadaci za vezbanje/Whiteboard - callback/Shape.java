import java.rmi.*;
import java.util.Vector.*;

public interface Shape extends Remote
{
	public int vratiVerziju() throws RemoteException;
	public void postaviVerziju(int verzija) throws RemoteException;
	public String prikaziUTekstualnomFormatu() throws RemoteException;
}
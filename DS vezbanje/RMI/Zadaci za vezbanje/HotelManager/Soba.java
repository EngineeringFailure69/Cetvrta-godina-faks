import java.rmi.*;

public interface Soba extends Remote
{
	public int vratiCenu() throws RemoteException;
	public int vratiBrojKreveta() throws RemoteException;
	public boolean vratiRezervisana() throws RemoteException;
	public void rezervacija(Putnik putnik) throws RemoteException;
}
import java.rmi.*;

public interface HotelManager extends Remote
{
	public Soba nadjiSobu(int maxCena, int brojKreveta) throws RemoteException;
}
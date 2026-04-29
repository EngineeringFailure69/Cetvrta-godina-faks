import java.rmi.*;

public interface Hotel extends Remote
{
	void rezervisiSobu(Soba soba, HotelCallback callback, Putnik putnik) throws RemoteException;
}
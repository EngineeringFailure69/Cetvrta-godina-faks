import java.rmi.*;

public interface WhiteboardCallback extends Remote
{
	void callback(int verzija) throws RemoteException;
}
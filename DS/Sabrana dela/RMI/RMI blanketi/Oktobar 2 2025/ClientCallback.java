import java.rmi.*;

public interface ClientCallback extends Remote
{
	void notify(String topic, Poruka poruka) throws RemoteException;
}
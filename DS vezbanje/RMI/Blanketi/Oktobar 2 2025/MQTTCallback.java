import java.rmi.*;

public interface MQTTCallback extends Remote
{
	void obavestenje(String topic, Poruka poruka) throws RemoteException;
}
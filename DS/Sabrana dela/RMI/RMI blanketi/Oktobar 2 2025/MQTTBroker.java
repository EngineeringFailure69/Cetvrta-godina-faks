import java.rmi.*;

public interface MQTTBroker extends Remote
{
	void publish(String topic, Poruka poruka) throws RemoteException;
	void subscribe(String topic, ClientCallback ccb) throws RemoteException;
}

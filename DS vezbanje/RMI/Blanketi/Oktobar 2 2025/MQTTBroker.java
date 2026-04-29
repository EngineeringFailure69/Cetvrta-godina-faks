import java.rmi.*;

public interface MQTTBroker extends Remote
{
	void subscribe(String topic, MQTTCallback callback) throws RemoteException;
	void publish(String topic, Poruka poruka) throws RemoteException;
}
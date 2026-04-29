import java.rmi.*;
import java.rmi.server.*;
import java.util.*;
//import java.util.concurrent.ConcurrentHashMap;

public class MQTTBrokerImpl extends UnicastRemoteObject implements MQTTBroker
{
	private Map<String, Set<ClientCallback>> topics; 
	
	public MQTTBrokerImpl() throws RemoteException
	{
		topics = new HashMap<>();	
	}
	
	private void createTopic(String topic)
	{
		if(!topics.containsKey(topic))
		{
			topics.put(topic, new HashSet<>());
		}	
	}
	
	public void publish(String topic, Poruka poruka) throws RemoteException
	{
		createTopic(topic);
		for(ClientCallback c : topics.get(topic))
		{
			c.notify(topic, poruka);
		}
	}
	
	public void subscribe(String topic, ClientCallback ccb) throws RemoteException
	{
		createTopic(topic);
		topics.get(topic).add(ccb);
		System.out.println("Klijent se pretplatio na temu: " + topic);
	}
}
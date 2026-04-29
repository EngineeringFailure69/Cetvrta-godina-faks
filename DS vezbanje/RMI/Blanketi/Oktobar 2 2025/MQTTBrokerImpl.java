import java.rmi.*;
import java.util.*;
import java.rmi.server.*;
import java.util.ArrayList;

public class MQTTBrokerImpl extends UnicastRemoteObject implements MQTTBroker
{
	private Map<String, List<MQTTCallback>> callbackovi;
	
	public MQTTBrokerImpl() throws RemoteException
	{
		callbackovi = new HashMap<String, List<MQTTCallback>>();
	}
	
	private void createTopic(String topic)
	{
		if(!callbackovi.containsKey(topic))
			callbackovi.put(topic, new ArrayList<>());
	}
	
	public void subscribe(String topic, MQTTCallback callback) throws RemoteException
	{
		if(!callbackovi.containsKey(topic))
			createTopic(topic);
		callbackovi.get(topic).add(callback);
		System.out.println("Pretplacen na temu: " + topic);
	}
	
	public void publish(String topic, Poruka poruka) throws RemoteException
	{
		if(!callbackovi.containsKey(topic))
			createTopic(topic);
		List<MQTTCallback> lista = callbackovi.get(topic);
		for(MQTTCallback cb : lista)
			cb.obavestenje(topic, poruka);
	}
}
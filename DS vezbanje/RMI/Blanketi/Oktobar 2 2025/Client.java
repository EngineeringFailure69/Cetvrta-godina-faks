import java.rmi.*;
import java.util.*;
import java.rmi.server.*;
import java.net.*;

public class Client
{
	public static void main(String[] args)
	{
		try
		{
			MQTTBroker manager = (MQTTBroker)Naming.lookup("rmi://localhost:1099/MQTTBrokerService");
			MQTTCallbackImpl clb = new MQTTCallbackImpl();
			manager.subscribe("sport", clb);
			Poruka poruka= new Poruka("FIFA", "svetsko prvenstvo 2026");
			manager.publish("sport", poruka);
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
		catch(MalformedURLException e)
		{
			e.printStackTrace();
		}
		catch(NotBoundException e)
		{
			e.printStackTrace();
		}
	}
	
	public static class MQTTCallbackImpl extends UnicastRemoteObject implements MQTTCallback
	{
		public MQTTCallbackImpl() throws RemoteException
		{
			super();
		}
		
		public void obavestenje(String topic, Poruka poruka) throws RemoteException
		{
			System.out.println("Obavestenje:\nTopic: " + topic + "\nNaslov poruke: " + poruka.naslov + "\nSadrzaj poruke: " + poruka.sadrzaj);
		}
	}
}
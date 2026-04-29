import java.rmi.*;
import java.rmi.server.*;
import java.util.*;

public class Client
{
	public static void main(String[] args)
	{
		try
		{
			MQTTBroker manager = (MQTTBroker)Naming.lookup("rmi://localhost/MQTTBrokerService");
			ClientCallbackImpl ccbi = new ClientCallbackImpl();
			
			manager.subscribe("tessss", ccbi);
			Scanner sc = new Scanner(System.in);
			while(true)
			{
				System.out.print("Unesi naslov poruke (ili 'exit' za kraj): ");
                String title = sc.nextLine();
                if (title.equalsIgnoreCase("exit")) break;

                System.out.print("Unesi sadrzaj poruke: ");
                String body = sc.nextLine();
				
				Poruka poruka = new Poruka(title, body);
				manager.publish("tessss", poruka);
			}
		}
		catch(Exception e)
		{
			e.printStackTrace();
		}
	}
	
	public static class ClientCallbackImpl extends UnicastRemoteObject implements ClientCallback
	{
		public ClientCallbackImpl() throws RemoteException
		{
			super();
		}
		public void notify(String topic, Poruka poruka) throws RemoteException
		{
			System.out.println("Stiglo je obavestenje, Topic: " + topic + "\n" + poruka);
		}
	}
}
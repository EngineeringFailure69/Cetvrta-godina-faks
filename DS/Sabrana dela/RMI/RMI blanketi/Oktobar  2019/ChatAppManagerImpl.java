import java.rmi.*;
import java.util.*;
import java.rmi.server.*;
import java.util.ArrayList;   

public class ChatAppManagerImpl extends UnicastRemoteObject implements ChatAppManager
{
	private static int id = 0;
	ArrayList<User> listaKorisnika;
	ArrayList<ChatMessage> poslatePoruke;
	Map<Integer, ChatMessageCallback> callbackovi;
	
	public ChatAppManagerImpl() throws  RemoteException
	{
		listaKorisnika = new ArrayList<User>();
		poslatePoruke = new ArrayList<ChatMessage>();
		callbackovi = new HashMap<Integer, ChatMessageCallback>();
	}
	
	public boolean SendChatMessage(User fromUser, User toUser, ChatMessage msg) throws RemoteException
	{
		msg.fromUser = fromUser;
		msg.toUser = toUser;
		poslatePoruke.add(msg);
		callbackovi.get(toUser.id).onChatMessage(msg);
		
		return true;
	}
	
	public Vector<ChatMessage> getChatMessages(User korisnik, int hour, int minute) throws RemoteException
	{
		Vector<ChatMessage> poruke = new Vector<ChatMessage>();
		for(ChatMessage msg : poslatePoruke)
			if(msg.toUser.id == korisnik.id)
				if(msg.hour > hour || (msg.hour == hour && msg.minute > minute))
					poruke.add(msg);
				
		return poruke;
	}
	
	public User addCallback(String username, ChatMessageCallback callback) throws RemoteException
	{
		User u = new User(username);
		u.id = id++;
		listaKorisnika.add(u);
		callbackovi.put(u.id, callback);
		return u;
	}
}
import java.rmi.*;
import java.util.*;

public interface ChatAppManager extends Remote
{
	boolean SendChatMessage(User fromUser, User toUser, ChatMessage msg) throws RemoteException;
	Vector<ChatMessage> getChatMessages(User korisnik, int hour, int minute) throws RemoteException;
	User addCallback(String username, ChatMessageCallback callback) throws RemoteException;
}
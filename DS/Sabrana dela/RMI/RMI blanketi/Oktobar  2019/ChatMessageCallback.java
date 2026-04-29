import java.rmi.*;

public interface ChatMessageCallback extends Remote
{
	void onChatMessage(ChatMessage msg) throws RemoteException;
}
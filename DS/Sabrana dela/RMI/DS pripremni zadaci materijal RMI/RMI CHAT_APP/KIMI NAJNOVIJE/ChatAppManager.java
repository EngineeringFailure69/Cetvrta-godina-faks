import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.Vector;

public interface ChatAppManager extends Remote {
    boolean sendChatMessage(User from,User to,ChatMessage msg) throws RemoteException;
    Vector<ChatMessage> getChatMessages(User u,int minute,int hour) throws RemoteException;
    User registerUser(String username,ChatMessageCallback clb) throws RemoteException;
    ArrayList<User> search() throws RemoteException;
}

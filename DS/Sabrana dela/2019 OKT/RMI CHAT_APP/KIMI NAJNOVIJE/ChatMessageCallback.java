import java.rmi.Remote;
import java.rmi.RemoteException;

public interface ChatMessageCallback extends Remote {
    void notifyUser(ChatMessage msg) throws RemoteException;
}

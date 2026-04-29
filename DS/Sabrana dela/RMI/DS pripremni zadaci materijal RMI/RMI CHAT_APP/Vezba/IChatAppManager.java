import java.rmi.RemoteException;

public interface IChatAppManager extends Remote{
    void sendChatMessage(User fromUser, User toUser, ChatMessage msg) throws RemoteException;
    Vector<ChatMessage> getChatMessages(User u, int hour, int minute) throws RemoteException;
    void RegisterUser(String username, IChatMessage clb) throws RemoteException;
}

public class ChatAppManager extends UnicastRemoteObject implements IChatAppManager{
    Map<Integer, IChatMessageCallback> clbs = new HashMap<Integer, IChatMessageCallback>();

    public static int globalId=0;
    void sendChatMessage(User fromUser, User toUser, ChatMessage msg) throws RemoteException;
    Vector<ChatMessage> getChatMessages(User u, int hour, int minute) throws RemoteException;
    void RegisterUser(String username, IChatMessage clb) throws RemoteException;

}
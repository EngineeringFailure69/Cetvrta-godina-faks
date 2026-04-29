import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Vector;



public class ChatAppManagerImpl extends UnicastRemoteObject implements ChatAppManager {
    private static int userId = 0;
    ArrayList<User> registeredUsers;
    ArrayList<ChatMessage> sentMessages;
    Map<Integer, ChatMessageCallback> chatMap;
   


    public ChatAppManagerImpl() throws RemoteException{
        registeredUsers=new ArrayList<User>();
        sentMessages=new ArrayList<ChatMessage>();
        chatMap=new HashMap<Integer,ChatMessageCallback>();
       
    }
    public boolean sendChatMessage(User from, User to, ChatMessage msg) throws RemoteException {
          
            msg.fromUser=from;
            msg.toUser=to;
            sentMessages.add(msg);
            chatMap.get(to.id).notifyUser(msg);
            return true;
        
    }

    public Vector<ChatMessage> getChatMessages(User u, int minute, int hour) throws RemoteException {
        Vector<ChatMessage> v=new Vector<ChatMessage>();
        for(ChatMessage msg:sentMessages){
            if(msg.toUser.id==u.id){
                if(msg.hour>hour || (msg.hour==hour && msg.minute>minute))
                      v.add(msg);
                
            }
        }
        return v;
    }

    public User registerUser(String username, ChatMessageCallback clb) throws RemoteException {
        User u=new User(username);
        u.id=userId++;
        registeredUsers.add(u);
        chatMap.put(u.id,clb);
        return u;
    }
    
    public ArrayList<User> search() throws RemoteException{
        return registeredUsers;
    }
    

}
    


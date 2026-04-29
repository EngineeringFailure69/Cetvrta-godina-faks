import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.Vector;

public class ChatAppClient {
    ChatAppManager m;
    ChatMessageCallback clb;
    User me;

    public ChatAppClient(String name) {
        m = (ChatAppManager) Naming.lookup("....");
        clb=new ChatMessageCallbackImpl();
        me=m.registeUser(name, clb);
    }

    public void sendMsg(String poruka,User toUser){
        ChatMessage msg=new ChatMessage(poruka);
        if(m.sendChatMessage(me, toUser, msg)){
             //poslata
        }else{
            //doslo je do greske
        }
    }

     private void getMsgs(User u,int hour,int minute){
         Vector<ChatMessage> v=m.getChatMessages(u, minute, hour);
         if(v.size()!=0){
             for(int i=0;i<v.size();i++){
                 onMessageReceived(v.get(i));
             }
         }
     }
    public ArrayList<User> search(){
        return m.search();
    }
    public void onMessageReceived(ChatMessage msg) {
        //dobio poruku ...
    }
    public class ChatMessageCallbackImpl extends UnicastRemoteObject implements ChatMessageCallback {
        public void notifyUser(ChatMessage msg) throws RemoteException {
            onMessageReceived(msg);
        }
    }

    public static void main(){
        ChatAppClient client=new ChatAppClient("name");
        ArrayList<User> friends=client.search();
        client.getMsgs(client.me,LocalDateTime.now().getHour(), LocalDateTime.now().getMinute());
        client.sendMsg("poruka",friends.get(0));
    }
    
}

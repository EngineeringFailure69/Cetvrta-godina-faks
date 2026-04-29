import java.rmi.*;
import java.rmi.server.*;
import java.io.IOException;
import java.net.*;
import java.util.*;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.Vector;
import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Client 
{
	ChatAppManager manager;
	ChatMessageCallback callback;
	User korisnik;
	
	public Client(String username)
	{
		manager = (ChatAppManager)Naming.lookup("rmi://localhost:1099/ChatAppService");
		callback = new ChatMessageCallbackImpl();
		korisnik = manager.addCallback(username, callback);
	}
	
	private void getMsgs(User u,int hour,int minute){
         Vector<ChatMessage> v = manager.getChatMessages(u, minute, hour);
         if(v.size()!=0){
             for(int i=0;i<v.size();i++){
                 dobioPoruku(v.get(i));
             }
         }
     }
	 
	 public void dobioPoruku(ChatMessage msg)
	 {
			System.out.println("Poruka primljena:");
			System.out.println("From: " + msg.fromUser);
			System.out.println("Poruka: " + msg.msg);
			System.out.println("Vreme: " + msg.hour + msg.minute);
	 }
	
	public class ChatMessageCallbackImpl extends UnicastRemoteObject implements ChatMessageCallback
	{
		public ChatMessageCallbackImpl() throws RemoteException
		{
			super();
		}
		public void onChatMessage(ChatMessage msg) throws RemoteException
		{
			dobioPoruku(msg);
		}
	}
	
	public static void main(String[] args)
	{
		Client client = new Client("name");
        //ArrayList<User> friends=client.search();
        client.getMsgs(client.korisnik,LocalDateTime.now().getHour(), LocalDateTime.now().getMinute());
        //client.sendMsg("poruka",friends.get(0));
	}
}
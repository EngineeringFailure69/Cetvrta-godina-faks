import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.util.Vector;
import java.util.ArrayList;

public class WhiteboardManagerImpl extends UnicastRemoteObject implements WhiteboardManager {
 
 private int version;
 private Vector theList; 
 private ArrayList<WhiteboardCallback> clients=new ArrayList<WhiteboardCallback>();
 
 public WhiteboardManagerImpl() throws RemoteException{
	 theList = new Vector();
	 version = 0;
 }
 
 public Shape newShape(GraphicalObject g) throws RemoteException {
	version++;
	Shape s = new ShapeImpl( g,version);
	theList.addElement(s);
	
	callback();
	
	return s;
 }
 
 public Vector allShapes() throws RemoteException{
	return theList;
 }
 
 public int getVersion() throws RemoteException{
	return version;
 } 
 
 public synchronized void register(WhiteboardCallback c) throws RemoteException {
	 	 
	 clients.add(c);
	 
 }
 
 public synchronized void unregister(WhiteboardCallback c) throws RemoteException {
	 
	 clients.remove(c);
	 
 }
 
 private void callback() {
	 
	for (WhiteboardCallback c : clients) {
		if (c!=null)
		try {
			System.out.println("callbacks..");
			c.callback(version);    
		}
		catch (Exception e) {
		}
	}
		
}
 
}
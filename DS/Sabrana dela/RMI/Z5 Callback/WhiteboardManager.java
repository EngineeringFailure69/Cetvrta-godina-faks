import java.rmi.*;
import java.util.Vector;

public interface WhiteboardManager extends Remote {
	
 Shape newShape(GraphicalObject g) throws RemoteException;
 
 Vector allShapes() throws RemoteException;
 
 int getVersion() throws RemoteException;
 
 void register (WhiteboardCallback callback) throws RemoteException;
 
 void unregister (WhiteboardCallback callback) throws RemoteException;
 
}
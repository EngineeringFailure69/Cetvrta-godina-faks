import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.registry.*; 

public class WhiteboardServer {

public static void main(String args[]){

try 
{ 
	LocateRegistry.createRegistry(1099); 
	System.out.println("java RMI registry created.");			
	
} catch (RemoteException e) {            
	System.out.println("java RMI registry already exists.");
}	

try {
 
	WhiteboardManager WMngr = new WhiteboardManagerImpl();	
	
	Naming.rebind("rmi://localhost:1099/ShapeList",WMngr); 

	System.out.println("ShapeList server ready");
 }
 catch(Exception e) {
	System.out.println("ShapeList server main " + e.getMessage());
 }
 
}
 
}
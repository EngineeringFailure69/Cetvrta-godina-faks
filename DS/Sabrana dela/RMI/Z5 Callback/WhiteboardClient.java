import java.rmi.*;
import java.rmi.server.*;
import java.util.Vector;
import java.awt.Rectangle;
import java.awt.Color;
import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.io.IOException;
import java.util.*; 

public class WhiteboardClient {
 
 private WhiteboardManager WMngr;
 private WhiteboardCallback cc;
 
 public WhiteboardClient() {
	 
	String option = "Read";
	String shapeType = "Rectangle";
	
	WMngr=null;	
	cc=null;
	
	try {
		
		WMngr = (WhiteboardManager)Naming.lookup("rmi://localhost:1099/ShapeList");
		
		System.out.println("Found server");
		
		cc=new WhiteboardCallbackImpl();
		
		WMngr.register(cc);		
		
		System.out.println("callback registered");
		
	} 
	catch(RemoteException e)
	{
		System.out.println("allShapes: " + e.getMessage());
	} 
	catch(Exception e) 
	{
		System.out.println("Lookup: " + e.getMessage());
	}
	
	try {	
	
		Scanner s=new Scanner(System.in);
	
		while(true) {
			
			shapeType=s.nextLine().trim();		
			
			if (shapeType.equals("EXIT")) break;
			
			GraphicalObject g = new GraphicalObject(shapeType, new Rectangle(50,50,300,400),Color.red,Color.blue, false);
			System.out.println("Created graphical object");	
			WMngr.newShape(g);		 				
		}		
	} 
	catch(RemoteException e)
	{		
	}
	
	try {		
		WMngr.unregister(cc);				
		System.out.println("callback unregistered");		
	} 
	catch(RemoteException e)
	{		
	}
	 
 } 
 
 public void showWhiteboard() {
 
	System.out.println("Whiteboard content");	
 
	try {  			
		 
		 Vector sList = WMngr.allShapes();
	
		 for(int i=0; i<sList.size(); i++) {
			 GraphicalObject g = ((Shape)sList.elementAt(i)).getAllState();
			 g.print();
		 }
		 
	} catch (IOException ioException) {     
	
	}    
	 
 }
 
 public static void main(String args[]) {
 
	new WhiteboardClient();
	
	try {  			
		System.in.read();      			 		
	} catch (IOException ioException) {     
	
	}      
	
	System.exit(0);
	
 } 
 
 public class WhiteboardCallbackImpl extends UnicastRemoteObject implements WhiteboardCallback {
	
	public WhiteboardCallbackImpl() throws RemoteException 
	{		
	}
	
	public void callback(int version) throws RemoteException 
	{
		System.out.println("Current Whiteboard version is: "+version);	
		
		showWhiteboard();
		
	}	
}
 
}

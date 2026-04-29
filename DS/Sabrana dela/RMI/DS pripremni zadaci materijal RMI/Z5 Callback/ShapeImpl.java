import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;

public class ShapeImpl extends UnicastRemoteObject implements Shape {
 
 int myVersion;
 GraphicalObject theG;

 public ShapeImpl(GraphicalObject g,int version) throws RemoteException{
	theG = g;
	myVersion = version;
 }

 public int getVersion() throws RemoteException {
	return myVersion;
 }
 
 public GraphicalObject getAllState() throws RemoteException {
	return theG;
 }

}
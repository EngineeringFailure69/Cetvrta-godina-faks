import java.rmi.*;
import java.server.*;
import java.io.*;
import java.net.MalformedURLException;

public class Server {
	
	private String host, port, service;
	public IKonkursManager konkursLista; 
	
	public static void main (String args[]) {
		
		try{
			konkursLista = new IKonkursManagerImpl();
		}catch(RemoteException re){
			System.out.println("Remote Exception");
		}
		
		host = args[0];
		port = args[1];
		service = args[2];
		
		try{
			Naming.rebind("rmi://" + host + ":" + port + "/" + service, konkursLista);
		}catch (RemoteException remoteException) {
			System.err.println("Failure during Name registration: " +
								remoteException);
		}catch (MalformedURLException malformedException) {
			System.err.println("Failure during Name registration: " +
								malformedException);
		}
		try {
			System.in.read();
		}catch (IOException ioException) { }
		
		System.exit(0);
		
	}
}


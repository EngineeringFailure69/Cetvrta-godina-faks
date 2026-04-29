package eBanka;
import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.rmi.registry.*; 

public class Server {

public static void main(String args[]){

try 
{ 
	LocateRegistry.createRegistry(1099); 
	System.out.println("java RMI registry created.");			
	
} catch (RemoteException e) {            
	System.out.println("java RMI registry already exists.");
}	

try {
 
	EBankaManager mngr = new EBankaManagerImpl();
	Korisnik e1=new KorisnikImpl("1",300,300);
	Korisnik e2=new KorisnikImpl("2",3000,4323);
	Korisnik e3=new KorisnikImpl("3",23,53);
	Korisnik e4=new KorisnikImpl("4",5600,1230);
	Korisnik e5=new KorisnikImpl("5",3456,654);
	
	mngr.dodaj(e1);
	mngr.dodaj(e2);
	mngr.dodaj(e3);
	mngr.dodaj(e4);
	mngr.dodaj(e5);
	
	Naming.rebind("rmi://localhost:1099/servis",mngr); 

	System.out.println("Server ready");
 }
 catch(Exception e) {
	System.out.println("Server main " + e.getMessage());
 }
 
}
 
}



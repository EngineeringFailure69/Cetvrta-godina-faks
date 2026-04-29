package eBanka;
import java.io.IOException;
import java.io.PrintWriter;
import java.io.Writer;
import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.util.Scanner;
import java.util.Vector;


public class Klijent {
	 
	 private EBankaManager mngr;
	 private EBankaCallback cc;
	 
	 
	 public Klijent() {
		
		mngr=null;	
		cc=null;
		
		try {
			
			mngr = (EBankaManager)Naming.lookup("rmi://localhost:1099/servis");
			
			System.out.println("Found server");
			
			cc=new EBankaCallbackImpl();
			
			mngr.registere(cc);		
			
			System.out.println("callback registered");
			
		} 
		catch(RemoteException e)
		{
			System.out.println("Remote Exception: " + e.getMessage());
		} 
		catch(Exception e) 
		{
			System.out.println("Lookup: " + e.getMessage());
		}
		
		try {	
		
			Scanner s=new Scanner(System.in);
			Writer writer = new PrintWriter(System.out);
			
			while(true) {
				
				System.out.println("Meni operatora");	
				System.out.println("a) Administratorski mod");
				System.out.println("b) Korisnicki mod");
				System.out.println("Unesite a ili b  da biste izabrali opciju");
				
				String opcija=s.nextLine();
				if(opcija.equals("a")){
				
						System.out.println("Dobro dosli u administratorski mod");	
						System.out.println("a) Slanje obavestenja");
						System.out.println("b) Izlaz");
						String opcija2=s.nextLine();
						if(opcija2.equals("b")){
							break;
						}
						else if(opcija2.equals("a")){
							System.out.println("Unesite poruku koju zelite da posaljete");
							String poruka=s.nextLine();
							mngr.posaljiObavestenje(poruka);
							continue;
						}
					
				}
				else if(opcija.equals("b")){
					
					System.out.println("Dobro dosli u korisnicki mod");	
					System.out.println("Unesite vas jedinstveni korisnicki broj");
					String jbk=s.nextLine();
					Korisnik kor=mngr.vratiKorisnika(jbk);
					if(kor==null){
						System.out.println("Niste registvovani korisnik");
						break;
					}
					System.out.println("a) Transfer sa dinarskog na devizni racun");
					System.out.println("b) Transfer sa deviznog na dinarski racun");
					System.out.println("c) Provera stanja");
					System.out.println("d) Izlaz");
					String opcija2=s.nextLine();
					if(opcija2.equals("d")){
						break;
					}
					else if(opcija2.equals("a")){
						
						System.out.println("Vase trenutno stanje je:");
						System.out.println("Dinarski iznos: "+kor.vratiStanje().vratiDinarskiIznos());
						System.out.println("Devizni iznos: "+kor.vratiStanje().vratiDevizniIznos());
						System.out.println("Unesite iznos");
						float iznos=s.nextFloat();
						try {
							writer.flush();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						kor.transferDinarskiNaDevizni(iznos, mngr.vratiKurs());
						System.out.println("Dinarski iznos: "+kor.vratiStanje().vratiDinarskiIznos());
						System.out.println("Devizni iznos: "+kor.vratiStanje().vratiDevizniIznos());
					}
					else if(opcija2.equals("b")){
						
						System.out.println("Vase trenutno stanje je:");
						System.out.println("Dinarski iznos: "+kor.vratiStanje().vratiDinarskiIznos());
						System.out.println("Devizni iznos: "+kor.vratiStanje().vratiDevizniIznos());
						System.out.println("Unesite iznos");
						float iznos=s.nextFloat();
						try {
							writer.flush();
						} catch (IOException e) {
							// TODO Auto-generated catch block
							e.printStackTrace();
						}
						kor.transferDevizniNaDinarski(iznos, mngr.vratiKurs());
						System.out.println("Dinarski iznos: "+kor.vratiStanje().vratiDinarskiIznos());
						System.out.println("Devizni iznos: "+kor.vratiStanje().vratiDevizniIznos());
					}
					else if(opcija2.equals("c")){
						
						System.out.println("Vase trenutno stanje je:");
						System.out.println("Dinarski iznos: "+kor.vratiStanje().vratiDinarskiIznos());
						System.out.println("Devizni iznos: "+kor.vratiStanje().vratiDevizniIznos());
					}
				}
				
				
				}		 						
		} 
		catch(RemoteException e)
		{		
		}
		
		try {		
			mngr.unregister(cc);				
			System.out.println("callback unregistered");		
		} 
		catch(RemoteException e)
		{		
		}
		 
	 } 
	 
	 public void show(String poruka) {
	 
		System.out.println(poruka);    
		 
	 }
	 
	 public static void main(String args[]) {
	 
		new Klijent();
		
		try {  			
			System.in.read();      			 		
		} catch (IOException ioException) {     
		
		}      
		
		System.exit(0);
		
	 } 
	 
	 public class EBankaCallbackImpl extends UnicastRemoteObject implements EBankaCallback{
		
		public EBankaCallbackImpl() throws RemoteException 
		{		
		}
		
		public void callback(String poruka) throws RemoteException 
		{
			System.out.println("Callback u klijentu");	
			
			show(poruka);
			
		}	
	}
	 
	}

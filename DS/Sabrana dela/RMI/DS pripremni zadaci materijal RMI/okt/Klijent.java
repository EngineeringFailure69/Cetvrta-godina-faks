import java.rmi.*;
import java.io.*;
import java.server.*;
import java.net.*;

public class Klijent {
	
	private IKonkursManager konkursi;
	
	public Klijent(String host, String port, String server){
		try{
			konkursi = (IKonkursManager)Naming.lookup("rmi://" + host + "/" + port + "/" + server);
		}catch(MalformedURLException URL){ }
		catch (NotBoundException bound) { }
		catch (RemoteException rm) { }
		
		try{
			Kandidat kand = new Kandidat();
			Scanner tastatura = new Scanner(System.in);
			System.out.println("Unesi ime kandidata: ");
			kand.ime = tastatura.NextLine();
			System.out.println("Unesi prezime kandidata: ");
			kand.prezime = tastatura.NextLine();
			System.out.println("Unesi minimalnu platu: ");
			List<KonkursImpl> recvKonkursi = konkursi.NadjiKonkurs(tastatura.NextInt());
			for(KonkursImpl k: recvKonkursi){
				System.out.println(k.VratiIme() + " " + k.VratiPlatu());
			}
		}
	}
	
	public static void main (String args[]) {
		String host = args[0];
		String port = args[1];
		String server = args[2];
		new Klijent(host,port,server);
	}
}


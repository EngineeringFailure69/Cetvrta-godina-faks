package eBanka;
import java.rmi.*; 

public interface EBankaManager extends Remote {
	public Korisnik vratiKorisnika(String jbk) throws RemoteException;
	public void posaljiObavestenje(String poruka) throws RemoteException;
	public void registere(EBankaCallback cc) throws RemoteException;
	public void unregister(EBankaCallback cc) throws RemoteException;
	public float vratiKurs() throws RemoteException;
	public void dodaj(Korisnik e1) throws RemoteException;

}

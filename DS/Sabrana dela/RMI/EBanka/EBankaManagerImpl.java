package eBanka;
import java.rmi.*;
import java.rmi.server.*;
import java.util.ArrayList;

public class EBankaManagerImpl extends UnicastRemoteObject implements EBankaManager{

	private ArrayList<Korisnik> listaKorisnika;
	private ArrayList<EBankaCallback> klijenti;
	private float kurs;
	
	protected EBankaManagerImpl() throws RemoteException {
		super();
		this.klijenti=new ArrayList<EBankaCallback>();
		this.listaKorisnika=new ArrayList<Korisnik>();
		this.kurs=(float) 118.17;
	}

	@Override
	public Korisnik vratiKorisnika(String jbk) throws RemoteException {
		for(int i=0;i<this.listaKorisnika.size();i++){
			if(this.listaKorisnika.get(i).vratiJbk().equals(jbk)){
				return this.listaKorisnika.get(i);
			}
		}
		return null;
	}

	@Override
	public void posaljiObavestenje(String poruka) throws RemoteException {
		for(int i=0;i<this.klijenti.size();i++){
			this.klijenti.get(i).callback(poruka);
		}
		
	}

	@Override
	public void registere(EBankaCallback cc) throws RemoteException {
		this.klijenti.add(cc);
		
	}

	@Override
	public void unregister(EBankaCallback cc) throws RemoteException {
		this.klijenti.remove(cc);
		
	}

	@Override
	public float vratiKurs() throws RemoteException {
		return this.kurs;
	}

	@Override
	public void dodaj(Korisnik e1) throws RemoteException {
		this.listaKorisnika.add(e1);
		
	}

}

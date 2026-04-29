package eBanka;
import java.rmi.server.*;
import java.rmi.*;


public class StanjeImpl extends UnicastRemoteObject implements Stanje {

	private float iznosDevizni, iznosDinarski;
	
	protected StanjeImpl(float iznosDinarski, float iznosDevizni) throws RemoteException {
		super();
		this.iznosDevizni=iznosDevizni;
		this.iznosDinarski=iznosDinarski;
	}

	@Override
	public float vratiDinarskiIznos() throws RemoteException {
		return this.iznosDinarski;
	}

	@Override
	public float vratiDevizniIznos() throws RemoteException {
		return this.iznosDevizni;
	}

	@Override
	public void azurirajDinarskiIznos(float dinari) throws RemoteException {
		this.iznosDinarski=dinari;
	}

	@Override
	public void azurirajDevizniIznos(float devize) throws RemoteException {
		this.iznosDevizni=devize;
	}

	@Override
	public void stampajStanje() throws RemoteException {
		 System.out.println("Stanje na dinarskom ranunu je: "+this.iznosDinarski);
		 System.out.println("Stanje na deviznom ranunu je: "+this.iznosDevizni);
	}

}

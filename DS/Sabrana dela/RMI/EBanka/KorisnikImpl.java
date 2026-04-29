package eBanka;
import java.rmi.server.*;
import java.rmi.*;

public class KorisnikImpl extends UnicastRemoteObject implements Korisnik {

	private String jbk;
	private Stanje stanje;
	
	protected KorisnikImpl(String jbk, float iznosDinarski, float iznosDevizni) throws RemoteException {
		super();
		this.stanje=new StanjeImpl(iznosDinarski, iznosDevizni);
		this.jbk=jbk;
	}

	@Override
	public Stanje vratiStanje() throws RemoteException {
		return this.stanje;
	}

	@Override
	public void transferDinarskiNaDevizni(float iznos, float kurs) throws RemoteException {
		float newSum=this.stanje.vratiDinarskiIznos()-iznos;

        if(newSum<0)
        {
            System.out.println("Nemate dovoljno novca");
            return;
        }

        float devize=iznos/kurs;

        this.stanje.azurirajDinarskiIznos(newSum);
        this.stanje.azurirajDevizniIznos(this.stanje.vratiDevizniIznos()+devize);

	}

	@Override
	public void transferDevizniNaDinarski(float iznos, float kurs) throws RemoteException {
		float newSum=this.stanje.vratiDevizniIznos()-iznos;

        if(newSum<0)
        {
        	System.out.println("Nemate dovoljno novca");
            return;
        }

        float dinari=iznos*kurs;
        this.stanje.azurirajDevizniIznos(newSum);
        this.stanje.azurirajDinarskiIznos(this.stanje.vratiDinarskiIznos()+dinari);

		
	}

	@Override
	public String vratiJbk() throws RemoteException {
		return this.jbk;
	}

}

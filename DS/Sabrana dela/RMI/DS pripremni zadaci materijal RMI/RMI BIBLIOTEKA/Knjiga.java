import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Knjiga extends UnicastRemoteObject implements IKnjiga {
    String naslov, pisac;
    boolean slobodna;

    public Knjiga(String naslovKnjige, String pisacKnjige) throws RemoteException {
        super();
        naslov = naslovKnjige;
        pisac = pisacKnjige;
        slobodna = true;
    }

    public String pribaviInformacije() {
        return "Naslov: " + naslov + ", pisac: " + pisac + ", slobodna: " + slobodna;
    }

    public boolean ispitajSlobodnost() { return slobodna;}
    public String pribaviNaziv() {return naslov;}
    public void izmeniSlobodnost() {slobodna = !slobodna;}
}

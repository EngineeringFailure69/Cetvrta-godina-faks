import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.*;

public class Biblioteka extends UnicastRemoteObject implements IBiblioteka {
    List<IKnjiga> listaKnjiga;
    List<ICitalac> listaCitalaca;

    public Biblioteka() throws RemoteException  {
        super();
        listaKnjiga = new ArrayList<IKnjiga>();
        listaCitalaca = new ArrayList<ICitalac>();
        Knjiga k1 = new Knjiga("Knjiga1", "Darko");
        Knjiga k2 = new Knjiga("Knjiga2", "Marko");
        Knjiga k3 = new Knjiga("Knjiga3", "Zarko");
        listaKnjiga.add(k1);
        listaKnjiga.add(k2);
        listaKnjiga.add(k3);
    }

    public List<IKnjiga> pribaviKnjige()
    {
        return listaKnjiga;
    }

    public boolean proveriDostupnost(String naziv) throws RemoteException {
        IKnjiga knjiga = pribaviKnjigu(naziv);
        return knjiga.ispitajSlobodnost();
    }

    private IKnjiga pribaviKnjigu(String naziv) throws RemoteException {
        System.out.println("naziv: " + naziv);
        for (int i = 0; i < listaKnjiga.size(); i++) {
            if (listaKnjiga.get(i).pribaviNaziv().equals(naziv)) {
                return listaKnjiga.get(i);
            }
        }
        return null;
        // Poredjenje dva stringa vrsiti funkcijom isEqual(String s)
        // on ih poredi po vrednosti, a operator == ih poredi po referenci.
    }

    public void iznajmiKnjigu(String ime, String prezime, String naziv) throws RemoteException {
        ICitalac citalac = new Citalac(ime, prezime);
        listaCitalaca.add(citalac);
        IKnjiga knjiga = pribaviKnjigu(naziv);
        System.out.println("nabavio sam knjigu" + knjiga.pribaviNaziv());
        if(knjiga != null)
            citalac.iznajmiKnjigu(knjiga);
        System.out.println(knjiga.pribaviInformacije());

        knjiga.izmeniSlobodnost();
    }
}

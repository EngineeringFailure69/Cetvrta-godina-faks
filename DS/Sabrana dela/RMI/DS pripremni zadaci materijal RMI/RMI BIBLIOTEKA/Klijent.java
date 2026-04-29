import javax.naming.Name;
import java.net.MalformedURLException;
import java.rmi.Naming;
import java.rmi.NotBoundException;
import java.rmi.RemoteException;
import java.util.List;

public class Klijent {

    public static void main(String [] args) throws RemoteException, NotBoundException, MalformedURLException {
        IBiblioteka biblioteka = (IBiblioteka) Naming.lookup("rmi://localhost:1099/Biblioteka");
        System.out.println("Woah! Klijent pokrenut! :D");
        List<IKnjiga> listaKnjiga = biblioteka.pribaviKnjige();
        for(int i = 0; i < listaKnjiga.size(); i++)
            System.out.println(listaKnjiga.get(i).pribaviInformacije());
        biblioteka.iznajmiKnjigu("Darko", "Stevanovic", "Knjiga1");
        if (biblioteka.proveriDostupnost("Knjiga2"))
            System.out.println("Knjiga2 je dostupna.");
        else
            System.out.println("Knjiga2 nije dostupna.");
    }
}

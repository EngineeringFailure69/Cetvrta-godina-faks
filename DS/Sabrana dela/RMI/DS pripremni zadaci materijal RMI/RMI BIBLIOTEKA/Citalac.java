import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.List;

public class Citalac extends UnicastRemoteObject implements ICitalac {
    String ime, prezime;
    List<IKnjiga> knjige;

    public Citalac(String ime, String prezime) throws RemoteException {
        super();
        this.ime = ime;
        this.prezime = prezime;
        knjige = new ArrayList<IKnjiga>();
    }

    public void iznajmiKnjigu(IKnjiga knjiga)
    {
        knjige.add(knjiga);
    }

    public String pribaviInformacije() throws RemoteException {
        String info = "Ime: " + ime + " ,prezime: " + prezime + ", lista iznajmljenih knjiga: ";
        for (int i = 0; i < knjige.size(); i++)
            info += knjige.get(i).pribaviInformacije() + "\n";
        return info;
    }

}


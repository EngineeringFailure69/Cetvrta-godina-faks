import java.rmi.*;
import java.server.*;

public class KonkursImpl extends UnicastRemoteObject implements IKonkurs {
	
	private int plata;
	private String naziv;
	private int brojPrijavljenih;
	private List<Kandidat> Kandidati;
	
	public KonkursImpl(){
		
	}
	public KonkursImpl(int pl, String ime){
		plata = pl;
		naziv = ime; 
		brojPrijavljenih = 0;
	}
	
	@Override
	public void PrijaviKandidata(Kandidat kandidat) throws RemoteException{
		if(brojPrijavljenih < 5){
			kandidati.Add(kandidat);
			brojPrijavljenih++;
		}
		else
			System.out.println("Konkurs nije dostupan");
	}
	
	@Override
	public void OdjaviKandridata(Kandidat kandidat) throws RemoteException{
		if(brojPrijavljenih > 0){
			kandidati.Remove(kandidat);
			brojPrijavljenih--;
		}
		else
			System.out.println("Konkurs je prazan");
	}
	
	@Override
	public int VratiPlatu() throws RemoteException{
		return plata;
	}
	
	@Override
	public String VratiIme() throws RemoteException{
		return naziv;
	}
	
	@Override
	public int VratiBrPrijavljenih() throws RemoteException{
		return brojPrijavljenih;
	}
}


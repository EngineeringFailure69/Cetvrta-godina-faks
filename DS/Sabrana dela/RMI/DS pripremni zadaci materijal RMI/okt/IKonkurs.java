import java.rmi.*;

public interface IKonkurs extends Remote {
	
	public void PrijaviKandidata(Kandidat kandidat) throws RemoteException;
	public void OdjaviKandridata(Kandidat kandidat) throws RemoteException;
	public int VratiPlatu() throws RemoteException; 
	public String VratiIme() throws RemoteException;
	public int VratiBrPrijavljenih() throws RemoteException;
}


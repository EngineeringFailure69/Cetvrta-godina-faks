import java.rmi.*;


public interface IKonkursManager implements Remote {
	
	private List<KonkursImpl> NadjiKonkurs(int plata) throws RemoteException;
	
}


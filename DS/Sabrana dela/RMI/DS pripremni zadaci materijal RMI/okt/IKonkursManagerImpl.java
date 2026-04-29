import java.rmi.*;
import java.server.*;


public class IKonkursManagerImpl extends UnicastRemoteObject implements IKonkursManager {
	
	private List<KonkursImpl> konkursi;
	
	public IKonkursManagerImpl(){
		IKonkurs konkurs1 = null;
		IKonkurs konkurs2 = null;
		IKonkurs konkurs3 = null;
		IKonkurs konkurs4 = null;
		IKonkurs konkurs5 = null;
		try{
			konkurs1 = new KonkursImpl(18000, "Cistac");
			konkurs2 = new KonkursImpl(20000, "Kasirka");
			konkurs3 = new KonkursImpl(25000, "Fizicki radnik");
			konkurs4 = new KonkursImpl(40000, "Profesor matematike");
			konkurs5 = new KonkursImpl(100000, "Ministar");
			
		}catch(RemoteException remoteEx){
			System.out.println("Greska: RemoteException");
		}
		konkursi.Add(konkurs1);
		konkursi.Add(konkurs2);
		konkursi.Add(konkurs3);
		konkursi.Add(konkurs4);
		konkursi.Add(konkurs5);
	}
	
	@Override
	private List<KonkursImpl> NadjiKonkurs(int plata){
		List<KonkursImpl> k;
		for (KonkursImpl konkurs: konkursi) {
			if(konkurs.plata >= plata)
				k.Add(konkurs);
		}
		return k;
	}
}


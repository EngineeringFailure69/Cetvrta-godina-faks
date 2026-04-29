package eBanka;
import java.rmi.*;


public interface EBankaCallback  extends Remote{
	public void callback(String poruka) throws RemoteException;

}

import java.rmi.*;
import java.util.*;

public interface LotoCallback extends Remote
{
	void winner() throws RemoteException;
	void showAllWinners(Vector<Integer> pobednici) throws RemoteException;
	void youLost() throws RemoteException;
}
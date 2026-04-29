import java.rmi.*;
import java.util.*;

public interface LotoManager extends Remote
{
	Ticket playTicket(Vector<Integer> numbers) throws RemoteException;
	Vector<Integer> getWinners() throws RemoteException;
	void drawNumbers() throws RemoteException;
	void addCallback(int clbId, LotoCallback clb) throws RemoteException;
}
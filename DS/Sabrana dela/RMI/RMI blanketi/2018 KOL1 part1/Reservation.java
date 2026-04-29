import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.util.*;

public interface Reservation extends Remote
{
	public String getInfo() throws RemoteException;
}
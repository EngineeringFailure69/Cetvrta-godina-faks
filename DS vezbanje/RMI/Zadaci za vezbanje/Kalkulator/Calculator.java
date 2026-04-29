import java.rmi.*;

public interface Calculator extends Remote
{
	public int add(int a) throws RemoteException;
	public int subtract(int a) throws RemoteException;
	public int multiply(int a) throws RemoteException;
	public int divide(int a) throws RemoteException;
}
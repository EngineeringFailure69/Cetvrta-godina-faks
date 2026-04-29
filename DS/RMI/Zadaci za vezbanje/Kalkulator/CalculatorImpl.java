import java.rmi.*;
import java.rmi.server.*;

public class CalculatorImpl extends UnicastRemoteObject implements Calculator
{
	private int acc;
	protected CalculatorImpl() throws RemoteException
	{
		super();
		acc = 0;
	}
	
	@Override
	public int add(int a) throws RemoteException
	{
		acc += a;
		return acc;
	}
	
	@Override 
	public int subtract(int a) throws RemoteException
	{
		acc -= a;
		return acc;
	}
	
	@Override
	public int multiply(int a) throws RemoteException
	{
		acc *= a;
		return acc;
	}
	
	@Override 
	public int divide(int a) throws RemoteException
	{
		acc /= a;
		return acc;
	}
} 
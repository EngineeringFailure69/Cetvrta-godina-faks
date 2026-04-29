import java.rmi.*;
import java.net.MalformedURLException;

public class Client
{
	public static void main(String[] args)
	{
		Calculator calculator;
		try
		{
			calculator = (Calculator) Naming.lookup("rmi://localhost:1099/CalculatorService");
			System.out.println("Add operation: " + calculator.add(10));
			System.out.println("Subtract operation: " + calculator.subtract(5));
			System.out.println("Multiply operation: " + calculator.multiply(5));
			System.out.println("Divide operation: " + calculator.divide(5));
		}
		catch (MalformedURLException e) 
		{
			e.printStackTrace();
		} 
		catch (RemoteException e) 
		{
			e.printStackTrace();
		} 
		catch (NotBoundException e) 
		{
			e.printStackTrace();
		}
	}
}
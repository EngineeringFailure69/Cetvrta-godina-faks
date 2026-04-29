import java.rmi.*;

public interface CarManager extends Remote
{
	boolean requestCar(String address) throws RemoteException;
	Car registerDriver(CarCallback driver) throws RemoteException;
}
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class CarManagerImpl extends UnicastRemoteObject implements CarManager
{
	ArrayList<Car> listaSvihVozila = new ArrayList<Car>();
	ArrayList<String> adreseUReduCekanja = new ArrayList<String>();
	Map<Integer, CarCallback> vozaci = new HashMap<Integer, CarCallback>();
	private static int globalId = 0;
	
	int maxRequests = 10;
	
	public CarManagerImpl() throws RemoteException
	{
		super();
	}
	
	public boolean requestCar(String address) throws RemoteException
	{
		boolean freeCar = false;
		Car car = new Car();
		
		for(Car c : listaSvihVozila)
		{
			if(c.isFree == true && !freeCar)
			{
				c = car;
				freeCar = true;
			}
		}
		
		if(freeCar)
		{
			car.isFree = false;
			vozaci.get(car.id).notifyCar(address);
			return true;
		}
		else if(adreseUReduCekanja.size() < maxRequests)
		{
			adreseUReduCekanja.add(address);
			return true;
		}
		else
			return false;
	}
	
	public Car registerDriver(CarCallback driver) throws RemoteException
	{
		Car car = new Car();
		car.id = globalId++;
		listaSvihVozila.add(car);
		vozaci.put(car.id, driver);
		return car;
	}
}
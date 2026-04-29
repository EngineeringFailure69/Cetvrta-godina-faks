import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class CarManager extends UnicastRemoteObject implements ICarManager{
    ArrayList<Car> cars = new ArrayList<Car>();
    ArrayList<String> waitingList = new ArrayList<String>();
    Map<Integer, ICarCallback> drivers = new HashMap<Integer, ICarCallback>();
    private static int globalId=0;

    int maxRequests = 10;

    public CarManager() throws RemoteException{
        super();
    }

    public boolean requestCar(String address) throws RemoteException{
        boolean freeCar = false;
        Car c = new Car();

        for(Car car : cars){
            if(car.isFree==true && !freeCar){
                c = car;
                freeCar = true;
            }
        }

        if(freeCar){
            c.isFree=false;
            drivers.get(c.id).notifyCar(address);
            return true;
        }else if(waitingList.size() < maxRequests){
            waitingList.add(address);
            return true;
        }else{
            return false;
        }
    }

    public Car registerDriver(ICarCallback driver) throws RemoteException {
        Car c = new Car();
        c.id = globalId++;
        cars.add(c);
        drivers.put(c.id, driver);
        return c;
    }
    
}

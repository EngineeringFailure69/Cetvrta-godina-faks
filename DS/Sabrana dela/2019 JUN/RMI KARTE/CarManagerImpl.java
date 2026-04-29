import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class CarManagerImpl extends UnicastRemoteObject implements CarManager {
    private static int carId=0;
    int maxAddresses;
    ArrayList<Car> cars;
    ArrayList<String> addresses;
    Map<Integer,CarCallback> carMap;

    public CarManagerImpl() throws RemoteException{
        maxAddresses=5;
        cars=new ArrayList<Car>();
        addresses=new ArrayList<String>();
        carMap=new HashMap<Integer,CarCallback>();
        
    }

    @Override
    public boolean requestCar(String address) throws RemoteException {
        for(int i=0;i<cars.size();i++){
            Car current=cars.get(i);
            if(current.isFree==true){
                carMap.get(current.id).notifyCar(address);
                current.isFree=false;
                return true;
            }
        }

        if(foundCar==false && addresses.size()<maxAddresses){
            addresses.add(address);
            return true;
        }
        return false;
    }

    @Override
    public Car addCar(CarCallback clb) throws RemoteException {
        Car c=new Car();
        c.id=carId++;
        cars.add(c);
        carMap.put(c.id,clb);

        return c;
    }
    
}

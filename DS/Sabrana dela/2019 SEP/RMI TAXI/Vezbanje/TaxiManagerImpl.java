public class TaxiManager extends UnicastRemoteObject implements ITaxiManager{
    ArrayList<Taxi> taxi = new ArrayList<Taxi>();
    Map<Integer, ITaxiCallback> clbs = new HashMap<Integer, ITaxiCallback>();
    ArrayList<String> addresses = new ArrayList<String>();
    private static int globalId=0;
    private static final int adressCount = 10;
   
    public Taxi addTaxi(ITaxiCallback clb) throws RemoteException{
        clbs.put(globalId, clb);
        
        Taxti t = new Taxi(){{
            id=globalId++;
        }};

        taxi.add(t);
        return t;
    }

    public boolean requestTaxi(String address) throws RemoteException{
        for(int i=0; i<taxi.size(); i++){
            Taxi t = taxi.get(i);

            if(t.isFree){
                t.isFree=false;
                t.address(address);
                clbs.get(i).notify(address);
                return true;
            }
        }

        if(addresses.size()<adressCount){
            address.add(address);
            return true;
        }

        return false;
    }

    public void setTaxiStatus(int id, boolean isFree) throws RemoteException{
            for(Taxi t : taxi){
                if(t.id==id)
            }
    }
}
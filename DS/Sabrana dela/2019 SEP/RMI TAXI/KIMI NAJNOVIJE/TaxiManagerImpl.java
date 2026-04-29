public class TaxiManagerImpl extends UnicastRemoteObject implements ITaxiManager{
    ArrayList<Taxi> taxi;
    Arraylist<String> addrs;
    Map<Integer,ITaxiCallback> clbs;
    private static int globalId=0;
    private static final int addrSize=10;

    public TaxiManagerImpl(){
        taxi=new ArrayList<Taxi>();
        addrs=new ArrayList<String>();
        clbs=new HashMap<Integer,ITaxiCallback>();
    }

    public Taxi addTaxi(ITaxiCallback clb) throws RemoteException{
        Taxi t=new Taxi();
        t.id=globalId++;
        taxi.add(t);
        clbs.put(t.id,clb);
        return t;
    } 

    public boolean requestTaxi(String address) throws RemoteException{
        for(Taxi t : taxi){
            if(t.isFree==true){
                t.isFree=false;
                clbs.get(t.id).notifyTaxi(address);
                t.address=address;
                return true;
            }
        }
        
        if(addrs.size()<addrSize){
            addrs.add(address);
            return true;
        }
        return false;
    }

    public void setTaxiStatus(int id,boolean isFree) throws RemoteException{
        for(Taxi t : taxi){
            if(t.id==id)
               t.isFree=isFree
        }
    }


}
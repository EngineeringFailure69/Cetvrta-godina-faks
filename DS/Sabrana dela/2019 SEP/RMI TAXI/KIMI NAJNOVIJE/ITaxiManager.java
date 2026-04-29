public interface ITaxiManager extends Remote{
    boolean requestTaxi(String address) throws RemoteException;
    void setTaxiStatus(int id,boolean isFree) throws RemoteException;
    Taxi addTaxi(ITaxiCallback clb) throws RemoteException;
}
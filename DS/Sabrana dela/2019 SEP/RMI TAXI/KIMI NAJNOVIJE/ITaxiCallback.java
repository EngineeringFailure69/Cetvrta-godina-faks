public interface ITaxiCallback extends Remote{
    void notifyTaxi(String address) throws RemoteException;
}
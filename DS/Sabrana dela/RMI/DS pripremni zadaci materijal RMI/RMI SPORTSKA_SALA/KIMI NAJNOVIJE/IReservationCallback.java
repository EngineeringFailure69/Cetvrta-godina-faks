public interface IReservationCallback extends Remote{
    void notify() throws RemoteException;
}
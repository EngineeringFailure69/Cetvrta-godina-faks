public interface IGymReservationManager extends Remote{
    Reservation makeReservation(int d,int m,int h,int num) throws RemoteException;
    Reservation extendsReservation(Reservation reservation,int num) throws RemoteException;
    void cancelReservation(Reservation res) throws RemoteException;
    void addClb(int resId,IReservationCallback clb) throws RemoteException;
}
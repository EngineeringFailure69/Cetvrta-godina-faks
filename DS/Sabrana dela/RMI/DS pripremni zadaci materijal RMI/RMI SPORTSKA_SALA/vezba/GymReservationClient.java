public class GymReservationClient {
    IGymReservationManager m;
    IReservationCallback clb;
    Reservation r;

    public GymReservationClient(){
        m = Naming.lookup("rmi://localhost:1099/GymReservationManager")
        clb = new ReservationCallback()
    }

    public void notifyClient(String msg){
        System.out.println(msg);
    }

    public class ReservationCallback extends UnicastRemoteObject implements IReservationCallback{
        void notify(String msg) throws RemoteException{
            notifyClient(msg);
        }

    }
}

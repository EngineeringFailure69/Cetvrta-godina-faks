import java.util.HashMap;

public class GymReservationManager extends UnicasRemoteObject implements ReservationManager {
    
    HashMap<Integer, IReservationCallback> clbs = new HashMap<Integer, IReservationCallback>();
    ArrayList<Reservation> reservations = new ArrayList<Reservation>();
    static int globalId=0;  

    public void addCallback(IReservationCallback clb, int reservationId) throws RemoteException{
        if(!clbs.containsKey(reservationId)){
            clbs.put(reservationId, clb);
        }
    }

    public Reservation makeReservation(int day, int month, int hour, int numHours) throws RemoteException{
        if(hour+numHours>24)
            return null;

        for(Reservation r :reservations){
            if(r.month==month && r.day==day)
                return null;
        }

        Reservation r = new Reservation();
        r.id = globalId++;
        r.month = month;
        r.hour = hour;
        r.numHours = numHours;  
        
        reservations.add(r);
        return r;
    }
    public Reservation extendReservation(Reservation res, int numExtraHours) throws RemoteException{

        for(Reservation r : reservations)
            if(r.id==res.id){
                if(r.hour+r.num+numExtraHours<24)
                    r.num+=num;
                    return r;
            }
        return null;
    }
    public void cancelReservation(Reservation res) throws RemoteException{
        for(Reservation r : reservations){
            if(r.id==res.id){
                reservations.remove
            }
        }

    }
    

}

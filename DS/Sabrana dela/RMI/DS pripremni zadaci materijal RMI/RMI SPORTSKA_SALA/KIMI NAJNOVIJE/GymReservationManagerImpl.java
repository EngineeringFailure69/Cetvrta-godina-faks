public class GymReservationManagerImpl extends UnicastRemoteObject implements IGymReservationManager{
    private static int resId=0;
    ArrayList<Reservation> res;
    Map<Integer,IReservationCallback> clb;

    public GymReservationManagerImpl() throws RemoteException{
        res=new ArrayList<Reservation>();
        clb=new HashMap<Integer,Reservation>();
    }
   
    public void addClb(int resId,IReservationCallback clb) throws RemoteException{
        clb.put(resId,clb);
    }

    public void cancelReservation(Reservation res) throws RemoteException{
       for(Reservation r:res){ //ne moze da se uklanja iz liste dok se iterira foreach petljom
           if(r.id==res.id){
               res.remove(r);
               clb.get(r.id).notify();
               clb.remove(r.id);
           }
       }
    }

    public Reservation makeReservation(int d,int m,int h,int num) throws RemoteException{
        if(h+num>24)
           return null;
        
        for(Reservation r : res){
            if(r.month==m && r.day==d)
               return null;
        }  
        
        Reservation r = new Reservation(num,d,m,h);
        r.id=resId++;

        res.add(r);
        return r;
    }

    public Reservation extendsReservation(Reservation reservation,int num) throws RemoteException{
        for(Reservation r : res){
            if(r.id==reservation.id && r.hour+r.num+num<=24){
                r.num+=num;
                return r;
            }
        }
        return null;
    }

}
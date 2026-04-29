public class GymReservationClient{
    Reservation r;
    IGymReservationCallback clb;
    IGymReservationManager m;
    
    public GymReservationClient(){
        m=(IGymReservationManager)Naming.lookup("rmi://localhost:1099/Gym");
    }
    public void makeRes(int d,int m,int h, int numH){
        r=m.makeReservation(d,m,h,numH)
        if(r==null){
            System.out.println("Reservation failed")
        }else{
            System.out.println("Reservation made")
            clb=new GymReservationcallbackImpl();
            m.addClb(r.id,clb);
        }
    }

    public void extend(int num){
        Reservation newRes=m.extendsReservation(res,num);
        if(newRes==null)
        {
            System.out.println("Extend failed")
        }
        else{
            r=newRes;
            System.out.println("Extend complete")

        }
    }

    public void cancel(){
        m.cancelReservation(r);
    }
    public void calceled(){
        r=null;
        System.out.println("Reservation canceled")
    }
    public class GymReservationcallbackImpl extends UnicastRemoteObject implements IGymReservationCallback{
        public void notify(){
            canceled();
        }
    }

    public static void main(){
        GymReservationClient client=new GymReservationClient();
        ..
    }
}
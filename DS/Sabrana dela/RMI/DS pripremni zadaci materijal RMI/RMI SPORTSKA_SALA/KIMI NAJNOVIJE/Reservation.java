public class Reservation implements Serializable{
    public int id;
    public int day;
    public int month;
    public int hour;
    public int numHours;

    public Reservation(int num,int d,int m,int h){
        month= m;
        hour=h;
        day=d;
        numHours=num;
    }


}
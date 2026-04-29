import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class Seat extends UnicastRemoteObject {
    int seatNum;
    int seatRow;
    boolean isFree;

    public Seat() throws RemoteException {
        super();
    }

    public Seat(int sNum, int sRow) throws RemoteException {
        super();
        seatNum = sNum;
        seatRow = sRow;
        isFree = true;
    }

    public boolean takeSeat()
    {
        if(isFree)
        {
            isFree = false;
            return true;
        }
        return  false;
    }

    public void freeSeat() {
        isFree = true;
    }

    public String getInfo()
    {
        return "i: " + Integer.toString(seatRow) + ", j: " + Integer.toString(seatNum);
    }


}

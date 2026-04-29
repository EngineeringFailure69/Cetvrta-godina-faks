import java.rmi.RemoteException;

public class ILotoManager extends Remote{
    Ticket playTicket(Vector<Integer> numbers) throws RemoteException;
    void addTicketCallback(int ticketId, ITicketCallback clb) throws RemoteException;
}

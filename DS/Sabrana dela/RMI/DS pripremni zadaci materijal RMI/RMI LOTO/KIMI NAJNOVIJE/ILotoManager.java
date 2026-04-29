public interface ILotoManager extends Remote{
    Ticket playTicket(Vektor<Integer> nums) throws RemoteException;
    void addCallback(int id,ILotoCallback clb) throws RemoteException;
}
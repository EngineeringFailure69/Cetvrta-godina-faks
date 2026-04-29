public interface ILotoCallback extends Remote{
    void winner() throws RemoteException;
    void allWinners(Vector<Integer> winners) throws RemoteException;
}
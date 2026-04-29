import java.rmi.*;

public interface FacultyManager extends Remote
{
	public Exam nadjiIspit(String idIspita) throws RemoteException; 
}
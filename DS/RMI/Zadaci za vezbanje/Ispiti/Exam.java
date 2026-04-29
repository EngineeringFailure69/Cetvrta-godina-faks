import java.rmi.*;

public interface Exam extends Remote
{
	public void prijaviStudentaZaIspit(Student student) throws RemoteException;
	public int vratiBrojPrijavljenihStudenataZaIspit() throws RemoteException;
	public String vratiIdIspitda() throws RemoteException;
	public String vratiNazivIspita() throws RemoteException;
}
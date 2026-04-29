import java.rmi.*;
import java.util.*;
import java.rmi.server.*;

public class ExamImpl extends UnicastRemoteObject implements Exam
{
	private String idIspita;
	private String nazivIspita;
	private int brojPrijavljenihStudenata;
	private Map<String, Student> prijavljeniStudenti;
	
	public ExamImpl(String idIspita, String nazivIspita) throws RemoteException
	{
		this.idIspita = idIspita;
		this.nazivIspita = nazivIspita;
		this.brojPrijavljenihStudenata = 0;
		prijavljeniStudenti = new HashMap<String, Student>();
	}
	
	public void prijaviStudentaZaIspit(Student student) throws RemoteException
	{
		this.prijavljeniStudenti.put(student.vratiIndeks(), student);
		this.brojPrijavljenihStudenata++;
	}
	
	public int vratiBrojPrijavljenihStudenataZaIspit() throws RemoteException
	{
		return brojPrijavljenihStudenata;
	}
	
	public String vratiIdIspitda() throws RemoteException
	{
		return idIspita;
	}
	public String vratiNazivIspita() throws RemoteException
	{
		return nazivIspita;
	}
}
import java.util.*;
import java.rmi.*;
import java.rmi.server.*;

public class FacultyManagerImpl extends UnicastRemoteObject implements FacultyManager
{
	private Map<String, Exam> ispiti;
	
	public FacultyManagerImpl() throws RemoteException
	{
		ispiti = new HashMap<String, Exam>();
		
		Exam ispit1 = new ExamImpl("rm","Racunarske mreze");
		Exam ispit2 = new ExamImpl("ds","Distribuirani sistemi"); //Bez pomocne funkcije se koristi ovaj nacin
 
	    ispiti.put("rm", ispit1);
	    ispiti.put("ds", ispit2); 
	}
	
	public Exam nadjiIspit(String idIspita) throws RemoteException
	{
		ExamImpl ispit = (ExamImpl)ispiti.get(idIspita);
		return ispit;
	}
}
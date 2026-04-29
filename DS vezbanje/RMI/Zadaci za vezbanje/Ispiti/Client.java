import java.rmi.*;
import java.net.MalformedURLException;
import java.io.* ;

public class Client
{
	public static void main(String[] args)
	{
		FacultyManager fakultet;
		
		try
		{
			fakultet = (FacultyManager) Naming.lookup("rmi://localhost:1099/FacultyManagerService");
			
			//Kreiram nekoliko studenata
			String ime1 = "Milun Lune Scekic";
			String email1 = "Lune@gmail.com";
			String brIndeksa1 = "1";

			String ime2 = "Lazar";
			String email2 = "Lazar@gmail.com";
			String brIndeksa2 = "2";
			
			Student student1 = new Student(ime1, email1, brIndeksa1);
			Student student2 = new Student(ime2, email2, brIndeksa2);
			
			String idIspita = "rm";
			
			Exam ispit = fakultet.nadjiIspit(idIspita);
			ispit.prijaviStudentaZaIspit(student1);
			ispit.prijaviStudentaZaIspit(student2);
			
			int brojPrijavljenihStudenataZaIspit = ispit.vratiBrojPrijavljenihStudenataZaIspit();
			System.out.println("\nBroj prijavljenih studenata za ispit " + ispit.vratiNazivIspita() + " je: " + brojPrijavljenihStudenataZaIspit + "\n");
			System.out.println("Prijavljeni studenti su: \n");
			System.out.println("Indeks: " + student1.vratiIndeks() + "\n" + "Ime: " + student1.vratiIme() + "\n" + "Email: " + student1.vratiEmail() + "\n");
			System.out.println("Indeks: " + student2.vratiIndeks() + "\n" + "Ime: " + student2.vratiIme() + "\n" + "Email: " + student2.vratiEmail());
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
		catch(MalformedURLException e)
		{
			e.printStackTrace();
		}
		catch(NotBoundException e)
		{
			e.printStackTrace();
		}
	}
}
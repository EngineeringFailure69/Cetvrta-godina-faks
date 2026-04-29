import java.io.*;

public class Student implements Serializable
{
	private String ime;
	private String email;
	private String brIndeksa;
	
	public Student(String ime, String email, String brIndeksa)
	{
		this.ime = ime;
		this.email = email;
		this.brIndeksa = brIndeksa;
	}
	
	public String vratiIndeks()
	{
		return brIndeksa;
	}
	
	public String vratiIme()
	{
		return ime;
	}
	
	public String vratiEmail()
	{
		return email;
	}
}
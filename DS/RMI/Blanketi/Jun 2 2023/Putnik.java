import java.rmi.*;
import java.io.*;
import java.util.*;

public class Putnik implements Serializable
{
	public String ime;
	public String prezime;
	public String matbr;
	public Soba soba;
	
	public Putnik(String ime, String prezime, String matbr)
	{
		this.ime=ime;
		this.prezime=prezime;
		this.matbr=matbr;
	}
}
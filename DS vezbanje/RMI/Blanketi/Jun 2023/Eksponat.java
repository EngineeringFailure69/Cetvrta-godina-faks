import java.rmi.*;
import java.io.*;

public class Eksponat implements Serializable
{
	public int id;
	public int cena;
	
	public Eksponat(int id, int cena)
	{
		this.id = id;
		this.cena = cena;
	}
}
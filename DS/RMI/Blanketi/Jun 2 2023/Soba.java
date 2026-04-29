import java.rmi.*;
import java.io.*;
import java.util.*;

public class Soba implements Serializable
{
	public int cena;
	public int brojKreveta;
	public boolean raspolozivost;
	
	public Soba(int cena, int brojKreveta, boolean raspolozivost)
	{
		this.cena=cena;
		this.brojKreveta=brojKreveta;
		this.raspolozivost=raspolozivost;
	}
}
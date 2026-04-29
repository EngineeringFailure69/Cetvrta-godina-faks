import java.rmi.*;
import java.io.*;
import java.util.*;

public class Poruka implements Serializable
{
	public String naslov;
	public String sadrzaj;
	
	public Poruka(String naslov, String sadrzaj)
	{
		this.naslov=naslov;
		this.sadrzaj=sadrzaj;
	}
}
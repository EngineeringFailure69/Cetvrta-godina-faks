import java.rmi.*;
import java.io.*;
import java.util.*;

public class Poruka implements Serializable
{
	private String naslov;
	private String poruka;
	
	public Poruka(String naslov, String poruka)
	{
		this.naslov = naslov;
		this.poruka = poruka;
	}
	
	public String getNaslov()
	{
		return naslov;
	}
	public String getPoruka()
	{
		return poruka;
	}
	
	public String toString()
	{
		return this.naslov + "\n" + this.poruka + "\n";
	}
}
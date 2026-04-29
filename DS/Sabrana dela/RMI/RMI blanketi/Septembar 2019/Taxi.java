import java.io.*;

public class Taxi implements Serializable
{
	public int id;
	public String address;
	public boolean isFree;
	public Taxi()
	{
		isFree = true;
	}
}
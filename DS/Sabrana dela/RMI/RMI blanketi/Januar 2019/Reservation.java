import java.io.*;

public class Reservation implements Serializable
{
	public int id;
	public int day;
	public int month;
	public int hour;
	public int numHours;
	
	public Reservation(int day, int month, int hour, int numHours)
	{
		this.day = day;
		this.month = month;
		this.hour = hour;
		this.numHours = numHours;
	}
}
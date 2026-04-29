import java.io.*;

public class User implements Serializable
{
	int id;
	String userName;
	
	public User(String userName)
	{
		this.userName = userName;
	}
}
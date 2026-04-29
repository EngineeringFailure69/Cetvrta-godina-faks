import java.rmi.*;
import java.time.LocalDateTime;
import java.io.*;

public class ChatMessage implements Serializable
{
	User fromUser;
	User toUser;
	String msg;
	int hour;
	int minute;
	
	public ChatMessage(String msg)
	{
		this.msg = msg;
		hour = LocalDateTime.now().getHour();
		minute = LocalDateTime.now().getMinute();
	}
}
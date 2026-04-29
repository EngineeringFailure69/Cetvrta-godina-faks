import java.io.Serializable;
import java.time.LocalDateTime;

public class ChatMessage implements Serializable{
    public User toUser;
    public User fromUser;
    public String msg;
    public int hour;
    public int minute;


    public ChatMessage(String poruka){
        msg=poruka;
        hour=LocalDateTime.now().getHour();
        minute=LocalDateTime.now().getMinute();
    }

}

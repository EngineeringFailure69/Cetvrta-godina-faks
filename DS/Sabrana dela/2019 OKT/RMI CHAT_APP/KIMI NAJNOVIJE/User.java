import java.io.Serializable;

public class User implements Serializable{
    public int id;
    public String userName;

    public User(String ime){
        userName=ime;
    }
}
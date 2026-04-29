import java.io.Serializable;

public class Car implements Serializable {
    public int id;
    public String address;
    public Boolean isFree;

    public Car(){
        isFree = true;
    }
}

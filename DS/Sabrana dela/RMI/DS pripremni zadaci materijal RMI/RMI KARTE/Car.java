import java.io.Serializable;

public class Car implements Serializable {
    public int id;
    public String address;
    public boolean isFree;

    public Car(){
        isFree=true;
    }
}
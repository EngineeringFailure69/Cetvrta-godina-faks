public class TaxiUser{
    ITaxiManager m = Naming.lookup("rmi://localhost:1099/TaxiManager");



    public static void main(){
        if(m.requestTaxi("zlot"))
            return true;
    }
}
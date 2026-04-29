public class TaxiServer{
    public static void main(){
        ITaxiManager m = (ITaxiManager) TaxiManager();
        LocalRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost:1099/TaxiManager", m);
        System.in.read();
    }
}
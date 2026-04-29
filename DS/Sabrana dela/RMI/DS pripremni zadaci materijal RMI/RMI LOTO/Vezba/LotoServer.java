import java.rmi.Naming;

public class LotoServer {
    static void main(){
        ILotoManager m = (ILotoManager) new LotoManager();
        LocalRegisrty.createRegistry(1099);
        Naming.rebind("rmi://localhost:1099/LotoManager", m);
        System.in.read(); 
    }
}

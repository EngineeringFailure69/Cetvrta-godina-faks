public class LotooServer{
    public static void main(){
        ILotoManager m=new LotoManagerImpl();
        LocalRegistry.createRegistry(1099);
        Naming.rebind("rmi://localhost:1099/Loto",m);
        System.in.read();
    }
}
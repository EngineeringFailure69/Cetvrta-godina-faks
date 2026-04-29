public class ChatAppServer {
    public static void main(){
        ChatAppManager m=(ChatAppManager)new ChatAppManagerImpl();
        LocalRegistry.createRegistry(1099);
        Naming.rebind("rmi://locahost:1099/Chat",m);
        System.in.read();
    }
    
}

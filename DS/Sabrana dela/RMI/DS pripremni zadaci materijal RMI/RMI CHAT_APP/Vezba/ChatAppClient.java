public class Klijent{
    IChatAppManager m;
    User me;
    IChatMessageCallback clb;

    public Klijent{
        m = Naming.lookup("rmi://localhost:1099/ChatAppManager");
        me = new User(){{
            username = "Ja";
        }};

        clb = new IChatMessageCallback();
    }

    public void notifyUser(){
        System.out.println("ChatMessage has arrived");
    }

    public class ChatMessageCallback extends UnicastRemoteObject implements IChatMessageCallback{
        public void onChatMessage(){
            notifyUser();
        }
    }
}
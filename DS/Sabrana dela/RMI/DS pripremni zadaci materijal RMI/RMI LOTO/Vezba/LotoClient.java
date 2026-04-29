import java.rmi.server.UnicastRemoteObject;

public class LotoClient {
    ILotoManager m;
    ITicketCallback clb;
    Ticket t;
    
    public LotoClient(){
        m = (ILotoManager) Naming.lookup("rmi://localhost:1099/LotoManager");
        clb = new TicketCallback();

        Vector<Integer> numbers = new Vector<Integer>();

        while(numbers.size() < 7){
            int number = Math.random()*100 % 39+1;
            if(!numbers.contains(number))
                numbers.add(number);
        }


        t = m.playTicket(numbers);
        m.addTicketCallback(t.id, clb);
    }

    public void notifyClient(String msg){
        //stampa
    }

    public class TicketCallback extends UnicastRemoteObject implements TicketCallback{
        public void notify(String msg){
            notifyClient(msg);
        }
    }

    public static void main(){
        new LotoClient();
    }
}

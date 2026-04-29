import java.util.Vector;

public class LotoManager extends UnicastRemoteObject implements ILotoManager {
    ArrayList<Ticket> tickets = new ArrayList<Ticket>();
    Map<Integer, ITicketCallback> clbs = new Hashmap<Integer, ITicketCallback>();
    ArrayList<Integer> izvuceniBrojevi = new ArrayList<Integer>();
    static int globalId=0;
    static boolean izvlacenje=false;

    public Ticket playTicket(Vector<Integer> numbers) throws RemoteException{
        Ticket t= new Ticket();
        t.numbers = numbers;
        t.id = globalId++;
        tickets.add(t);

        return t;
    }

    public void addTicketCallback(int ticketId, ITicketCallback clb) throws RemoteException{
        clbs.put(ticketID, clb);
    }

    private Vector getWinners(){
        int maxHits=0;
        Vector<Integer> v = new Vector<Integer>();

        for(Ticket t : tickets){
            int hits=0;

            for(int number : t.numbers)
                for(int num : izvuceniBrojevi){
                    if(num==number)
                        hits++;
                }

            if(hits==v.maxHits){
                v.add(t.id);
            }else if(hits>maxHits){
                maxHits = hits;
                v = new Vector<Integer>();
                v.add(t.id);
            }
        }

        return v;
    }

    private void drawNumbers(){
        while(izvuceniBrojevi.size() < 7){
            int number = Math.random()*100 % 39+1;
            if(!izvuceniBrojevi.contains(number))
                izvuceniBrojevi.add(number);
        }

        Vector<Integer> winners = getWinners();
        
        for(int number : winners){
            clbs.get(number).notify("bravo!");
        }
    }
}

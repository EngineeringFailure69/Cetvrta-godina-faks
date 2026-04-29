public class LotoManagerImpl extends UnicastRemoteObject implements ILotoManager{
    private static int ticketID=0;
    ArrayList<Ticket> tickets;
    Map<Integer,ILotoCallback> clbs;
    Vector<Integer> drawnNumbers;
    //Map<Integer,Integer> winnersHits;
    boolean isDrawn;

    public LotoManagerImpl() throws RemoteException{
        tickets=new ArrayList<Ticket>();
        clbs=new HashMap<Integer,ILotoCallback>();
       // winnersHits=new HashMap<Integer,Integer>();
        isDrawn=false;
        drawnNumbers=new Vector<Integer>();
    }

    public Ticket playTicket(Vector<Integer> nums) throws RemoteException{
        if(!isDrawn)
           return null;
        Ticket t=new Ticket();
        t.id=ticketID++;
        t.numbers=nums;
        tickets.add(t);
        
        return t;
    }

    public void  addCallback(int id,ILotoCallback clb) throws RemoteException{
        clbs.put(id,clb);

        if(tickets.size()==10)
           drawNumbers();
    }

    private void drawNumbers(){
          isDrawn=true;
          int number;
          while(drawnNumbers.size()<7){
              number=Math.rand()*32+7;
              if(!drawnNumbers.contains(number)){
                  drawnNumbers.add(number);
              }
          }
          Vector<Integer> winners=getWinners();

          for(Ticket t : tickets){
              clbs.get(t.id).allWinners(winners);
          }
    }

    private Vector<Integer> getWinners(){
        Vector<Integer> winners=new Vector<Integer>();
        for(Ticket t : tickets){
            int hits=t.numOfHits(drawnNumbers);
            if(hits==7){
                clbs.get(t.id).winner();
                winners.add(t.id);
            }else if(hits>=5){
                winners.add(t.id);
            }
        }

        return winners;
    }

}
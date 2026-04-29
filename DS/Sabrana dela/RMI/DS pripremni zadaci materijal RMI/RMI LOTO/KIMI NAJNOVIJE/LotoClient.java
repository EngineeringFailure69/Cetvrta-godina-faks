public class LotoClient{
    ILotoManager m;
    Ticket t;
    ILotoCallback clb;
    
    public LotoClient(Vector<Integer> nums){
        clb=new LotoCallbackImpl();
        m=(ILotoManager)Naming.lookup("rmi://localhost:1099/Loto");
        t=m.playTicket(nums);
        if(t==null){
            System.out.println("Already drawn.");
        }else{
            m.addCallback(t.id,clb);
        }
    }

    public void congratulations(){
        System.out.println("You won");
    }
    public void displaywinners(Vector<integer> winners){
        System.out.println("All winners");
        for(Integer i : winners){
          System.out.println(i+"\n");       
        }
    }
    public class LotoCallbackImpl extends UnicastRemoteObject implements ILotoCallback{
        public void winner() throws RemoteException{
            congratulations();
        }
        public void allwinners(Vector<Integer> winners) throws RemoteException{
            displayWinners(winners);
        }
    }

    public static void main(){
        Vector<Integer> nums=new Vector<integer>();
        while(nums.size()<7){
            System.out.println("Enter number between 7 and 39");
            BufferedReader br=new BufferedReader(new InoutStreamReader(System.in));
            int number=Integer.parseInt(br.readLine());
            if(number>=7 && number<=39)
              nums.add(number);
        }
        LotoClient client=new LotoClient(nums);
    }
}
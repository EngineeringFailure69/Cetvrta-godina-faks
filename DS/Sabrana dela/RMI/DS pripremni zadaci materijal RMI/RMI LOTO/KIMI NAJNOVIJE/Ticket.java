public class Ticket implements Serializable{
   public int id;
   public Vector<Integer> numbers; 
   
   public int numOfHits(Vector<Integer> vector){
       int hits=0;
       for(Integer n : vector){
           for(Integer n1 : numbers){
               if(n==n1)
                 hits++;
           }
       }
    return hits;
   }
}
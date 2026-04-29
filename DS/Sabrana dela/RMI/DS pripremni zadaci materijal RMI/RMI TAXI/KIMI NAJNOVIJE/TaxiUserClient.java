public class TaxiUserClient{
    ITaxiManager m;

    public TaxiUserClient(){
        m=Naming.lookup("rmi://localhost:1099/TaxiManager");
    }

    public getTaxi(String address){
        if(m.requestTaxi(address)){
            System.out.println("Poslato vozilo");
        }else{
            System.out.println("Pozovite kasnije");
        }
    }

    public static void main(){
         TaxiUserClient client=new TaxiUserClient();
         client.getTaxi("adresa");
         System.in.read();//dal treba??
    }
}
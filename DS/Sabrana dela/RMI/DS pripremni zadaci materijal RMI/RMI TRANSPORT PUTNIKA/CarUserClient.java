public class CarUserClient {
    String address;
    ICarManager iCarManager;

    public CarUserClient(String address){
        this.address = address;
        iCarManager = (ICarManager) Naming.lookup("rmi://localhost:1099/ICarManager");
    }

    public void request(){
        Boolean carRequest = iCarManager.requestCar(address);
        if(carRequest){
            System.out.println("Kola ce biti poslata na vasu adresu");
        }else{
            System.out.println("Velika guzva probajte kasnije");
        }
    }

    public static void main(String args[]){
        CarUserClient carUserClient = new CarUserClient("address");
        carUserClient.request();
    }

}

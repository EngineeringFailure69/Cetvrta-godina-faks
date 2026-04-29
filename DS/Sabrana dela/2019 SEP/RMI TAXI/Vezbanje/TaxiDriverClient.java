public class TaxiDriver{
    ITaxiManager m = Naming.lookup("rmi://localhost:1099/TaxiManager");
    ITaxiCallback clb= new TaxiCallback();
    Taxi t;

    public TaxiDriver(){
        t = m.addTaxi(clb);
    }
    

    public void notifyDriver{

    }

    public class TaxiCallback extends UnicastRemoteObject implements ITaxiCallback{
        void notify(String address){
            notifyDriver(address);
        }
    }

}
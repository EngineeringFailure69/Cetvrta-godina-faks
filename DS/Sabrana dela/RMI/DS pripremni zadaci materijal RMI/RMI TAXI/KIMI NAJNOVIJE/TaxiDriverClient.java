public class TaxiDriverClient{
    Taxi t;
    ITaxiManager m;
    ITaxiCallback clb;

    public TaxiDriverClient(){
        clb=new TaxiCallbackImpl();
        m=Naming.lookup("rmi://localhost:1099/TaxiManager");
        t=m.addTaxi(clb);
    }

    private void notify(String addr){
        t.address=addr;
        t.isFree=false;
        //m.setTaxiStatus(t.id,false); //isFree==false, moze i u taxiManageru kad se zahteva auto
        //a da se setTaxiStatus koristi samo u klijentu kad se zavrsi voznja
    }

    public class TaxiCallbackImpl extends UnicastRemoteObject implements ITaxiCallback{
        public void notifyTaxi(String address) throws RemoteException{
            notify(address);
        }
    }

    public static void main(){
        new TaxiDriverClient();
    }
}
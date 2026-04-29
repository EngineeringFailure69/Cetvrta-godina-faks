import java.rmi.*;
import java.rmi.server.*;
import java.util.Vector;
import java.awt.Rectangle;
import java.awt.Color;
import java.io.IOException;
import java.util.*; 
import java.net.*;

public class Client 
{	
	public WhiteboardManager tabla = null;
	public WhiteboardCallback tablaCallback = null;
	
	public Client(){}
	
	public void pokreni()
	{
		try
		{
			tabla = (WhiteboardManager) Naming.lookup("rmi://localhost:1099/WhiteboardService");
			tablaCallback = new WhiteboardCallbackImpl();
			tabla.register(tablaCallback);
			
			//Kreiram nekoliko oblika
			//Prvi
			String tip1 = "LINE";
			Color bojaLinije1 = Color.red;
			Color bojaIspune1 = Color.blue;
			boolean indikatorIspunjenosti1 = false;
			Rectangle  oblik1 = new Rectangle(50,50,300,400);
			tabla.dodajNovOblikNaTablu(tip1, bojaLinije1, bojaIspune1, indikatorIspunjenosti1, oblik1);
			//Drugi
			String tip2 = "SQUARE";
			Color bojaLinije2 = Color.blue;
			Color bojaIspune2 = Color.red;
			boolean indikatorIspunjenosti2 = true;
			Rectangle oblik2 = new Rectangle(150,150,500,500);
			tabla.dodajNovOblikNaTablu(tip2, bojaLinije2, bojaIspune2, indikatorIspunjenosti2, oblik2);
			
			tabla.unregister(tablaCallback);
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
		catch(MalformedURLException e)
		{
			e.printStackTrace();
		}
		catch(NotBoundException e)
		{
			e.printStackTrace();
		}
	}
	
	public void prikaziTablu()
	{
		try
		{
			Vector oblici = tabla.vratiSveOblike();
			for(int i = 0; i < oblici.size(); i++)
			{
				String tekst = "";
				Shape oblik = (Shape) oblici.elementAt(i);
				tekst = oblik.prikaziUTekstualnomFormatu();
				System.out.println(tekst);
			}
		}
		catch(RemoteException e)
		{
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args)
	{
		Client klijent = new Client();
		klijent.pokreni();
		
		System.exit(0);
	}
	
	public class WhiteboardCallbackImpl extends UnicastRemoteObject implements WhiteboardCallback
	{
		public WhiteboardCallbackImpl() throws RemoteException{}
		
		public void callback(int verzija) throws RemoteException
		{
			System.out.println("Trenutna verzija table: " + verzija);
			prikaziTablu();
		}
	}
}
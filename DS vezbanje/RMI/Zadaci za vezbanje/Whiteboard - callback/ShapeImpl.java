import java.rmi.*;
import java.rmi.server.UnicastRemoteObject;
import java.awt.*;

public class ShapeImpl extends UnicastRemoteObject implements Shape
{
	int verzija;
	public String tip;
	public Color bojaLinije;
	public Color bojaIspune;
	public boolean ispunjen;
	public Rectangle oblik;
	
	public ShapeImpl(String tip, Color bojaLinije, Color bojaIspune, boolean ispunjen, Rectangle oblik) throws RemoteException
	{
		this.tip = tip;
		this.bojaLinije = bojaLinije;
		this.bojaIspune = bojaIspune;
		this.ispunjen = ispunjen;
		this.oblik = oblik;
	}
	
	public int vratiVerziju() throws RemoteException
	{
		return verzija;
	}
	
	public void postaviVerziju(int verzija) throws RemoteException
	{
		this.verzija = verzija;
	}
	
	public String prikaziUTekstualnomFormatu() throws RemoteException
	{
		String tekst = "";
		tekst = "Tip: " + tip + "\n" + "Boja linije: " + bojaLinije + "\n";
		tekst += "Oblik: \n" + "x: " + oblik.x + "\n" + "y: " + oblik.y + "\n" + "Width: " + oblik.width + "\n" + "Height: " + oblik.height + "\n";
		if(ispunjen)
			tekst += "Popunjen: da\n" + "Boja ispune: "  + bojaIspune + "\n";
		else
			tekst += "Popunjen: ne\n";
		return tekst; //Ovo se vraca na klijent, i ovaj string se kasnije ispisuje na ekranu klijenta
	}
}
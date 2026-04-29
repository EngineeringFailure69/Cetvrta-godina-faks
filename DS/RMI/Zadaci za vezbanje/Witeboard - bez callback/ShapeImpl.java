import java.rmi.*;
import java.awt.*;
import java.io.*;
import java.rmi.server.*;

public class ShapeImpl extends UnicastRemoteObject implements Shape
{
	public String tip;
	public Color bojaLinije;
	public Color bojaIspune;
	public boolean indikatorIspunjenosti;
	public Rectangle oblik;
	
	public ShapeImpl(String tip, Color bojaLinije, Color bojaIspune, boolean indikatorIspunjenosti, Rectangle oblik) throws RemoteException
	{
		this.tip = tip;
		this.bojaLinije = bojaLinije;
		this.bojaIspune = bojaIspune;
		this.indikatorIspunjenosti = indikatorIspunjenosti;
		this.oblik = oblik;
	}
	
	public String predstaviUTekstualnomFormatu()
	{
		String tekst = "";
		tekst = "Tip: " + tip + "\n" + "Boja linije: " + bojaLinije + "\n";
		tekst += "Oblik: \n" + "x: " + oblik.x + "\n" + "y: " + oblik.y + "\n" + "Width: " + oblik.width + "\n" + "Height: " + oblik.height + "\n";
		System.out.println("Tip: " + tip + "\n" + "Boja linije: " + bojaLinije); //Svi ovi System.out.println ispisuju na serveru, mogu da se uklone, ali ja necu jer mi je lepo 
		System.out.println("Oblik: \n" + "x: " + oblik.x + "\n" + "y: " + oblik.y + "\n" + "Width: " + oblik.width + "\n" + "Height: " + oblik.height);
		if(indikatorIspunjenosti)
		{
			System.out.println("Popunjen: da\n" + "Boja ispune: "  + bojaIspune + "\n");
			tekst += "Popunjen: da\n" + "Boja ispune: "  + bojaIspune + "\n";
		}
		else
		{ 
			tekst += "Popunjen: ne\n";
			System.out.println("Popunjen: ne\n");
		}
		return tekst; //Ovo se vraca na klijent, i ovaj string se kasnije ispisuje na ekranu klijenta
	}
}
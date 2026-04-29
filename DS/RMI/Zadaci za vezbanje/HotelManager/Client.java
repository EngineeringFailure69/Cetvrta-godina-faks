import java.rmi.*;
import java.net.*;
import java.io.*;

public class Client
{
	public static void main(String[] args)
	{
		HotelManager hotel;
		try
		{
			hotel = (HotelManager) Naming.lookup("rmi://localhost:1099/HotelService");
			String ime = "Bogoljub";
			String prezime = "Gagic";
			int jmbg = 1234567;
			int cena = 200;
			int brojKreveta = 2;
			
			Putnik putnik = new Putnik(ime, prezime, jmbg);
			Soba soba = hotel.nadjiSobu(cena, brojKreveta);
			
			if(soba == null) System.out.println("Nemamo odgovarajucu sobu.\n");
			else
			{
				soba.rezervacija(putnik);
				System.out.println("Soba je rezervisana!\n");
				System.out.println("Informacije o putniku: \n" + "Ime: " + putnik.ime +  "\n" + "Prezime: " + putnik.prezime + "\n" + "JMBG: " + putnik.jmbg + "\n");
				System.out.println("Informacije o sobi: \n" + "Cena: " + soba.vratiCenu() +  "\n" + "Broj kreveta: " + soba.vratiBrojKreveta() + "\n");
			}
		}
		catch (MalformedURLException e) 
		{
			e.printStackTrace();
		} 
		catch (RemoteException e) 
		{
			e.printStackTrace();
		} 
		catch (NotBoundException e) 
		{
			e.printStackTrace();
		}
	}
}
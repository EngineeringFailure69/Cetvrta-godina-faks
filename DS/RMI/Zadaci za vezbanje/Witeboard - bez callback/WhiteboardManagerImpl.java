import java.rmi.*;
import java.rmi.server.*;
import java.util.*;
import java.awt.*;

public class WhiteboardManagerImpl extends UnicastRemoteObject implements WhiteboardManager
{
	private Vector<Shape> listaOblika;
	
	public WhiteboardManagerImpl() throws RemoteException
	{
		listaOblika = new Vector<Shape>();
	}
	
	public Shape dodajNoviOblik(String tip, Color bojaLinije, Color bojaIspune, boolean indikatorIspunjenosti, Rectangle oblik) throws RemoteException
	{
		Shape crtez = new ShapeImpl(tip, bojaLinije, bojaIspune, indikatorIspunjenosti, oblik);
		listaOblika.addElement(crtez);
		return (ShapeImpl)crtez;
	}
	public Vector<Shape> vratiSveOblike() throws RemoteException
	{
		return listaOblika;
	}
}
import java.rmi.*;
import java.rmi.server.*;
import java.awt.*;
import java.util.*;

public class WhiteboardManagerImpl extends UnicastRemoteObject implements WhiteboardManager
{
	private Vector<Shape> listaOblika;
	private int verzija;
	private ArrayList<WhiteboardCallback> listaCallback = new ArrayList<WhiteboardCallback>();
	
	public WhiteboardManagerImpl() throws RemoteException
	{
		this.verzija = 0;
		listaOblika = new Vector<Shape>();
	}
	
	public Shape dodajNovOblikNaTablu(String tip, Color bojaLinije, Color bojaIspune, boolean ispunjen, Rectangle oblik) throws RemoteException
	{
		verzija++;
		Shape crtez = new ShapeImpl(tip, bojaLinije, bojaIspune, ispunjen, oblik);
		listaOblika.addElement(crtez);
		
		pozoviSveCallbackove();
		
		return (Shape)crtez;
	}
	
	public Vector<Shape> vratiSveOblike() throws RemoteException
	{
		return listaOblika;
	}
	
	public int vratiVerziju() throws RemoteException
	{
		return verzija;
	}
	
	public synchronized void register(WhiteboardCallback callback) throws RemoteException
	{
		listaCallback.add(callback);
	}
	
	public synchronized void unregister(WhiteboardCallback callback) throws RemoteException
	{
		listaCallback.remove(callback);
	}
	
	private void pozoviSveCallbackove()
	{
		for(WhiteboardCallback c : listaCallback)
		{
			if(c != null)
			{
				try
				{
					c.callback(verzija);
				}
				catch(Exception e)
				{
					System.out.println("Greska prilikom callback-a: " + e + "\n");
				}
			}
		}
	}
}
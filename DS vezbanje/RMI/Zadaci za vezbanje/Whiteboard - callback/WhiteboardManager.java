import java.rmi.*;
import java.util.*;
import java.awt.*;

public interface WhiteboardManager extends Remote
{
	Shape dodajNovOblikNaTablu(String tip, Color bojaLinije, Color bojaIspune, boolean ispunjen, Rectangle oblik) throws RemoteException;
	Vector<Shape> vratiSveOblike() throws RemoteException;
	int vratiVerziju() throws RemoteException;
	void register(WhiteboardCallback callback) throws RemoteException;
	void unregister(WhiteboardCallback callback) throws RemoteException;
}
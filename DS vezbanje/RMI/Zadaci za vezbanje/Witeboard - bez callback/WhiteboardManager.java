import java.rmi.*;
import java.util.*;
import java.awt.*;

public interface WhiteboardManager extends Remote
{
	Shape dodajNoviOblik(String tip, Color bojaLinije, Color bojaIspune, boolean indikatorIspunjenosti, Rectangle oblik) throws RemoteException;
	Vector<Shape> vratiSveOblike() throws RemoteException;
}
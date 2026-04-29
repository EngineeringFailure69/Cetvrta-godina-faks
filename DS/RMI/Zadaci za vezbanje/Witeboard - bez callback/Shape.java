import java.rmi.*;
import java.awt.*;
import java.io.*;

public interface Shape extends Remote 
{
	public String predstaviUTekstualnomFormatu() throws RemoteException;
}
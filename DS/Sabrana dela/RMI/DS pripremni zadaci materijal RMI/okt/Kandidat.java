import java.rmi.*;
import java.server.*;
import java.io.*;

public class Kandidat implements Serializable {
	
	private String ime;
	private String prezime;
	
	public Kandidat(){
		ime = " ";
		prezime = " ";
	}
	
	public Kandidat(String i, String p){
		ime = i;
		prezime = p;
	}

}


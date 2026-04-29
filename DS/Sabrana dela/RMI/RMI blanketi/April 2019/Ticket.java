import java.rmi.*;
import java.util.*;
import java.io.*;

public class Ticket implements Serializable
{
	public int id;
	public Vector<Integer> numbers;
	
	public int brojPogodaka(Vector<Integer> brojevi)
	{
		int brojPogodaka = 0;
		for(Integer n : brojevi)
			for(Integer n1 : numbers)
				if(n == n1)
					brojPogodaka++;
		return brojPogodaka;
	}
}

import java.util.Hashtable;
public class KWTable {

	private Hashtable<String, Integer> mTable;
	public KWTable()
	{
		// Inicijalizcaija hash tabele koja pamti kljucne reci
		mTable = new Hashtable<String, Integer>();
		mTable.put("program", Integer.valueOf(sym.PROGRAM));
		mTable.put("var", Integer.valueOf(sym.VAR));
		mTable.put("integer", Integer.valueOf(sym.INTEGER));
		mTable.put("char", Integer.valueOf(sym.CHAR));
		mTable.put("begin", Integer.valueOf(sym.BEGIN));
		mTable.put("end", Integer.valueOf(sym.END));
		mTable.put("read", Integer.valueOf(sym.READ));
		mTable.put("write", Integer.valueOf(sym.WRITE));
		mTable.put("if", Integer.valueOf(sym.IF));
		mTable.put("then", Integer.valueOf(sym.THEN));
		mTable.put("else", Integer.valueOf(sym.ELSE));
	}
	
	/**
	 * Vraca ID kljucne reci 
	 */
	public int find(String keyword)
	{
		Integer symbol = mTable.get(keyword);
		if (symbol != null)
			return symbol.intValue();
		
		// Ako rec nije pronadjena u tabeli kljucnih reci radi se o identifikatoru
		return sym.ID;
	}
	

}

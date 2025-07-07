package SymbolTable;

public class Type extends SymbolNode {
public static int INT = 0;
public static int CHAR = 1;
public static int UNKNOWN = 2;
public static int FLOAT = 3;
public int tkind;
public Type ( String name,
 int typeKind,
 SymbolNode next)
{
super( name, SymbolNode.TYPE, null, next );
this.tkind = typeKind;
this.type = this;
}
}

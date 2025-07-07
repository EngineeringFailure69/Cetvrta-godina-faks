// import sekcija

%%

// sekcija opcija i deklaracija
%class MPLexer
%cup
%line
%column

%eofval{
return new Symbol( sym.EOF );
%eofval}

%{
   public int getLine()
   {
      return yyline;
   }
%}

//stanja
%xstate KOMENTAR
//makroi
slovo = [a-zA-Z]
cifra = [0-9]

%%

// pravila
\(\* { yybegin( KOMENTAR ); }
<KOMENTAR>~"*)" { yybegin( YYINITIAL ); }

[\t\n\r ] { ; }
\[ { return new Symbol( sym.LEFTSQUAREBRACKET ); }
\] { return new Symbol( sym.RIGHTSQUAREBRACKET ); }

//operatori
= { return new Symbol( sym.ASSIGN ); }

//separatori
, { return new Symbol( sym.COMMA ); }

//kljucne reci

//identifikatori
({slovo}|_)({slovo}|{cifra}|_)* { return new Symbol(sym.ID ); }
//konstante
{cifra}+ { return new Symbol( sym.CONST ); }
{cifra}+(\.{cifra}+)([E][+|-]{cifra}+)([F|f|l|L]) { return new Symbol( sym.CONST ); }
{cifra}+\.([E][+|-]{cifra}+)([F|f|l|L]) { return new Symbol( sym.CONST ); }
\"([^\"\\]|\\.)*\" { return new Symbol( sym.CONST ); }
//obrada gresaka
. { System.out.println( "ERROR: " + yytext() ); }

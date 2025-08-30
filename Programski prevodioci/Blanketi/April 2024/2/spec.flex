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
//slovo = [a-zA-Z]
cifra = [0-9]

%%

// pravila
\(\* { yybegin( KOMENTAR ); }
<KOMENTAR>~"*)" { yybegin( YYINITIAL ); }

[\t\n\r ] { ; }

//operatori

//separatori
\{ { return new Symbol( sym.LEFTCURLY ); }
\} { return new Symbol( sym.RIGHTCURLY ); }
\[ { return new Symbol( sym.LEFTSQUARE); }
\] { return new Symbol(sym.RIGHTSQUARE); }
, { return new Symbol( sym.COMMA ); }

//kljucne reci
"int" { return new Symbol(sym.INT); }
"float" { return new Symbol (sym.FLOAT); }
"string" { return new Symbol (sym.STRING); }
"new" {return new Symbol (sym.NEW); }
//identifikatori

//konstante
{cifra}+(\.{cifra}+)?([eE][+-]?{cifra}+)? { return new Symbol( sym.CONST ); } 
([\-\+]?{cifra})+ { return new Symbol( sym.CONST ); }
\"([^\"\\]|\\.)*\" { return new Symbol( sym.CONST ); }
//obrada gresaka
. { System.out.println( "ERROR: " + yytext() ); }
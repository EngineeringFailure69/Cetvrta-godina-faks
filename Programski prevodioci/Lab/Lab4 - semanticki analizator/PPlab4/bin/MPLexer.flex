// import sekcija
import java_cup.runtime.*;

%%
// sekcija deklaracija
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
//macros
slovo = [a-zA-Z]
cifra = [0-9]

%%
// rules section
\%\%			{ yybegin( KOMENTAR ); }
<KOMENTAR>~"\%\%" { yybegin( YYINITIAL ); }


[\t\r\n ]		{ ; }

//operatori
\+				{ return new Symbol( sym.PLUS ); }
\-				{ return new Symbol( sym.MINUS ); }

//separatori
;				{ return new Symbol( sym.SEMICOLON ); }
,				{ return new Symbol( sym.COMMA ); }
:				{ return new Symbol( sym.COLON ); }
=				{ return new Symbol( sym.ASSIGN ); }
\(				{ return new Symbol( sym.LEFTPAR ); }
\)				{ return new Symbol( sym.RIGHTPAR ); }
\{				{ return new Symbol( sym.LEFTCURLY ); }
\}				{ return new Symbol( sym.RIGHTCURLY ); }

//kljucne reci
"main"			{ return new Symbol( sym.MAIN );	}	
"int"			{ return new Symbol( sym.INT );	}
"char"			{ return new Symbol( sym.CHAR );	}
"float"			{ return new Symbol( sym.FLOAT );	}
"when"			{ return new Symbol( sym.WHEN );	}
"case"			{ return new Symbol( sym.CASE );	}

//identifikatori
({slovo}|_)({slovo}|{cifra}|_)*	{ return new Symbol( sym.ID, yytext() ); }

//konstante
\'[^]\'			{ return new Symbol( sym.CONSTCHAR, new Character(yytext().charAt(1)) ); }
//{cifra}+		{ return new Symbol( sym.CONST ); }
0oct[1-7][0-7]* { return new Symbol( sym.CONSTINTEGER, new Integer(yytext()) ); }
0hex[1-9A-F][0-9A-F]* { return new Symbol( sym.CONSTINTEGER, new Integer(yytext()) ); }
0dec[1-9][0-9]* { return new Symbol( sym.CONSTINTEGER, new Integer(yytext()) ); }
[1-9][0-9]* { return new Symbol( sym.CONSTINTEGER, new Integer(yytext()) ); }
{cifra}+\.{cifra}*(E(\+|-)?{cifra}+)? { return new Symbol( sym.CONSTFLOAT, new Float(yytext()) ); }

//obrada greske
.		{ System.out.println( "ERROR: " + yytext() ); }
// import sekcija

%%

// sekcija opcija i deklaracija
%class MPLexer
%function next_token
%type Yytoken
%line
%column
%debug



%eofval{
return new Yytoken( sym.EOF, null, yyline, yycolumn);
%eofval}

%{
//dodatni clanovi generisane klase
KWTable kwTable = new KWTable();
Yytoken getKW()
{
	return new Yytoken( kwTable.find( yytext() ),
	yytext(), yyline, yycolumn );
}
%}

//stanja
%xstate KOMENTAR
//makroi
slovo = [a-zA-Z]
cifra = [0-9]

%%

// pravila
\%\% { yybegin( KOMENTAR ); }
<KOMENTAR>~"\%\%" { yybegin( YYINITIAL ); }

[\t\n\r ] { ; }
\( { return new Yytoken( sym.LEFTPAR, yytext(), yyline, yycolumn ); }
\) { return new Yytoken( sym.RIGHTPAR, yytext(), yyline, yycolumn ); }
\{ { return new Yytoken( sym.LEFTCURLY, yytext(), yyline, yycolumn ); }
\} { return new Yytoken( sym.RIGHTCURLY, yytext(), yyline, yycolumn ); }

//operatori
\+ { return new Yytoken( sym.PLUS,yytext(), yyline, yycolumn ); }
\- { return new Yytoken( sym.MINUS,yytext(), yyline, yycolumn ); }
//separatori
; { return new Yytoken( sym.SEMICOLON, yytext(), yyline, yycolumn ); }
: { return new Yytoken( sym.COLON, yytext(), yyline, yycolumn ); }
, { return new Yytoken( sym.COMMA, yytext(), yyline, yycolumn ); }
= { return new Yytoken( sym.ASSIGN, yytext(), yyline, yycolumn ); }

//kljucne reci
{slovo}+ { return getKW(); }
//identifikatori
({slovo}|_)({slovo}|{cifra}|_)* { return new Yytoken(sym.ID, yytext(),yyline, yycolumn ); }
//konstante
0oct[1-7][0-7]* { return new Yytoken(sym.CONST, yytext(),yyline, yycolumn ); }
0hex[1-9A-F][0-9A-F]* { return new Yytoken(sym.CONST, yytext(),yyline, yycolumn ); }
0dec[1-9][0-9]* { return new Yytoken(sym.CONST, yytext(),yyline, yycolumn ); }
[1-9][0-9]* { return new Yytoken(sym.CONST, yytext(),yyline, yycolumn ); }
'[^]' { return new Yytoken( sym.CONST,yytext(), yyline, yycolumn ); }
{cifra}+\.{cifra}*(E(\+|-)?{cifra}+)? { return new Yytoken(sym.CONST, yytext(),yyline, yycolumn ); }
//obrada gresaka
. { if (yytext() != null && yytext().length() > 0) System.out.println( "ERROR: " + yytext() ); }

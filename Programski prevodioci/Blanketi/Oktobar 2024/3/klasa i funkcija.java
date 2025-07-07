public class SelectExpression extends Expression
{
    private Expression uslov;
    private ArrayList<Expression> izrazi;

    public SelectExpression (Expression uslov, ArrayList<Expression> izrazi)
    {
        this.uslov = uslov;
        this.izrazi = izrazi;
    }

    @Override
    public void translate(BufferedWriter out) throws IOException
    {
        // krajSelect je poslednja labela koja označava kraj celog select izraza
        String krajSelect = ASTNode.genLab();
        uslov.translate(out);
        uslov.genLoad("R1", out);
        for(int i = 0; i < izrazi.size() - 1; i++)
        {
            String krajTekuceg = ASTNode.genLab();
            // Pretpostavljamo da izraze brojimo kao 1-based
            // Ako želimo da ih brojimo kao 0-based umesto i + 1 ostavićemo samo i
            out.write("Load_Const R2, " + (i + 1));
            out.newLine();
            out.write("Compare_Equal R2, R1");
            out.newLine();
            out.write("JumpIfZero R2, " + krajTekuceg);
            out.newLine();
            Expression tekuciIzraz = izrazi.get(i);
            tekuciIzraz.translate(out);
            tekuciIzraz.genLoad("R3", out);
            out.write("Jump" + krajSelect);
            out.newLine();
            out.write(krajTekuceg + ":");
            out.newLine();
        }
        // Prethodna petlja se zavrsava sa pretposlednjim izrazom iz liste jer
        // kod poslednjeg izraza ne postoji posebna labela za njegov kraj.
        // Generisanje koda za poslednji izraz:
        out.write("Load_Const R2, " + izrazi.size());
        out.newLine();
        out.write("Compare_Equal R2, R1");
        out.newLine();
        out.write("JumpIfZero R2, " + krajSelect);
        out.newLine();
        Expression poslednjiIzraz = izrazi.get(izrazi.size() - 1);
        poslednjiIzraz.translate(out);
        poslednjiIzraz.genLoad("R3, out");

        // Zajednicki kraj za ceo select izraz
        out.write(krajSelect + ":");
        out.newLine();
        // U R3 je svakako rezultat koji treba da se smesti u promenljivu
        // rezulztat za objekat this. Naziv promenljive za objekat this
        // treba najpre da generisemo.
        super.result = ASTNode.genLab();
        out.write("Store R3, " + super.result);
        out.newLine();
    }
}
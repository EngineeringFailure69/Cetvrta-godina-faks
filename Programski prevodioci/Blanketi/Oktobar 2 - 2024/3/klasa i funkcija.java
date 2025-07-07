public class SelectStatement extends Statement 
{
    private ArrayList<Expression> selectAlternatives;

    public SelectStatement(ArrayList<Expression> selectAlternatives)
    {
        this.selectAlternatives = selectAlternatives;
    }

    @Override
    public void translate(BufferedWriter out) throws IOException {
        selectAlternatives.translate(out);
    }
}

public class Alternative extends Statement
{
    private Expression exp;
    private Statement stat;

    public Alternative(Expression exp, Statement stat)
    {
        this.exp = exp;
        this.stat  = stat;
    }
    @Override
    public void translate(BufferedWriter out) throws IOException {
        String lblDalje = ASTNode.genLab();
        exp.translate(out);
        exp.genLoad("R1", out);
        out.write("JmpIfZero R1, " + lblDalje);
        stat.translate(out);
        out.write("Jmp" + lblKraj);
        out.write(lblDalje + ":");
    }
}

public class AlternativeList extends Statement
{
     private ArrayList<Alternative> alternatives;
     private String lblKraj;

    public SelectStatement(ArrayList<Alternative> alternatives, String lblKraj)
    {
        this.alternatives = alternatives;
        this.lblKraj = lblKraj;
    }

    public void SetLabelaKraj(String lblKraj)
    {
        this.lblKraj = lblKraj;
    }

    @Override
    public void translate(BufferedWriter out) throws IOException {
        String lblKraj =  ASTNode.genLab();
        for(int i=0; i<alternatives.size(); i++)
        {
            Alternative current = (Alternative)alternatives.get(i);
            current.SetLabelaKraj(lblKraj);
            current.translate(out);
        }
        out.write(lblKraj + ":");
    }
}
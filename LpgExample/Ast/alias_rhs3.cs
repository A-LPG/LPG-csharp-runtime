namespace LpgExample.Ast
{


using LPG2.Runtime;
using System;



 
/**
 *<b>
 *<li>Rule 50:  alias_rhs ::= EOL_KEY
 *</b>
 */
public class alias_rhs3 : ASTNodeToken , Ialias_rhs
{
    public IToken getEOL_KEY() { return leftIToken; }

    public alias_rhs3(IToken token):base(token) {  initialize(); }

    public override void accept(Visitor v) { v.visit(this); }
    public override  void accept(ArgumentVisitor v, object o) { v.visit(this, o); }
    public override object accept(ResultVisitor v) { return v.visit(this); }
    public override  object accept(ResultArgumentVisitor v, object o) { return v.visit(this, o); }
}
}



namespace LpgExample.Ast
{


using LPG2.Runtime;
using System;



 
public abstract class ASTNode : IAst
{
    public IAst getNextAst() { return null; }
    public void setNextAst(IAst n) { }
    protected IToken leftIToken,
                     rightIToken;
    protected IAst parent = null;
    public void setParent(IAst parent) { this.parent = parent; }
    public IAst getParent() { return parent; }

    public IToken getLeftIToken() { return leftIToken; }
    public IToken getRightIToken() { return rightIToken; }
    public IToken[] getPrecedingAdjuncts() { return leftIToken.getPrecedingAdjuncts(); }
    public IToken[] getFollowingAdjuncts() { return rightIToken.getFollowingAdjuncts(); }

    public override string ToString()
    {
        return leftIToken.getILexStream().ToString(leftIToken.getStartOffset(), rightIToken.getEndOffset());
    }

    public ASTNode(IToken token) { this.leftIToken = this.rightIToken = token; }
    public ASTNode(IToken leftIToken, IToken rightIToken)
    {
        this.leftIToken = leftIToken;
        this.rightIToken = rightIToken;
    }

  public  void initialize() {}

    /**
     * A list of all children of this node, excluding the null ones.
     */
    public System.Collections.ArrayList getChildren()
    {
         ArrayListEx<object> list = new ArrayListEx<object>(getAllChildren()) ;
        int k = -1;
        for (int i = 0; i < list.Count; i++)
        {
            object element = list.get(i);
            if (element != null)
            {
                if (++k != i)
                    list.set(k, element);
            }
        }
        for (int i = list.Count - 1; i > k; i--) // remove extraneous elements
            list.remove(i);
        return list;
    }

    /**
     * A list of all children of this node, including the null ones.
     */
    public abstract System.Collections.ArrayList getAllChildren();

    public override bool Equals(object o)
    {
        if (o == this) return true;
        if (! (o is ASTNode)) return false;
        ASTNode other = (ASTNode) o;
        return getLeftIToken().getILexStream() == other.getLeftIToken().getILexStream() &&
               getLeftIToken().getTokenIndex() == other.getLeftIToken().getTokenIndex() &&
               getRightIToken().getILexStream() == other.getRightIToken().getILexStream() &&
               getRightIToken().getTokenIndex() == other.getRightIToken().getTokenIndex();
    }

    public override int GetHashCode()
    {
        int hash = 7;
        if (getLeftIToken().getILexStream() != null) hash = hash * 31 + getLeftIToken().getILexStream().GetHashCode();
        hash = hash * 31 + getLeftIToken().getTokenIndex();
        if (getRightIToken().getILexStream() != null) hash = hash * 31 + getRightIToken().getILexStream().GetHashCode();
        hash = hash * 31 + getRightIToken().getTokenIndex();
        return hash;
    }
    public abstract void accept(Visitor v);
    public abstract void accept(ArgumentVisitor v, object o);
    public abstract object accept(ResultVisitor v);
    public abstract object accept(ResultArgumentVisitor v, object o);
    public virtual void accept(IAstVisitor v) {}
}

}


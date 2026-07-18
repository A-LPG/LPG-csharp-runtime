namespace LPG2.Runtime
{
    public interface IAst
    {
        IAst getNextAst();
        void setNextAst(IAst n);
        IAst getParent();
        IToken getLeftIToken();
        IToken getRightIToken();
        IToken[] getPrecedingAdjuncts();
        IToken[] getFollowingAdjuncts();
        System.Collections.ArrayList getChildren();
        System.Collections.ArrayList getAllChildren();
        void accept(IAstVisitor v);
    }

    
}

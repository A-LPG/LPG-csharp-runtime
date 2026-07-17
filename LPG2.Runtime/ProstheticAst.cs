namespace LPG2.Runtime
{
    /// <summary>
    /// Factory that synthesizes a placeholder AST node for a %Recover
    /// nonterminal that the backtracking parser replays as an ErrorToken
    /// (inserted by scope recovery). It is invoked with the error token and
    /// returns a freshly built node the parser pushes onto the value stack.
    /// </summary>
    public delegate IAst ProstheticAst(IToken errorToken);
}

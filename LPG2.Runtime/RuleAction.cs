namespace LPG2.Runtime
{

    public interface RuleAction
    {
        void ruleAction(int ruleNumber);

        //
        // Parsers generated with automatic_ast and %Recover symbols override
        // this to return factories indexed by ParseTable.getProsthesisIndex.
        // The default (no recover symbols) returns null, in which case the
        // backtracking parser keeps throwing a BadParseException on a replayed
        // nonterminal token.
        //
        ProstheticAst[] getProstheticAst() { return null; }
    }
}
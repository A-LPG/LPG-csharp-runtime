namespace LPG2.Runtime
{

    public interface RuleAction
    {
        void ruleAction(int ruleNumber);

        //
        // Parsers generated with automatic_ast and %Recover symbols override
        // this to return factories indexed by ParseTable.getProsthesisIndex.
        // Implementations without recover symbols return null, in which case
        // the backtracking parser keeps throwing BadParseException on a
        // replayed nonterminal token.
        //
        ProstheticAst[] getProstheticAst();

        //
        // GLR parsers that fall back to BacktrackingParser for %Recover replay
        // override these so generated span/symbol accessors use the BT stacks.
        //
        void setRecoverParser(BacktrackingParser parser);
        BacktrackingParser getRecoverParser();
    }
}

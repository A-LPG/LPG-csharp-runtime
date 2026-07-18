namespace LPG2.Runtime
{

    public interface ParseTable
    {
        int baseCheck(int index);

        int rhs(int index);

        int baseAction(int index);

        int lhs(int index);

        int termCheck(int index);

        int termAction(int index);

        int asb(int index);

        int asr(int index);

        int nasb(int index);

        int nasr(int index);

        int terminalIndex(int index);

        int nonterminalIndex(int index);

        int scopePrefix(int index);

        int scopeSuffix(int index);

        int scopeLhs(int index);

        int scopeLa(int index);

        int scopeStateSet(int index);

        int scopeRhs(int index);

        int scopeState(int index);

        int inSymb(int index);

        string name(int index);

        int originalState(int state);

        int asi(int state);

        int nasi(int state);

        int inSymbol(int state);

        int ntAction(int state, int sym);

        int tAction(int act, int sym);

        int lookAhead(int act, int sym);

        int getErrorSymbol();

        int getScopeUbound();

        int getScopeSize();

        int getMaxNameLength();

        int getNumStates();

        int getNtOffset();

        int getLaStateOffset();

        int getMaxLa();

        int getNumRules();

        int getNumNonterminals();

        int getNumSymbols();

        int getSegmentSize();

        int getStartState();

        int getStartSymbol();

        int getEoftSymbol();

        int getEoltSymbol();

        int getAcceptAction();

        int getErrorAction();

        bool isNullable(int symbol);

        bool isValidForParser();

        bool getBacktrack();

        //
        // True when the table was generated with -glr. Generated *prs always
        // emit an override (false for non-GLR tables) so netstandard2.0 builds
        // do not rely on default interface implementations.
        //
        bool isGLR();

        //
        // Map a nonterminal token kind (NT_OFFSET already applied) to a compact
        // slot in RuleAction.getProstheticAst(). Generated tables always emit
        // an override (returns 0 when the grammar has no %Recover symbols).
        //
        int getProsthesisIndex(int index);
    }
}
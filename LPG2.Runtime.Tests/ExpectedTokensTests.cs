using LPG2.Runtime;
using Xunit;

namespace LPG2.Runtime.Tests;

public sealed class ExpectedTokensTests
{
    private sealed class MockTable : ParseTable
    {
        public int getErrorAction() => 0;
        public int getNtOffset() => 4;
        public int tAction(int state, int sym) =>
            state == 0 && (sym == 1 || sym == 2) ? 1 : 0;
        public int terminalIndex(int sym) => sym;
        public string name(int index) =>
            index == 1 ? "a" : index == 2 ? "b" : "";

        public int baseCheck(int index) => 0;
        public int rhs(int index) => 0;
        public int baseAction(int index) => 0;
        public int lhs(int index) => 0;
        public int termCheck(int index) => 0;
        public int termAction(int index) => 0;
        public int asb(int index) => 0;
        public int asr(int index) => 0;
        public int nasb(int index) => 0;
        public int nasr(int index) => 0;
        public int nonterminalIndex(int index) => 0;
        public int scopePrefix(int index) => 0;
        public int scopeSuffix(int index) => 0;
        public int scopeLhs(int index) => 0;
        public int scopeLa(int index) => 0;
        public int scopeStateSet(int index) => 0;
        public int scopeRhs(int index) => 0;
        public int scopeState(int index) => 0;
        public int inSymb(int index) => 0;
        public int originalState(int state) => 0;
        public int asi(int state) => 0;
        public int nasi(int state) => 0;
        public int inSymbol(int state) => 0;
        public int ntAction(int state, int sym) => 0;
        public int lookAhead(int act, int sym) => 0;
        public int getErrorSymbol() => 0;
        public int getScopeUbound() => 0;
        public int getScopeSize() => 0;
        public int getMaxNameLength() => 0;
        public int getNumStates() => 0;
        public int getLaStateOffset() => 0;
        public int getMaxLa() => 0;
        public int getNumRules() => 0;
        public int getNumNonterminals() => 0;
        public int getNumSymbols() => 0;
        public int getSegmentSize() => 0;
        public int getStartState() => 0;
        public int getStartSymbol() => 0;
        public int getEoftSymbol() => 0;
        public int getEoltSymbol() => 0;
        public int getAcceptAction() => 0;
        public bool isNullable(int symbol) => false;
        public bool isValidForParser() => true;
        public bool getBacktrack() => false;
    }

    [Fact]
    public void ExpectedTerminalNames_returns_sorted_legal_terminals()
    {
        var prs = new MockTable();
        var names = ExpectedTokens.ExpectedTerminalNames(prs, 0);
        Assert.Equal(new[] { "a", "b" }, names);
    }

    [Fact]
    public void ParseIssue_mismatch_fills_expected_from_state()
    {
        var prs = new MockTable();
        var issue = ParseIssue.Mismatch(prs, 0, ParseErrorCodes.ERROR_CODE,
            new SourceSpan(1, 1), "x");
        Assert.Equal(ParseErrorCodes.ERROR_CODE, issue.Code);
        Assert.Equal(new[] { "a", "b" }, issue.Expected);
        Assert.Equal("x", issue.Got);
    }
}

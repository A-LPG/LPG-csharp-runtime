using System.Collections.Generic;

namespace LPG2.Runtime
{
    /// <summary>
    /// Expected-terminals helper for editor completion (antlr4-c3 style).
    /// </summary>
    public static class ExpectedTokens
    {
        public static List<string> ExpectedTerminalNames(ParseTable prs, int state)
        {
            var outList = new List<string>();
            if (prs == null)
                return outList;

            int errorAction = prs.getErrorAction();
            int ntOffset = prs.getNtOffset();
            var unique = new SortedSet<string>();
            for (int sym = 1; sym < ntOffset; sym++)
            {
                int act = prs.tAction(state, sym);
                if (act == errorAction)
                    continue;
                string n = prs.name(prs.terminalIndex(sym));
                if (!string.IsNullOrEmpty(n))
                    unique.Add(n);
            }
            outList.AddRange(unique);
            return outList;
        }
    }
}

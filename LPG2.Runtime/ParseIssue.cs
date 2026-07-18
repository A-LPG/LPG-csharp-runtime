using System.Collections.Generic;

namespace LPG2.Runtime
{
    /// <summary>
    /// Unified parse-error shape: code / span / expected / got.
    /// </summary>
    public sealed class ParseIssue
    {
        public int Code { get; }
        public SourceSpan Span { get; }
        public IReadOnlyList<string> Expected { get; }
        public string Got { get; }

        public ParseIssue(int code, SourceSpan span, IReadOnlyList<string> expected, string got)
        {
            Code = code;
            Span = span;
            Expected = expected ?? new string[0];
            Got = got ?? "";
        }

        public static ParseIssue Mismatch(ParseTable prs, int state, int code, SourceSpan span, string got)
        {
            return new ParseIssue(code, span, ExpectedTokens.ExpectedTerminalNames(prs, state), got);
        }
    }
}

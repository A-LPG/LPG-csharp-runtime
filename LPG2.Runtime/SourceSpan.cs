namespace LPG2.Runtime
{
    /// <summary>
    /// Source location span for structured parse diagnostics.
    /// </summary>
    public readonly struct SourceSpan
    {
        public int StartOffset { get; }
        public int EndOffset { get; }

        public SourceSpan(int startOffset, int endOffset)
        {
            StartOffset = startOffset;
            EndOffset = endOffset;
        }
    }
}

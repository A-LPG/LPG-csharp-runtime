namespace LPG2.Runtime
{
    /// <summary>
    /// A GSS predecessor edge labeled with a recognized grammar symbol.
    /// </summary>
    public sealed class GssEdge
    {
        internal readonly GssNode predecessor;
        internal readonly int symbol;
        internal readonly int location;
        internal readonly object semantic;
        internal readonly SppfNode sppf;

        internal GssEdge(GssNode predecessor, int symbol, int location,
                         object semantic, SppfNode sppf)
        {
            this.predecessor = predecessor;
            this.symbol = symbol;
            this.location = location;
            this.semantic = semantic;
            this.sppf = sppf;
        }

        public GssNode getPredecessor() { return predecessor; }
        public int getSymbol() { return symbol; }
        public int getLocation() { return location; }
        public object getSemantic() { return semantic; }
        public SppfNode getSppf() { return sppf; }
    }
}

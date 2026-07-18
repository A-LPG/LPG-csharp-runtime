using System.Collections.Generic;

namespace LPG2.Runtime
{
    /// <summary>Graph-structured stack node: LR state at an input index.</summary>
    public sealed class GssNode
    {
        internal readonly int state;
        internal readonly int index;
        internal readonly List<GssEdge> edges = new List<GssEdge>();

        internal GssNode(int state, int index)
        {
            this.state = state;
            this.index = index;
        }

        public int getState() { return state; }
        public int getIndex() { return index; }
        public IReadOnlyList<GssEdge> getEdges() { return edges.AsReadOnly(); }
    }
}

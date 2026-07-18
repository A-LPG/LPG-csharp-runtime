using System.Collections.Generic;

namespace LPG2.Runtime
{
    /// <summary>
    /// Shared packed parse forest symbol node, keyed by grammar symbol and span.
    /// </summary>
    public sealed class SppfNode
    {
        public sealed class Packed
        {
            internal readonly int rule;
            internal readonly SppfNode[] children;
            internal readonly object semantic;

            internal Packed(int rule, SppfNode[] children, object semantic)
            {
                this.rule = rule;
                this.children = children ?? new SppfNode[0];
                this.semantic = semantic;
            }

            public int getRule() { return rule; }

            public IReadOnlyList<SppfNode> getChildren()
            {
                List<SppfNode> result = new List<SppfNode>();
                foreach (SppfNode child in children)
                    if (child != null)
                        result.Add(child);
                return result.AsReadOnly();
            }

            public object getSemantic() { return semantic; }
        }

        internal readonly int grammarSymbol;
        internal readonly int leftExtent;
        internal readonly int rightExtent;
        internal readonly List<Packed> packs = new List<Packed>();
        internal object astForest;

        internal SppfNode(int grammarSymbol, int leftExtent, int rightExtent)
        {
            this.grammarSymbol = grammarSymbol;
            this.leftExtent = leftExtent;
            this.rightExtent = rightExtent;
        }

        public int getGrammarSymbol() { return grammarSymbol; }
        public int getLeftExtent() { return leftExtent; }
        public int getRightExtent() { return rightExtent; }
        public IReadOnlyList<Packed> getPacks() { return packs.AsReadOnly(); }
        public object getAstForest() { return astForest; }
    }
}

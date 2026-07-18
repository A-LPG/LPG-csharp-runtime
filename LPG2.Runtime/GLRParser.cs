using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace LPG2.Runtime
{
/// <summary>
/// Generalized LR driver over LPG GLR conflict tables (GLR v2).
/// Configurations share GSS prefixes, reductions populate an SPPF, and
/// compatible AST alternatives are projected through IAst.getNextAst().
/// </summary>
public class GLRParser : Stacks
{
    private static readonly object NULL_RESULT = new object();

    private Monitor monitor;
    private int START_STATE;
    private int NUM_RULES;
    private int NT_OFFSET;
    private int LA_STATE_OFFSET;
    private int ACCEPT_ACTION;
    private int ERROR_ACTION;

    private TokenStream tokStream;
    private ParseTable prs;
    private RuleAction ra;

    private bool taking_actions;
    private int currentAction;
    private int lastToken;
    private int parseStackRoot;
    private int frameTop;
    private int[] frameLocation;
    private object[] frameParse;
    private Dictionary<ReductionKey, IAst> familyCache;
    private Dictionary<ForestKey, IAst> forestCache;
    private Dictionary<GssKey, GssNode> gssNodes;
    private Dictionary<SppfKey, SppfNode> sppfNodes;
    private SppfNode sppfRoot;
    private int sppfSymbolCount;

    private sealed class AcceptCandidate
    {
        internal readonly object ast;
        internal readonly int grammarSymbol;
        internal readonly SppfNode sppf;

        internal AcceptCandidate(object ast, int grammarSymbol, SppfNode sppf)
        {
            this.ast = ast;
            this.grammarSymbol = grammarSymbol;
            this.sppf = sppf;
        }
    }

    private sealed class Config
    {
        internal int[] stateStack;
        internal int[] symbolStack;
        internal object[] parseStack;
        internal int[] locationStack;
        internal SppfNode[] sppfStack;
        internal GssNode gssTip;
        internal int stateStackTop;
        internal int currentAction;
        internal int curtok;
        internal int lastToken;
        internal int currentKind;

        internal Config Copy()
        {
            Config c = new Config();
            c.stateStackTop = stateStackTop;
            c.currentAction = currentAction;
            c.curtok = curtok;
            c.lastToken = lastToken;
            c.currentKind = currentKind;
            c.gssTip = gssTip;
            if (stateStack != null)
            {
                c.stateStack = (int[]) stateStack.Clone();
                c.symbolStack = (int[]) symbolStack.Clone();
                c.parseStack = (object[]) parseStack.Clone();
                c.locationStack = (int[]) locationStack.Clone();
                c.sppfStack = (SppfNode[]) sppfStack.Clone();
            }
            return c;
        }
    }

    private sealed class ConfigKey : IEquatable<ConfigKey>
    {
        private readonly Config config;
        private readonly int hash;

        internal ConfigKey(Config config)
        {
            this.config = config;
            unchecked
            {
                int h = 31 * config.curtok + config.currentKind;
                h = 31 * h + config.lastToken;
                h = 31 * h + config.currentAction;
                for (int i = 0; i <= config.stateStackTop; i++)
                {
                    h = 31 * h + config.stateStack[i];
                    h = 31 * h + config.locationStack[i];
                    h = 31 * h + config.symbolStack[i];
                }
                hash = h;
            }
        }

        public override int GetHashCode() { return hash; }

        public bool Equals(ConfigKey other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other == null)
                return false;
            Config a = config;
            Config b = other.config;
            if (a.curtok != b.curtok || a.currentKind != b.currentKind
                    || a.lastToken != b.lastToken
                    || a.currentAction != b.currentAction
                    || a.stateStackTop != b.stateStackTop)
                return false;
            for (int i = 0; i <= a.stateStackTop; i++)
            {
                if (a.stateStack[i] != b.stateStack[i]
                        || a.locationStack[i] != b.locationStack[i]
                        || a.symbolStack[i] != b.symbolStack[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj) { return Equals(obj as ConfigKey); }
    }

    private sealed class ReductionKey : IEquatable<ReductionKey>
    {
        private readonly int rule;
        private readonly int lastToken;
        private readonly int[] locations;
        private readonly int[] grammarSymbols;
        private readonly object[] semanticValues;
        private readonly int hash;

        internal ReductionKey(int rule, int lastToken, int rhs, int frameTop,
                              int[] locationStack, int[] symbolStack,
                              object[] parseStack)
        {
            this.rule = rule;
            this.lastToken = lastToken;
            locations = new int[rhs];
            grammarSymbols = new int[rhs];
            semanticValues = new object[rhs];
            unchecked
            {
                int h = 31 * rule + lastToken;
                for (int i = 0; i < rhs; i++)
                {
                    int index = frameTop + i;
                    locations[i] = locationStack[index];
                    grammarSymbols[i] = symbolStack[index];
                    semanticValues[i] = parseStack[index];
                    h = 31 * h + locations[i];
                    h = 31 * h + grammarSymbols[i];
                    h = 31 * h + IdentityHash(semanticValues[i]);
                }
                hash = h;
            }
        }

        public override int GetHashCode() { return hash; }

        public bool Equals(ReductionKey other)
        {
            if (ReferenceEquals(this, other))
                return true;
            if (other == null || rule != other.rule || lastToken != other.lastToken
                    || locations.Length != other.locations.Length)
                return false;
            for (int i = 0; i < locations.Length; i++)
            {
                if (locations[i] != other.locations[i]
                        || grammarSymbols[i] != other.grammarSymbols[i]
                        || !ReferenceEquals(semanticValues[i], other.semanticValues[i]))
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj) { return Equals(obj as ReductionKey); }
    }

    private sealed class ForestKey : IEquatable<ForestKey>
    {
        private readonly int grammarSymbol;
        private readonly ILexStream lexStream;
        private readonly int leftToken;
        private readonly int rightToken;
        private readonly int hash;

        internal ForestKey(int grammarSymbol, IAst ast)
        {
            IToken left = ast.getLeftIToken();
            IToken right = ast.getRightIToken();
            this.grammarSymbol = grammarSymbol;
            lexStream = left == null ? null : left.getILexStream();
            leftToken = left == null ? -1 : left.getTokenIndex();
            rightToken = right == null ? -1 : right.getTokenIndex();
            unchecked
            {
                int h = 31 * grammarSymbol + IdentityHash(lexStream);
                h = 31 * h + leftToken;
                hash = 31 * h + rightToken;
            }
        }

        internal bool IsPackable() { return leftToken >= 0 && rightToken >= 0; }
        public override int GetHashCode() { return hash; }

        public bool Equals(ForestKey other)
        {
            return other != null
                && grammarSymbol == other.grammarSymbol
                && ReferenceEquals(lexStream, other.lexStream)
                && leftToken == other.leftToken
                && rightToken == other.rightToken;
        }

        public override bool Equals(object obj) { return Equals(obj as ForestKey); }
    }

    private struct GssKey : IEquatable<GssKey>
    {
        private readonly int state;
        private readonly int index;

        internal GssKey(int state, int index)
        {
            this.state = state;
            this.index = index;
        }

        public bool Equals(GssKey other)
        {
            return state == other.state && index == other.index;
        }

        public override bool Equals(object obj)
        {
            return obj is GssKey && Equals((GssKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked { return 31 * state + index; }
        }
    }

    private struct SppfKey : IEquatable<SppfKey>
    {
        private readonly int symbol;
        private readonly int left;
        private readonly int right;

        internal SppfKey(int symbol, int left, int right)
        {
            this.symbol = symbol;
            this.left = left;
            this.right = right;
        }

        public bool Equals(SppfKey other)
        {
            return symbol == other.symbol && left == other.left && right == other.right;
        }

        public override bool Equals(object obj)
        {
            return obj is SppfKey && Equals((SppfKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked { return (31 * symbol + left) * 31 + right; }
        }
    }

    private static int IdentityHash(object value)
    {
        return value == null ? 0 : RuntimeHelpers.GetHashCode(value);
    }

    private int lookahead(int act, int token)
    {
        act = prs.lookAhead(act - LA_STATE_OFFSET, tokStream.getKind(token));
        return act > LA_STATE_OFFSET
            ? lookahead(act, tokStream.getNext(token))
            : act;
    }

    private int tAction(int state, int sym, int curtok)
    {
        int act = prs.tAction(state, sym);
        return act > LA_STATE_OFFSET
            ? lookahead(act, tokStream.getNext(curtok))
            : act;
    }

    private void expandConflict(int act, List<int> result)
    {
        for (int i = act; ; i++)
        {
            int candidate = prs.baseAction(i);
            if (candidate == 0)
                break;
            result.Add(candidate);
        }
    }

    public int getCurrentRule()
    {
        if (taking_actions)
            return currentAction;
        throw new UnavailableParserInformationException();
    }

    public override int getToken(int i)
    {
        return taking_actions
            ? frameLocation[frameTop + (i - 1)]
            : base.getToken(i);
    }

    public new object getSym(int i)
    {
        return taking_actions
            ? frameParse[frameTop + (i - 1)]
            : base.getSym(i);
    }

    public new void setSym1(object ast)
    {
        if (taking_actions)
            frameParse[frameTop] = ast;
        else
            base.setSym1(ast);
    }

    public int getFirstToken()
    {
        if (taking_actions)
            return getToken(1);
        throw new UnavailableParserInformationException();
    }

    public int getFirstToken(int i)
    {
        if (taking_actions)
            return getToken(i);
        throw new UnavailableParserInformationException();
    }

    public int getLastToken()
    {
        if (taking_actions)
            return lastToken;
        throw new UnavailableParserInformationException();
    }

    public int getLastToken(int i)
    {
        if (taking_actions)
            return i >= prs.rhs(currentAction)
                ? lastToken
                : tokStream.getPrevious(getToken(i + 1));
        throw new UnavailableParserInformationException();
    }

    /// <summary>Root SPPF node from the last successful error-free parse.</summary>
    public SppfNode getSppfRoot() { return sppfRoot; }

    /// <summary>Number of distinct SPPF symbol nodes in the last parse.</summary>
    public int getSppfSymbolCount() { return sppfSymbolCount; }

    public void setMonitor(Monitor monitor) { this.monitor = monitor; }

    public void reset(Monitor monitor, TokenStream tokStream)
    {
        this.monitor = monitor;
        this.tokStream = tokStream;
        taking_actions = false;
        sppfRoot = null;
        sppfSymbolCount = 0;
    }

    public void reset(TokenStream tokStream)
    {
        reset(null, tokStream);
    }

    public void reset(Monitor monitor, TokenStream tokStream,
                      ParseTable prs, RuleAction ra)
    {
        reset(monitor, tokStream);
        this.prs = prs;
        this.ra = ra;

        START_STATE = prs.getStartState();
        NUM_RULES = prs.getNumRules();
        NT_OFFSET = prs.getNtOffset();
        LA_STATE_OFFSET = prs.getLaStateOffset();
        ACCEPT_ACTION = prs.getAcceptAction();
        ERROR_ACTION = prs.getErrorAction();

        if (!prs.isValidForParser())
            throw new BadParseSymFileException();
        if (!prs.isGLR())
            throw new NotGLRParseTableException();
    }

    public void reset(TokenStream tokStream, ParseTable prs, RuleAction ra)
    {
        reset(null, tokStream, prs, ra);
    }

    public GLRParser() { }

    public GLRParser(TokenStream tokStream, ParseTable prs, RuleAction ra)
    {
        reset(null, tokStream, prs, ra);
    }

    public GLRParser(Monitor monitor, TokenStream tokStream,
                     ParseTable prs, RuleAction ra)
    {
        reset(monitor, tokStream, prs, ra);
    }

    public object parse()
    {
        return parseEntry(0);
    }

    public object parse(int max_error_count)
    {
        return parseEntry(0, max_error_count);
    }

    public object parseEntry(int marker_kind)
    {
        return parseEntryNoRepair(marker_kind);
    }

    public object parseEntry(int marker_kind, int max_error_count)
    {
        try
        {
            return parseEntryNoRepair(marker_kind);
        }
        catch (BadParseException)
        {
            if (max_error_count <= 0)
                throw;

            BacktrackingParser bt =
                new BacktrackingParser(monitor, tokStream, prs, ra);
            ra.setRecoverParser(bt);
            try
            {
                return bt.fuzzyParseEntry(marker_kind, max_error_count);
            }
            finally
            {
                ra.setRecoverParser(null);
            }
        }
    }

    private object parseEntryNoRepair(int marker_kind)
    {
        tokStream.reset();
        familyCache = new Dictionary<ReductionKey, IAst>();
        forestCache = new Dictionary<ForestKey, IAst>();
        gssNodes = new Dictionary<GssKey, GssNode>();
        sppfNodes = new Dictionary<SppfKey, SppfNode>();
        sppfRoot = null;
        int firstTok = tokStream.getToken();
        int previous = tokStream.getPrevious(firstTok);
        int startTok = marker_kind == 0 ? firstTok : previous;
        int startKind = marker_kind == 0 ? tokStream.getKind(firstTok) : marker_kind;
        parseStackRoot = marker_kind == 0 ? 0 : 1;

        Config start = new Config();
        start.stateStackTop = -1;
        start.currentAction = START_STATE;
        start.curtok = startTok;
        start.lastToken = previous;
        start.currentKind = startKind;
        ensureCapacity(start, 16);

        List<Config> live = new List<Config>();
        live.Add(start);
        List<AcceptCandidate> accepts = new List<AcceptCandidate>();
        int errorTok = startTok;
        int outerGuard = prs.getNumStates() * 64
            + tokStream.getStreamLength() * 8 + 256;

        while (live.Count > 0)
        {
            if (monitor != null && monitor.isCancelled())
                return null;
            if (--outerGuard < 0)
                throw new InvalidOperationException(
                    "cyclic/epsilon-loop grammar not supported by GLR v2");

            List<Config> next = new List<Config>();
            Dictionary<ConfigKey, List<Config>> packed =
                new Dictionary<ConfigKey, List<Config>>();

            foreach (Config cfg in live)
            {
                if (cfg.curtok > errorTok)
                    errorTok = cfg.curtok;

                List<Config> stepResults = new List<Config>();
                List<AcceptCandidate> stepAccepts = new List<AcceptCandidate>();
                stepConfig(cfg, stepResults, stepAccepts);

                foreach (AcceptCandidate candidate in stepAccepts)
                    packAccept(accepts, candidate);

                foreach (Config result in stepResults)
                {
                    ConfigKey key = new ConfigKey(result);
                    List<Config> bucket;
                    if (!packed.TryGetValue(key, out bucket))
                    {
                        bucket = new List<Config>();
                        bucket.Add(result);
                        packed.Add(key, bucket);
                        next.Add(result);
                    }
                    else
                    {
                        bool merged = false;
                        foreach (Config existing in bucket)
                        {
                            if (canPackParseStacks(existing, result))
                            {
                                packParseStacks(existing, result);
                                merged = true;
                                break;
                            }
                        }
                        if (!merged)
                        {
                            bucket.Add(result);
                            next.Add(result);
                        }
                    }
                }
            }

            if (accepts.Count > 0 && next.Count == 0)
                break;

            live = next;
            if (live.Count == 0 && accepts.Count == 0)
                throw new BadParseException(errorTok);
        }

        if (accepts.Count == 0)
            throw new BadParseException(errorTok);

        object root = accepts[0].ast;
        int rootSymbol = accepts[0].grammarSymbol;
        sppfRoot = accepts[0].sppf;
        for (int i = 1; i < accepts.Count; i++)
        {
            AcceptCandidate other = accepts[i];
            if (other.grammarSymbol != rootSymbol)
                throw new InvalidOperationException(
                    "GLR accepted distinct start symbols");
            if (sppfRoot == null)
                sppfRoot = other.sppf;
            if (!appendNextAst(root, other.ast))
                throw new InvalidOperationException(
                    "overlapping GLR accept forests");
        }
        sppfSymbolCount = sppfNodes.Count;
        return ReferenceEquals(root, NULL_RESULT) ? null : root;
    }

    private void stepConfig(Config cfg, List<Config> result,
                            List<AcceptCandidate> accepts)
    {
        List<Config> work = new List<Config>();
        work.Add(cfg.Copy());
        int guard = prs.getNumStates() * 4 + 8;

        while (work.Count > 0)
        {
            if (--guard < 0)
                throw new InvalidOperationException(
                    "cyclic/epsilon-loop grammar not supported by GLR v2");

            int last = work.Count - 1;
            Config c = work[last];
            work.RemoveAt(last);
            ensureCapacity(c, c.stateStackTop + 2);
            c.stateStack[++c.stateStackTop] = c.currentAction;
            c.locationStack[c.stateStackTop] = c.curtok;
            c.symbolStack[c.stateStackTop] = 0;
            c.sppfStack[c.stateStackTop] = null;
            if (c.stateStackTop != parseStackRoot)
                c.parseStack[c.stateStackTop] = null;
            c.gssTip = gssPush(c.gssTip, c.currentAction, c.curtok,
                               0, null, null);

            int act = tAction(c.currentAction, c.currentKind, c.curtok);
            List<int> candidates = new List<int>();
            if (act > ACCEPT_ACTION && act < ERROR_ACTION)
                expandConflict(act, candidates);
            else
                candidates.Add(act);

            for (int i = 0; i < candidates.Count; i++)
            {
                Config fork = candidates.Count == 1 ? c : c.Copy();
                applyConcreteAction(fork, candidates[i], work, result, accepts);
            }
        }
    }

    private void applyConcreteAction(Config fork, int candidate,
                                     List<Config> work,
                                     List<Config> result,
                                     List<AcceptCandidate> accepts)
    {
        if (candidate <= NUM_RULES)
        {
            fork.stateStackTop--;
            fork.gssTip = gssPop(fork.gssTip);
            applyReduceClosure(fork, candidate, work);
        }
        else if (candidate > ERROR_ACTION)
        {
            fork.symbolStack[fork.stateStackTop] = fork.currentKind;
            SppfNode terminal = terminalSppf(fork.currentKind, fork.curtok);
            fork.sppfStack[fork.stateStackTop] = terminal;
            fork.gssTip = gssRelabel(fork.gssTip, fork.currentKind,
                                     fork.curtok, null, terminal);
            fork.lastToken = fork.curtok;
            fork.curtok = tokStream.getNext(fork.curtok);
            fork.currentKind = tokStream.getKind(fork.curtok);
            applyReduceClosure(fork, candidate - ERROR_ACTION, work);
        }
        else if (candidate < ACCEPT_ACTION)
        {
            fork.symbolStack[fork.stateStackTop] = fork.currentKind;
            SppfNode terminal = terminalSppf(fork.currentKind, fork.curtok);
            fork.sppfStack[fork.stateStackTop] = terminal;
            fork.gssTip = gssRelabel(fork.gssTip, fork.currentKind,
                                     fork.curtok, null, terminal);
            fork.lastToken = fork.curtok;
            fork.curtok = tokStream.getNext(fork.curtok);
            fork.currentKind = tokStream.getKind(fork.curtok);
            fork.currentAction = candidate;
            result.Add(fork);
        }
        else if (candidate == ACCEPT_ACTION)
        {
            object root = null;
            int rootSymbol = 0;
            if (fork.parseStack != null && parseStackRoot < fork.parseStack.Length)
                root = fork.parseStack[parseStackRoot];
            if (fork.symbolStack != null && parseStackRoot <= fork.stateStackTop)
                rootSymbol = fork.symbolStack[parseStackRoot];
            SppfNode rootSppf = null;
            if (fork.sppfStack != null && parseStackRoot < fork.sppfStack.Length)
                rootSppf = fork.sppfStack[parseStackRoot];
            accepts.Add(new AcceptCandidate(
                root ?? NULL_RESULT, rootSymbol, rootSppf));
        }
    }

    private void applyReduceClosure(Config fork, int rule, List<Config> work)
    {
        int action = rule;
        do
        {
            int rhs = prs.rhs(action);
            if (fork.stateStackTop - (rhs - 1) < 0)
                throw new InvalidOperationException("GLR reduce stack underflow");

            SppfNode[] children = new SppfNode[rhs];
            for (int i = 0; i < rhs; i++)
                children[i] =
                    fork.sppfStack[fork.stateStackTop - rhs + 1 + i];

            fork.stateStackTop -= rhs - 1;
            if (rhs > 0)
            {
                for (int i = 0; i < rhs - 1; i++)
                    fork.gssTip = gssPop(fork.gssTip);
            }
            else
            {
                ensureCapacity(fork, fork.stateStackTop + 1);
                fork.gssTip = gssPush(
                    fork.gssTip,
                    fork.stateStack[fork.stateStackTop],
                    fork.locationStack[fork.stateStackTop],
                    0, null, null);
            }

            ReductionKey reductionKey = new ReductionKey(
                action, fork.lastToken, rhs, fork.stateStackTop,
                fork.locationStack, fork.symbolStack, fork.parseStack);
            currentAction = action;
            lastToken = fork.lastToken;
            frameTop = fork.stateStackTop;
            frameLocation = fork.locationStack;
            frameParse = fork.parseStack;

            taking_actions = true;
            try
            {
                ra.ruleAction(action);
            }
            finally
            {
                taking_actions = false;
            }

            int lhs = prs.lhs(action);
            int lhsSymbol = NT_OFFSET + lhs;
            object semantic = fork.parseStack[fork.stateStackTop];
            IAst ast = semantic as IAst;
            if (ast != null)
            {
                IAst canonical;
                if (!familyCache.TryGetValue(reductionKey, out canonical))
                {
                    ForestKey forestKey = new ForestKey(lhsSymbol, ast);
                    if (!forestKey.IsPackable()
                            || !forestCache.TryGetValue(forestKey, out canonical))
                    {
                        canonical = ast;
                        if (forestKey.IsPackable())
                            forestCache[forestKey] = canonical;
                    }
                    else if (!ReferenceEquals(canonical, ast)
                            && !appendNextAst(canonical, ast))
                    {
                        throw new InvalidOperationException(
                            "cannot merge GLR production family");
                    }
                    familyCache[reductionKey] = canonical;
                }
                fork.parseStack[fork.stateStackTop] = canonical;
                semantic = canonical;
            }

            int leftExtent = fork.locationStack[fork.stateStackTop];
            int rightExtent = fork.lastToken;
            ast = semantic as IAst;
            if (ast != null)
            {
                IToken left = ast.getLeftIToken();
                IToken right = ast.getRightIToken();
                if (left != null && right != null)
                {
                    leftExtent = left.getTokenIndex();
                    rightExtent = right.getTokenIndex();
                }
            }

            SppfNode symbolNode =
                sppfSymbol(lhsSymbol, leftExtent, rightExtent);
            addPacked(symbolNode, action, children, semantic);
            if (ast != null)
                symbolNode.astForest = semantic;
            fork.sppfStack[fork.stateStackTop] = symbolNode;
            fork.symbolStack[fork.stateStackTop] = lhsSymbol;
            fork.gssTip = gssRelabel(fork.gssTip, lhsSymbol, leftExtent,
                                     semantic, symbolNode);
            action = prs.ntAction(fork.stateStack[fork.stateStackTop], lhs);
        }
        while (action <= NUM_RULES);

        fork.currentAction = action;
        work.Add(fork);
    }

    private void ensureCapacity(Config config, int need)
    {
        int length = config.stateStack == null ? 0 : config.stateStack.Length;
        if (need < length)
            return;
        int next = Math.Max(need + 8, length + STACK_INCREMENT);
        if (config.stateStack == null)
        {
            config.stateStack = new int[next];
            config.symbolStack = new int[next];
            config.parseStack = new object[next];
            config.locationStack = new int[next];
            config.sppfStack = new SppfNode[next];
        }
        else
        {
            Array.Resize(ref config.stateStack, next);
            Array.Resize(ref config.symbolStack, next);
            Array.Resize(ref config.parseStack, next);
            Array.Resize(ref config.locationStack, next);
            Array.Resize(ref config.sppfStack, next);
        }
    }

    private SppfNode sppfSymbol(int grammarSymbol, int leftExtent,
                                int rightExtent)
    {
        SppfKey key = new SppfKey(grammarSymbol, leftExtent, rightExtent);
        SppfNode node;
        if (!sppfNodes.TryGetValue(key, out node))
        {
            node = new SppfNode(grammarSymbol, leftExtent, rightExtent);
            sppfNodes.Add(key, node);
        }
        return node;
    }

    private SppfNode terminalSppf(int kind, int token)
    {
        SppfNode terminal = sppfSymbol(kind, token, token);
        if (terminal.packs.Count == 0)
            terminal.packs.Add(new SppfNode.Packed(-kind, null, null));
        return terminal;
    }

    private void addPacked(SppfNode symbolNode, int rule,
                           SppfNode[] children, object semantic)
    {
        int count = children == null ? 0 : children.Length;
        foreach (SppfNode.Packed packed in symbolNode.packs)
        {
            if (packed.rule != rule || packed.children.Length != count)
                continue;
            bool same = true;
            for (int i = 0; i < count; i++)
            {
                if (!ReferenceEquals(packed.children[i], children[i]))
                {
                    same = false;
                    break;
                }
            }
            if (same)
                return;
        }
        symbolNode.packs.Add(new SppfNode.Packed(rule, children, semantic));
    }

    private GssNode gssPush(GssNode tip, int state, int index,
                            int symbol, object semantic, SppfNode sppf)
    {
        GssNode node = new GssNode(state, index);
        GssNode predecessor = tip ?? new GssNode(int.MinValue, -1);
        node.edges.Add(new GssEdge(
            predecessor, symbol, index, semantic, sppf));
        GssKey key = new GssKey(state, index);
        GssNode canonical;
        if (!gssNodes.TryGetValue(key, out canonical))
        {
            canonical = new GssNode(state, index);
            gssNodes.Add(key, canonical);
        }
        canonical.edges.Add(new GssEdge(
            predecessor, symbol, index, semantic, sppf));
        return node;
    }

    private static GssNode gssPop(GssNode tip)
    {
        if (tip == null || tip.edges.Count == 0)
            return null;
        GssNode predecessor = tip.edges[0].predecessor;
        return predecessor.state == int.MinValue ? null : predecessor;
    }

    private static GssNode gssRelabel(GssNode tip, int symbol, int location,
                                      object semantic, SppfNode sppf)
    {
        if (tip == null || tip.edges.Count == 0)
            return tip;
        GssNode predecessor = tip.edges[0].predecessor;
        GssNode node = new GssNode(tip.state, tip.index);
        node.edges.Add(new GssEdge(
            predecessor, symbol, location, semantic, sppf));
        return node;
    }

    private static void packAccept(List<AcceptCandidate> accepts,
                                   AcceptCandidate candidate)
    {
        object ast = candidate.ast;
        if (ReferenceEquals(ast, NULL_RESULT))
        {
            foreach (AcceptCandidate existing in accepts)
                if (ReferenceEquals(existing.ast, NULL_RESULT))
                    return;
            accepts.Add(candidate);
            return;
        }
        if (ast == null)
            return;

        foreach (AcceptCandidate existing in accepts)
        {
            if (ReferenceEquals(existing.ast, NULL_RESULT))
                continue;
            if (existing.grammarSymbol == candidate.grammarSymbol
                    && sameSpan(existing.ast, ast)
                    && appendNextAst(existing.ast, ast))
                return;
        }
        accepts.Add(candidate);
    }

    private static bool canPackParseStacks(Config existing, Config incoming)
    {
        if (existing.stateStackTop != incoming.stateStackTop)
            return false;
        for (int i = 0; i <= existing.stateStackTop; i++)
        {
            object a = existing.parseStack[i];
            object b = incoming.parseStack[i];
            if (ReferenceEquals(a, b))
                continue;
            if (!(a is IAst) || !(b is IAst)
                    || !sameSpan(a, b)
                    || !appendNextAst(a, b, false))
                return false;
        }
        return true;
    }

    private void packParseStacks(Config existing, Config incoming)
    {
        for (int i = 0; i <= existing.stateStackTop; i++)
        {
            object a = existing.parseStack[i];
            object b = incoming.parseStack[i];
            if (ReferenceEquals(a, b) || a == null || b == null)
                continue;
            if (!appendNextAst(a, b, false))
                throw new InvalidOperationException(
                    "overlapping GLR semantic forests");
        }

        for (int i = 0; i <= existing.stateStackTop; i++)
        {
            existing.parseStack[i] =
                packSym(existing.parseStack[i], incoming.parseStack[i]);
            if (existing.sppfStack[i] == null)
                existing.sppfStack[i] = incoming.sppfStack[i];
            else if (incoming.sppfStack[i] != null
                    && !ReferenceEquals(existing.sppfStack[i], incoming.sppfStack[i])
                    && existing.sppfStack[i].grammarSymbol
                        == incoming.sppfStack[i].grammarSymbol
                    && existing.sppfStack[i].leftExtent
                        == incoming.sppfStack[i].leftExtent
                    && existing.sppfStack[i].rightExtent
                        == incoming.sppfStack[i].rightExtent)
            {
                SppfNode canonical = existing.sppfStack[i];
                SppfNode other = incoming.sppfStack[i];
                foreach (SppfNode.Packed packed in other.packs)
                    addPacked(canonical, packed.rule,
                              packed.children, packed.semantic);
                if (existing.parseStack[i] is IAst)
                    canonical.astForest = existing.parseStack[i];
            }
        }
        if (incoming.gssTip != null)
            existing.gssTip = incoming.gssTip;
    }

    private static object packSym(object first, object second)
    {
        if (first == null)
            return second;
        if (second == null || ReferenceEquals(first, second))
            return first;
        if (!appendNextAst(first, second))
            throw new InvalidOperationException(
                "overlapping GLR semantic forests");
        return first;
    }

    private static bool sameSpan(object first, object second)
    {
        IAst a = first as IAst;
        IAst b = second as IAst;
        if (a == null || b == null)
            return false;
        IToken leftA = a.getLeftIToken();
        IToken rightA = a.getRightIToken();
        IToken leftB = b.getLeftIToken();
        IToken rightB = b.getRightIToken();
        if (leftA == null || rightA == null || leftB == null || rightB == null)
            return false;
        return ReferenceEquals(leftA.getILexStream(), leftB.getILexStream())
            && ReferenceEquals(rightA.getILexStream(), rightB.getILexStream())
            && leftA.getTokenIndex() == leftB.getTokenIndex()
            && rightA.getTokenIndex() == rightB.getTokenIndex();
    }

    private static bool appendNextAst(object root, object alternative)
    {
        return appendNextAst(root, alternative, true);
    }

    private static bool appendNextAst(object root, object alternative,
                                      bool commit)
    {
        IAst current = root as IAst;
        IAst incomingRoot = alternative as IAst;
        if (current == null || incomingRoot == null)
            return false;
        if (ReferenceEquals(current, incomingRoot))
            return true;

        HashSet<IAst> seen =
            new HashSet<IAst>(ReferenceEqualityComparer<IAst>.Instance);
        IAst tail = null;
        for (IAst node = current; node != null; node = node.getNextAst())
        {
            if (!seen.Add(node))
                return false;
            tail = node;
        }

        HashSet<IAst> incoming =
            new HashSet<IAst>(ReferenceEqualityComparer<IAst>.Instance);
        for (IAst node = incomingRoot; node != null; )
        {
            if (!incoming.Add(node))
                return false;
            if (seen.Contains(node))
            {
                node = node.getNextAst();
                continue;
            }
            for (IAst next = node.getNextAst();
                 next != null;
                 next = next.getNextAst())
            {
                if (!incoming.Add(next) || seen.Contains(next))
                    return false;
            }
            if (commit)
            {
                tail.setNextAst(node);
                for (IAst next = node;
                     next != null;
                     next = next.getNextAst())
                {
                    seen.Add(next);
                    tail = next;
                }
            }
            return true;
        }
        return true;
    }

    private sealed class ReferenceEqualityComparer<T> : IEqualityComparer<T>
        where T : class
    {
        internal static readonly ReferenceEqualityComparer<T> Instance =
            new ReferenceEqualityComparer<T>();

        public bool Equals(T first, T second)
        {
            return ReferenceEquals(first, second);
        }

        public int GetHashCode(T value)
        {
            return RuntimeHelpers.GetHashCode(value);
        }
    }
}
}

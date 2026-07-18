namespace LpgExample
{

using LpgExample.Ast;

    //#line 157 "dtParserTemplateF.gi

using LPG2.Runtime;
using System;

    //#line 9 "LPGParser.g


 
    //#line 164 "dtParserTemplateF.gi

public class LPGParser : object , RuleAction
{
    private PrsStream prsStream = null;
    
    private bool unimplementedSymbolsWarning = false;

    private static ParseTable prsTable = new LPGParserprs();
    public ParseTable getParseTable() { return prsTable; }

    private DeterministicParser dtParser = null;
    public DeterministicParser getParser() { return dtParser; }

    private void setResult(object _object) { dtParser.setSym1(_object); }
    public object getRhsSym(int i) { return dtParser.getSym(i); }

    public int getRhsTokenIndex(int i) { return dtParser.getToken(i); }
    public IToken getRhsIToken(int i) { return prsStream.getIToken(getRhsTokenIndex(i)); }
    
    public int getRhsFirstTokenIndex(int i) { return dtParser.getFirstToken(i); }
    public IToken getRhsFirstIToken(int i) { return prsStream.getIToken(getRhsFirstTokenIndex(i)); }

    public int getRhsLastTokenIndex(int i) { return dtParser.getLastToken(i); }
    public IToken getRhsLastIToken(int i) { return prsStream.getIToken(getRhsLastTokenIndex(i)); }

    public int getLeftSpan() { return dtParser.getFirstToken(); }
    public IToken getLeftIToken()  { return prsStream.getIToken(getLeftSpan()); }

    public int getRightSpan() { return dtParser.getLastToken(); }
    public IToken getRightIToken() { return prsStream.getIToken(getRightSpan()); }

    public int getRhsErrorTokenIndex(int i)
    {
        int index = dtParser.getToken(i);
        IToken err = prsStream.getIToken(index);
        return (err is ErrorToken ? index : 0);
    }
    public ErrorToken getRhsErrorIToken(int i)
    {
        int index = dtParser.getToken(i);
        IToken err = prsStream.getIToken(index);
        return (ErrorToken) (err is ErrorToken ? err : null);
    }

    public void reset(ILexStream lexStream)
    {
        prsStream = new PrsStream(lexStream);
        dtParser.reset(prsStream);

        try
        {
            prsStream.remapTerminalSymbols(orderedTerminalSymbols(), prsTable.getEoftSymbol());
        }
        catch(NullExportedSymbolsException e) {
        }
        catch(NullTerminalSymbolsException e) {
        }
        catch(UnimplementedTerminalsException e)
        {
            if (unimplementedSymbolsWarning) {
                ArrayListHelper<int> unimplemented_symbols =  new ArrayListHelper<int>( e.getSymbols());
                Console.Out.WriteLine("The Lexer will not scan the following token(s):");
                for (int i = 0; i < unimplemented_symbols.Count; i++)
                {
                    int  id = unimplemented_symbols.get(i);
                    Console.Out.WriteLine("    " + LPGParsersym.orderedTerminalSymbols[id]);               
                }
                Console.Out.WriteLine();
            }
        }
        catch(UndefinedEofSymbolException e)
        {
            throw (new UndefinedEofSymbolException
                                ("The Lexer does not implement the Eof symbol " +
                                 LPGParsersym.orderedTerminalSymbols[prsTable.getEoftSymbol()]));
        }
    }
    
    public LPGParser()
    {
        try
        {
            dtParser = new DeterministicParser(prsStream, prsTable, (RuleAction) this);
        }
        catch (NotDeterministicParseTableException e)
        {
            throw (new NotDeterministicParseTableException
                                ("Regenerate LPGParserprs.cs with -NOBACKTRACK option"));
        }
        catch (BadParseSymFileException e)
        {
            throw (new BadParseSymFileException("Bad Parser Symbol File -- LPGParsersym.cs. Regenerate LPGParserprs.cs"));
        }
    }

    public LPGParser(ILexStream lexStream): this()
    {
       
        reset(lexStream);
    }

    public int numTokenKinds() { return LPGParsersym.numTokenKinds; }
    public string[] orderedTerminalSymbols() { return LPGParsersym.orderedTerminalSymbols; }
    public string getTokenKindName(int kind) { return LPGParsersym.orderedTerminalSymbols[kind]; }            
    public int getEOFTokenKind() { return prsTable.getEoftSymbol(); }
    public IPrsStream getIPrsStream() { return prsStream; }

    /**
     * @deprecated replaced by {@link #getIPrsStream()}
     *
     */
    public PrsStream getPrsStream() { return prsStream; }

    /**
     * @deprecated replaced by {@link #getIPrsStream()}
     *
     */
    public PrsStream getParseStream() { return prsStream; }

    public object parser()
    {
        return parser(null, 0);
    }
        
    public object parser(Monitor monitor)
    {
        return parser(monitor, 0);
    }
        
    public object parser(int error_repair_count)
    {
        return parser(null, error_repair_count);
    }
        
    public object parser(Monitor monitor, int error_repair_count)
    {
        dtParser.setMonitor(monitor);

        try
        {
            return (object) dtParser.parse();
        }
        catch (BadParseException e)
        {
            prsStream.reset(e.error_token); // point to error token

            DiagnoseParser diagnoseParser = new DiagnoseParser(prsStream, prsTable);
            diagnoseParser.diagnose(e.error_token);
        }

        return null;
    }

    //
    // Additional entry points, if any
    //
    

    //#line 39 "LPGParser.g


 
    //#line 326 "dtParserTemplateF.gi

    
    public ProstheticAst[] getProstheticAst() { return null; }
    public void setRecoverParser(BacktrackingParser parser) { }
    public BacktrackingParser getRecoverParser() { return null; }

    public void ruleAction(int ruleNumber)
    {
        switch (ruleNumber)
        {
            //#line 327 "dtParserTemplateF.gi"

            //
            // Rule 1:  LPG ::= options_segment LPG_INPUT
            //
            case 1: {
                //#line 45 "LPGParser.g"
                setResult(
                    //#line 45 LPGParser.g
                    new LPG(this, getLeftIToken(), getRightIToken(),
                            //#line 45 LPGParser.g
                            (option_specList)getRhsSym(1),
                            //#line 45 LPGParser.g
                            (LPG_itemList)getRhsSym(2))
                //#line 45 LPGParser.g
                );
            break;
            }
            //
            // Rule 2:  LPG_INPUT ::= $Empty
            //
            case 2: {
                //#line 50 "LPGParser.g"
                setResult(
                    //#line 50 LPGParser.g
                    new LPG_itemList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 50 LPGParser.g
                );
            break;
            }
            //
            // Rule 3:  LPG_INPUT ::= LPG_INPUT LPG_item
            //
            case 3: {
                //#line 51 "LPGParser.g"
                ((LPG_itemList)getRhsSym(1)).addElement((ILPG_item)getRhsSym(2));
            break;
            }
            //
            // Rule 4:  LPG_item ::= ALIAS_KEY$ alias_segment END_KEY_OPT$
            //
            case 4: {
                //#line 54 "LPGParser.g"
                setResult(
                    //#line 54 LPGParser.g
                    new AliasSeg(getLeftIToken(), getRightIToken(),
                                 //#line 54 LPGParser.g
                                 (aliasSpecList)getRhsSym(2))
                //#line 54 LPGParser.g
                );
            break;
            }
            //
            // Rule 5:  LPG_item ::= AST_KEY$ ast_segment END_KEY_OPT$
            //
            case 5: {
                //#line 55 "LPGParser.g"
                setResult(
                    //#line 55 LPGParser.g
                    new AstSeg(getLeftIToken(), getRightIToken(),
                               //#line 55 LPGParser.g
                               (action_segmentList)getRhsSym(2))
                //#line 55 LPGParser.g
                );
            break;
            }
            //
            // Rule 6:  LPG_item ::= DEFINE_KEY$ define_segment END_KEY_OPT$
            //
            case 6: {
                //#line 56 "LPGParser.g"
                setResult(
                    //#line 56 LPGParser.g
                    new DefineSeg(getLeftIToken(), getRightIToken(),
                                  //#line 56 LPGParser.g
                                  (defineSpecList)getRhsSym(2))
                //#line 56 LPGParser.g
                );
            break;
            }
            //
            // Rule 7:  LPG_item ::= EOF_KEY$ eof_segment END_KEY_OPT$
            //
            case 7: {
                //#line 57 "LPGParser.g"
                setResult(
                    //#line 57 LPGParser.g
                    new EofSeg(getLeftIToken(), getRightIToken(),
                               //#line 57 LPGParser.g
                               (Ieof_segment)getRhsSym(2))
                //#line 57 LPGParser.g
                );
            break;
            }
            //
            // Rule 8:  LPG_item ::= EOL_KEY$ eol_segment END_KEY_OPT$
            //
            case 8: {
                //#line 58 "LPGParser.g"
                setResult(
                    //#line 58 LPGParser.g
                    new EolSeg(getLeftIToken(), getRightIToken(),
                               //#line 58 LPGParser.g
                               (Ieol_segment)getRhsSym(2))
                //#line 58 LPGParser.g
                );
            break;
            }
            //
            // Rule 9:  LPG_item ::= ERROR_KEY$ error_segment END_KEY_OPT$
            //
            case 9: {
                //#line 59 "LPGParser.g"
                setResult(
                    //#line 59 LPGParser.g
                    new ErrorSeg(getLeftIToken(), getRightIToken(),
                                 //#line 59 LPGParser.g
                                 (Ierror_segment)getRhsSym(2))
                //#line 59 LPGParser.g
                );
            break;
            }
            //
            // Rule 10:  LPG_item ::= EXPORT_KEY$ export_segment END_KEY_OPT$
            //
            case 10: {
                //#line 60 "LPGParser.g"
                setResult(
                    //#line 60 LPGParser.g
                    new ExportSeg(getLeftIToken(), getRightIToken(),
                                  //#line 60 LPGParser.g
                                  (terminal_symbolList)getRhsSym(2))
                //#line 60 LPGParser.g
                );
            break;
            }
            //
            // Rule 11:  LPG_item ::= GLOBALS_KEY$ globals_segment END_KEY_OPT$
            //
            case 11: {
                //#line 61 "LPGParser.g"
                setResult(
                    //#line 61 LPGParser.g
                    new GlobalsSeg(getLeftIToken(), getRightIToken(),
                                   //#line 61 LPGParser.g
                                   (action_segmentList)getRhsSym(2))
                //#line 61 LPGParser.g
                );
            break;
            }
            //
            // Rule 12:  LPG_item ::= HEADERS_KEY$ headers_segment END_KEY_OPT$
            //
            case 12: {
                //#line 62 "LPGParser.g"
                setResult(
                    //#line 62 LPGParser.g
                    new HeadersSeg(getLeftIToken(), getRightIToken(),
                                   //#line 62 LPGParser.g
                                   (action_segmentList)getRhsSym(2))
                //#line 62 LPGParser.g
                );
            break;
            }
            //
            // Rule 13:  LPG_item ::= IDENTIFIER_KEY$ identifier_segment END_KEY_OPT$
            //
            case 13: {
                //#line 63 "LPGParser.g"
                setResult(
                    //#line 63 LPGParser.g
                    new IdentifierSeg(getLeftIToken(), getRightIToken(),
                                      //#line 63 LPGParser.g
                                      (Iidentifier_segment)getRhsSym(2))
                //#line 63 LPGParser.g
                );
            break;
            }
            //
            // Rule 14:  LPG_item ::= IMPORT_KEY$ import_segment END_KEY_OPT$
            //
            case 14: {
                //#line 64 "LPGParser.g"
                setResult(
                    //#line 64 LPGParser.g
                    new ImportSeg(getLeftIToken(), getRightIToken(),
                                  //#line 64 LPGParser.g
                                  (import_segment)getRhsSym(2))
                //#line 64 LPGParser.g
                );
            break;
            }
            //
            // Rule 15:  LPG_item ::= INCLUDE_KEY$ include_segment END_KEY_OPT$
            //
            case 15: {
                //#line 65 "LPGParser.g"
                setResult(
                    //#line 65 LPGParser.g
                    new IncludeSeg(getLeftIToken(), getRightIToken(),
                                   //#line 65 LPGParser.g
                                   (include_segment)getRhsSym(2))
                //#line 65 LPGParser.g
                );
            break;
            }
            //
            // Rule 16:  LPG_item ::= KEYWORDS_KEY$ keywords_segment END_KEY_OPT$
            //
            case 16: {
                //#line 66 "LPGParser.g"
                setResult(
                    //#line 66 LPGParser.g
                    new KeywordsSeg(getLeftIToken(), getRightIToken(),
                                    //#line 66 LPGParser.g
                                    (keywordSpecList)getRhsSym(2))
                //#line 66 LPGParser.g
                );
            break;
            }
            //
            // Rule 17:  LPG_item ::= NAMES_KEY$ names_segment END_KEY_OPT$
            //
            case 17: {
                //#line 67 "LPGParser.g"
                setResult(
                    //#line 67 LPGParser.g
                    new NamesSeg(getLeftIToken(), getRightIToken(),
                                 //#line 67 LPGParser.g
                                 (nameSpecList)getRhsSym(2))
                //#line 67 LPGParser.g
                );
            break;
            }
            //
            // Rule 18:  LPG_item ::= NOTICE_KEY$ notice_segment END_KEY_OPT$
            //
            case 18: {
                //#line 68 "LPGParser.g"
                setResult(
                    //#line 68 LPGParser.g
                    new NoticeSeg(getLeftIToken(), getRightIToken(),
                                  //#line 68 LPGParser.g
                                  (action_segmentList)getRhsSym(2))
                //#line 68 LPGParser.g
                );
            break;
            }
            //
            // Rule 19:  LPG_item ::= RULES_KEY$ rules_segment END_KEY_OPT$
            //
            case 19: {
                //#line 69 "LPGParser.g"
                setResult(
                    //#line 69 LPGParser.g
                    new RulesSeg(getLeftIToken(), getRightIToken(),
                                 //#line 69 LPGParser.g
                                 (rules_segment)getRhsSym(2))
                //#line 69 LPGParser.g
                );
            break;
            }
            //
            // Rule 20:  LPG_item ::= SOFT_KEYWORDS_KEY$ keywords_segment END_KEY_OPT$
            //
            case 20: {
                //#line 70 "LPGParser.g"
                setResult(
                    //#line 70 LPGParser.g
                    new SoftKeywordsSeg(getLeftIToken(), getRightIToken(),
                                        //#line 70 LPGParser.g
                                        (keywordSpecList)getRhsSym(2))
                //#line 70 LPGParser.g
                );
            break;
            }
            //
            // Rule 21:  LPG_item ::= START_KEY$ start_segment END_KEY_OPT$
            //
            case 21: {
                //#line 71 "LPGParser.g"
                setResult(
                    //#line 71 LPGParser.g
                    new StartSeg(getLeftIToken(), getRightIToken(),
                                 //#line 71 LPGParser.g
                                 (start_symbolList)getRhsSym(2))
                //#line 71 LPGParser.g
                );
            break;
            }
            //
            // Rule 22:  LPG_item ::= TERMINALS_KEY$ terminals_segment END_KEY_OPT$
            //
            case 22: {
                //#line 72 "LPGParser.g"
                setResult(
                    //#line 72 LPGParser.g
                    new TerminalsSeg(getLeftIToken(), getRightIToken(),
                                     //#line 72 LPGParser.g
                                     (terminalList)getRhsSym(2))
                //#line 72 LPGParser.g
                );
            break;
            }
            //
            // Rule 23:  LPG_item ::= TRAILERS_KEY$ trailers_segment END_KEY_OPT$
            //
            case 23: {
                //#line 73 "LPGParser.g"
                setResult(
                    //#line 73 LPGParser.g
                    new TrailersSeg(getLeftIToken(), getRightIToken(),
                                    //#line 73 LPGParser.g
                                    (action_segmentList)getRhsSym(2))
                //#line 73 LPGParser.g
                );
            break;
            }
            //
            // Rule 24:  LPG_item ::= TYPES_KEY$ types_segment END_KEY_OPT$
            //
            case 24: {
                //#line 74 "LPGParser.g"
                setResult(
                    //#line 74 LPGParser.g
                    new TypesSeg(getLeftIToken(), getRightIToken(),
                                 //#line 74 LPGParser.g
                                 (type_declarationsList)getRhsSym(2))
                //#line 74 LPGParser.g
                );
            break;
            }
            //
            // Rule 25:  LPG_item ::= RECOVER_KEY$ recover_segment END_KEY_OPT$
            //
            case 25: {
                //#line 75 "LPGParser.g"
                setResult(
                    //#line 75 LPGParser.g
                    new RecoverSeg(getLeftIToken(), getRightIToken(),
                                   //#line 75 LPGParser.g
                                   (SYMBOLList)getRhsSym(2))
                //#line 75 LPGParser.g
                );
            break;
            }
            //
            // Rule 26:  LPG_item ::= DISJOINTPREDECESSORSETS_KEY$ predecessor_segment END_KEY_OPT$
            //
            case 26: {
                //#line 76 "LPGParser.g"
                setResult(
                    //#line 76 LPGParser.g
                    new PredecessorSeg(getLeftIToken(), getRightIToken(),
                                       //#line 76 LPGParser.g
                                       (symbol_pairList)getRhsSym(2))
                //#line 76 LPGParser.g
                );
            break;
            }
            //
            // Rule 27:  options_segment ::= $Empty
            //
            case 27: {
                //#line 79 "LPGParser.g"
                setResult(
                    //#line 79 LPGParser.g
                    new option_specList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 79 LPGParser.g
                );
            break;
            }
            //
            // Rule 28:  options_segment ::= options_segment option_spec
            //
            case 28: {
                //#line 79 "LPGParser.g"
                ((option_specList)getRhsSym(1)).addElement((option_spec)getRhsSym(2));
            break;
            }
            //
            // Rule 29:  option_spec ::= OPTIONS_KEY$ option_list
            //
            case 29: {
                //#line 80 "LPGParser.g"
                setResult(
                    //#line 80 LPGParser.g
                    new option_spec(getLeftIToken(), getRightIToken(),
                                    //#line 80 LPGParser.g
                                    (optionList)getRhsSym(2))
                //#line 80 LPGParser.g
                );
            break;
            }
            //
            // Rule 30:  option_list ::= option
            //
            case 30: {
                //#line 81 "LPGParser.g"
                setResult(
                    //#line 81 LPGParser.g
                    new optionList((option)getRhsSym(1), true /* left recursive */)
                //#line 81 LPGParser.g
                );
            break;
            }
            //
            // Rule 31:  option_list ::= option_list ,$ option
            //
            case 31: {
                //#line 81 "LPGParser.g"
                ((optionList)getRhsSym(1)).addElement((option)getRhsSym(3));
            break;
            }
            //
            // Rule 32:  option ::= SYMBOL option_value
            //
            case 32: {
                //#line 82 "LPGParser.g"
                setResult(
                    //#line 82 LPGParser.g
                    new option(getLeftIToken(), getRightIToken(),
                               //#line 82 LPGParser.g
                               new ASTNodeToken(getRhsIToken(1)),
                               //#line 82 LPGParser.g
                               (Ioption_value)getRhsSym(2))
                //#line 82 LPGParser.g
                );
            break;
            }
            //
            // Rule 33:  option_value ::= $Empty
            //
            case 33: {
                //#line 83 "LPGParser.g"
                setResult(null);
            break;
            }
            //
            // Rule 34:  option_value ::= =$ SYMBOL
            //
            case 34: {
                //#line 83 "LPGParser.g"
                setResult(
                    //#line 83 LPGParser.g
                    new option_value0(getLeftIToken(), getRightIToken(),
                                      //#line 83 LPGParser.g
                                      new ASTNodeToken(getRhsIToken(2)))
                //#line 83 LPGParser.g
                );
            break;
            }
            //
            // Rule 35:  option_value ::= =$ ($ symbol_list )$
            //
            case 35: {
                //#line 83 "LPGParser.g"
                setResult(
                    //#line 83 LPGParser.g
                    new option_value1(getLeftIToken(), getRightIToken(),
                                      //#line 83 LPGParser.g
                                      (SYMBOLList)getRhsSym(3))
                //#line 83 LPGParser.g
                );
            break;
            }
            //
            // Rule 36:  symbol_list ::= SYMBOL
            //
            case 36: {
                //#line 85 "LPGParser.g"
                setResult(
                    //#line 85 LPGParser.g
                    new SYMBOLList(new ASTNodeToken(getRhsIToken(1)), true /* left recursive */)
                //#line 85 LPGParser.g
                );
            break;
            }
            //
            // Rule 37:  symbol_list ::= symbol_list ,$ SYMBOL
            //
            case 37: {
                //#line 86 "LPGParser.g"
                ((SYMBOLList)getRhsSym(1)).addElement(new ASTNodeToken(getRhsIToken(3)));
            break;
            }
            //
            // Rule 38:  alias_segment ::= aliasSpec
            //
            case 38: {
                //#line 89 "LPGParser.g"
                setResult(
                    //#line 89 LPGParser.g
                    new aliasSpecList((IaliasSpec)getRhsSym(1), true /* left recursive */)
                //#line 89 LPGParser.g
                );
            break;
            }
            //
            // Rule 39:  alias_segment ::= alias_segment aliasSpec
            //
            case 39: {
                //#line 89 "LPGParser.g"
                ((aliasSpecList)getRhsSym(1)).addElement((IaliasSpec)getRhsSym(2));
            break;
            }
            //
            // Rule 40:  aliasSpec ::= ERROR_KEY produces alias_rhs
            //
            case 40: {
                //#line 91 "LPGParser.g"
                setResult(
                    //#line 91 LPGParser.g
                    new aliasSpec0(getLeftIToken(), getRightIToken(),
                                   //#line 91 LPGParser.g
                                   new ASTNodeToken(getRhsIToken(1)),
                                   //#line 91 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 91 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 91 LPGParser.g
                );
            break;
            }
            //
            // Rule 41:  aliasSpec ::= EOL_KEY produces alias_rhs
            //
            case 41: {
                //#line 92 "LPGParser.g"
                setResult(
                    //#line 92 LPGParser.g
                    new aliasSpec1(getLeftIToken(), getRightIToken(),
                                   //#line 92 LPGParser.g
                                   new ASTNodeToken(getRhsIToken(1)),
                                   //#line 92 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 92 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 92 LPGParser.g
                );
            break;
            }
            //
            // Rule 42:  aliasSpec ::= EOF_KEY produces alias_rhs
            //
            case 42: {
                //#line 93 "LPGParser.g"
                setResult(
                    //#line 93 LPGParser.g
                    new aliasSpec2(getLeftIToken(), getRightIToken(),
                                   //#line 93 LPGParser.g
                                   new ASTNodeToken(getRhsIToken(1)),
                                   //#line 93 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 93 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 93 LPGParser.g
                );
            break;
            }
            //
            // Rule 43:  aliasSpec ::= IDENTIFIER_KEY produces alias_rhs
            //
            case 43: {
                //#line 94 "LPGParser.g"
                setResult(
                    //#line 94 LPGParser.g
                    new aliasSpec3(getLeftIToken(), getRightIToken(),
                                   //#line 94 LPGParser.g
                                   new ASTNodeToken(getRhsIToken(1)),
                                   //#line 94 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 94 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 94 LPGParser.g
                );
            break;
            }
            //
            // Rule 44:  aliasSpec ::= SYMBOL produces alias_rhs
            //
            case 44: {
                //#line 95 "LPGParser.g"
                setResult(
                    //#line 95 LPGParser.g
                    new aliasSpec4(getLeftIToken(), getRightIToken(),
                                   //#line 95 LPGParser.g
                                   new ASTNodeToken(getRhsIToken(1)),
                                   //#line 95 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 95 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 95 LPGParser.g
                );
            break;
            }
            //
            // Rule 45:  aliasSpec ::= alias_lhs_macro_name produces alias_rhs
            //
            case 45: {
                //#line 96 "LPGParser.g"
                setResult(
                    //#line 96 LPGParser.g
                    new aliasSpec5(getLeftIToken(), getRightIToken(),
                                   //#line 96 LPGParser.g
                                   (alias_lhs_macro_name)getRhsSym(1),
                                   //#line 96 LPGParser.g
                                   (Iproduces)getRhsSym(2),
                                   //#line 96 LPGParser.g
                                   (Ialias_rhs)getRhsSym(3))
                //#line 96 LPGParser.g
                );
            break;
            }
            //
            // Rule 46:  alias_lhs_macro_name ::= MACRO_NAME
            //
            case 46: {
                //#line 98 "LPGParser.g"
                setResult(
                    //#line 98 LPGParser.g
                    new alias_lhs_macro_name(getRhsIToken(1))
                //#line 98 LPGParser.g
                );
            break;
            }
            //
            // Rule 47:  alias_rhs ::= SYMBOL
            //
            case 47: {
                //#line 100 "LPGParser.g"
                setResult(
                    //#line 100 LPGParser.g
                    new alias_rhs0(getRhsIToken(1))
                //#line 100 LPGParser.g
                );
            break;
            }
            //
            // Rule 48:  alias_rhs ::= MACRO_NAME
            //
            case 48: {
                //#line 101 "LPGParser.g"
                setResult(
                    //#line 101 LPGParser.g
                    new alias_rhs1(getRhsIToken(1))
                //#line 101 LPGParser.g
                );
            break;
            }
            //
            // Rule 49:  alias_rhs ::= ERROR_KEY
            //
            case 49: {
                //#line 102 "LPGParser.g"
                setResult(
                    //#line 102 LPGParser.g
                    new alias_rhs2(getRhsIToken(1))
                //#line 102 LPGParser.g
                );
            break;
            }
            //
            // Rule 50:  alias_rhs ::= EOL_KEY
            //
            case 50: {
                //#line 103 "LPGParser.g"
                setResult(
                    //#line 103 LPGParser.g
                    new alias_rhs3(getRhsIToken(1))
                //#line 103 LPGParser.g
                );
            break;
            }
            //
            // Rule 51:  alias_rhs ::= EOF_KEY
            //
            case 51: {
                //#line 104 "LPGParser.g"
                setResult(
                    //#line 104 LPGParser.g
                    new alias_rhs4(getRhsIToken(1))
                //#line 104 LPGParser.g
                );
            break;
            }
            //
            // Rule 52:  alias_rhs ::= EMPTY_KEY
            //
            case 52: {
                //#line 105 "LPGParser.g"
                setResult(
                    //#line 105 LPGParser.g
                    new alias_rhs5(getRhsIToken(1))
                //#line 105 LPGParser.g
                );
            break;
            }
            //
            // Rule 53:  alias_rhs ::= IDENTIFIER_KEY
            //
            case 53: {
                //#line 106 "LPGParser.g"
                setResult(
                    //#line 106 LPGParser.g
                    new alias_rhs6(getRhsIToken(1))
                //#line 106 LPGParser.g
                );
            break;
            }
            //
            // Rule 54:  ast_segment ::= action_segment_list
            //
            case 54:
                break;
            //
            // Rule 55:  define_segment ::= defineSpec
            //
            case 55: {
                //#line 112 "LPGParser.g"
                setResult(
                    //#line 112 LPGParser.g
                    new defineSpecList((defineSpec)getRhsSym(1), true /* left recursive */)
                //#line 112 LPGParser.g
                );
            break;
            }
            //
            // Rule 56:  define_segment ::= define_segment defineSpec
            //
            case 56: {
                //#line 112 "LPGParser.g"
                ((defineSpecList)getRhsSym(1)).addElement((defineSpec)getRhsSym(2));
            break;
            }
            //
            // Rule 57:  defineSpec ::= macro_name_symbol macro_segment
            //
            case 57: {
                //#line 113 "LPGParser.g"
                setResult(
                    //#line 113 LPGParser.g
                    new defineSpec(getLeftIToken(), getRightIToken(),
                                   //#line 113 LPGParser.g
                                   (Imacro_name_symbol)getRhsSym(1),
                                   //#line 113 LPGParser.g
                                   (macro_segment)getRhsSym(2))
                //#line 113 LPGParser.g
                );
            break;
            }
            //
            // Rule 58:  macro_name_symbol ::= MACRO_NAME
            //
            case 58: {
                //#line 116 "LPGParser.g"
                setResult(
                    //#line 116 LPGParser.g
                    new macro_name_symbol0(getRhsIToken(1))
                //#line 116 LPGParser.g
                );
            break;
            }
            //
            // Rule 59:  macro_name_symbol ::= SYMBOL
            //
            case 59: {
                //#line 117 "LPGParser.g"
                setResult(
                    //#line 117 LPGParser.g
                    new macro_name_symbol1(getRhsIToken(1))
                //#line 117 LPGParser.g
                );
            break;
            }
            //
            // Rule 60:  macro_segment ::= BLOCK
            //
            case 60: {
                //#line 118 "LPGParser.g"
                setResult(
                    //#line 118 LPGParser.g
                    new macro_segment(getRhsIToken(1))
                //#line 118 LPGParser.g
                );
            break;
            }
            //
            // Rule 61:  eol_segment ::= terminal_symbol
            //
            case 61:
                break;
            //
            // Rule 62:  eof_segment ::= terminal_symbol
            //
            case 62:
                break;
            //
            // Rule 63:  error_segment ::= terminal_symbol
            //
            case 63:
                break;
            //
            // Rule 64:  export_segment ::= terminal_symbol
            //
            case 64: {
                //#line 128 "LPGParser.g"
                setResult(
                    //#line 128 LPGParser.g
                    new terminal_symbolList((Iterminal_symbol)getRhsSym(1), true /* left recursive */)
                //#line 128 LPGParser.g
                );
            break;
            }
            //
            // Rule 65:  export_segment ::= export_segment terminal_symbol
            //
            case 65: {
                //#line 128 "LPGParser.g"
                ((terminal_symbolList)getRhsSym(1)).addElement((Iterminal_symbol)getRhsSym(2));
            break;
            }
            //
            // Rule 66:  globals_segment ::= action_segment
            //
            case 66: {
                //#line 131 "LPGParser.g"
                setResult(
                    //#line 131 LPGParser.g
                    new action_segmentList((action_segment)getRhsSym(1), true /* left recursive */)
                //#line 131 LPGParser.g
                );
            break;
            }
            //
            // Rule 67:  globals_segment ::= globals_segment action_segment
            //
            case 67: {
                //#line 131 "LPGParser.g"
                ((action_segmentList)getRhsSym(1)).addElement((action_segment)getRhsSym(2));
            break;
            }
            //
            // Rule 68:  headers_segment ::= action_segment_list
            //
            case 68:
                break;
            //
            // Rule 69:  identifier_segment ::= terminal_symbol
            //
            case 69:
                break;
            //
            // Rule 70:  import_segment ::= SYMBOL drop_command_list
            //
            case 70: {
                //#line 140 "LPGParser.g"
                setResult(
                    //#line 140 LPGParser.g
                    new import_segment(getLeftIToken(), getRightIToken(),
                                       //#line 140 LPGParser.g
                                       new ASTNodeToken(getRhsIToken(1)),
                                       //#line 140 LPGParser.g
                                       (drop_commandList)getRhsSym(2))
                //#line 140 LPGParser.g
                );
            break;
            }
            //
            // Rule 71:  drop_command_list ::= $Empty
            //
            case 71: {
                //#line 142 "LPGParser.g"
                setResult(
                    //#line 142 LPGParser.g
                    new drop_commandList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 142 LPGParser.g
                );
            break;
            }
            //
            // Rule 72:  drop_command_list ::= drop_command_list drop_command
            //
            case 72: {
                //#line 142 "LPGParser.g"
                ((drop_commandList)getRhsSym(1)).addElement((Idrop_command)getRhsSym(2));
            break;
            }
            //
            // Rule 73:  drop_command ::= DROPSYMBOLS_KEY drop_symbols
            //
            case 73: {
                //#line 144 "LPGParser.g"
                setResult(
                    //#line 144 LPGParser.g
                    new drop_command0(getLeftIToken(), getRightIToken(),
                                      //#line 144 LPGParser.g
                                      new ASTNodeToken(getRhsIToken(1)),
                                      //#line 144 LPGParser.g
                                      (SYMBOLList)getRhsSym(2))
                //#line 144 LPGParser.g
                );
            break;
            }
            //
            // Rule 74:  drop_command ::= DROPRULES_KEY drop_rules
            //
            case 74: {
                //#line 145 "LPGParser.g"
                setResult(
                    //#line 145 LPGParser.g
                    new drop_command1(getLeftIToken(), getRightIToken(),
                                      //#line 145 LPGParser.g
                                      new ASTNodeToken(getRhsIToken(1)),
                                      //#line 145 LPGParser.g
                                      (drop_ruleList)getRhsSym(2))
                //#line 145 LPGParser.g
                );
            break;
            }
            //
            // Rule 75:  drop_symbols ::= SYMBOL
            //
            case 75: {
                //#line 147 "LPGParser.g"
                setResult(
                    //#line 147 LPGParser.g
                    new SYMBOLList(new ASTNodeToken(getRhsIToken(1)), true /* left recursive */)
                //#line 147 LPGParser.g
                );
            break;
            }
            //
            // Rule 76:  drop_symbols ::= drop_symbols SYMBOL
            //
            case 76: {
                //#line 148 "LPGParser.g"
                ((SYMBOLList)getRhsSym(1)).addElement(new ASTNodeToken(getRhsIToken(2)));
            break;
            }
            //
            // Rule 77:  drop_rules ::= drop_rule
            //
            case 77: {
                //#line 149 "LPGParser.g"
                setResult(
                    //#line 149 LPGParser.g
                    new drop_ruleList((drop_rule)getRhsSym(1), true /* left recursive */)
                //#line 149 LPGParser.g
                );
            break;
            }
            //
            // Rule 78:  drop_rules ::= drop_rules drop_rule
            //
            case 78: {
                //#line 150 "LPGParser.g"
                ((drop_ruleList)getRhsSym(1)).addElement((drop_rule)getRhsSym(2));
            break;
            }
            //
            // Rule 79:  drop_rule ::= SYMBOL optMacroName produces ruleList
            //
            case 79: {
                //#line 152 "LPGParser.g"
                setResult(
                    //#line 152 LPGParser.g
                    new drop_rule(getLeftIToken(), getRightIToken(),
                                  //#line 152 LPGParser.g
                                  new ASTNodeToken(getRhsIToken(1)),
                                  //#line 152 LPGParser.g
                                  (optMacroName)getRhsSym(2),
                                  //#line 152 LPGParser.g
                                  (Iproduces)getRhsSym(3),
                                  //#line 152 LPGParser.g
                                  (ruleList)getRhsSym(4))
                //#line 152 LPGParser.g
                );
            break;
            }
            //
            // Rule 80:  optMacroName ::= $Empty
            //
            case 80: {
                //#line 154 "LPGParser.g"
                setResult(null);
            break;
            }
            //
            // Rule 81:  optMacroName ::= MACRO_NAME
            //
            case 81: {
                //#line 154 "LPGParser.g"
                setResult(
                    //#line 154 LPGParser.g
                    new optMacroName(getRhsIToken(1))
                //#line 154 LPGParser.g
                );
            break;
            }
            //
            // Rule 82:  include_segment ::= SYMBOL
            //
            case 82: {
                //#line 157 "LPGParser.g"
                setResult(
                    //#line 157 LPGParser.g
                    new include_segment(getRhsIToken(1))
                //#line 157 LPGParser.g
                );
            break;
            }
            //
            // Rule 83:  keywords_segment ::= keywordSpec
            //
            case 83: {
                //#line 160 "LPGParser.g"
                setResult(
                    //#line 160 LPGParser.g
                    new keywordSpecList((IkeywordSpec)getRhsSym(1), true /* left recursive */)
                //#line 160 LPGParser.g
                );
            break;
            }
            //
            // Rule 84:  keywords_segment ::= keywords_segment keywordSpec
            //
            case 84: {
                //#line 160 "LPGParser.g"
                ((keywordSpecList)getRhsSym(1)).addElement((IkeywordSpec)getRhsSym(2));
            break;
            }
            //
            // Rule 85:  keywordSpec ::= terminal_symbol
            //
            case 85:
                break;
            //
            // Rule 86:  keywordSpec ::= terminal_symbol produces name
            //
            case 86: {
                //#line 162 "LPGParser.g"
                setResult(
                    //#line 162 LPGParser.g
                    new keywordSpec(getLeftIToken(), getRightIToken(),
                                    //#line 162 LPGParser.g
                                    (Iterminal_symbol)getRhsSym(1),
                                    //#line 162 LPGParser.g
                                    (Iproduces)getRhsSym(2),
                                    //#line 162 LPGParser.g
                                    (Iname)getRhsSym(3))
                //#line 162 LPGParser.g
                );
            break;
            }
            //
            // Rule 87:  names_segment ::= nameSpec
            //
            case 87: {
                //#line 165 "LPGParser.g"
                setResult(
                    //#line 165 LPGParser.g
                    new nameSpecList((nameSpec)getRhsSym(1), true /* left recursive */)
                //#line 165 LPGParser.g
                );
            break;
            }
            //
            // Rule 88:  names_segment ::= names_segment nameSpec
            //
            case 88: {
                //#line 165 "LPGParser.g"
                ((nameSpecList)getRhsSym(1)).addElement((nameSpec)getRhsSym(2));
            break;
            }
            //
            // Rule 89:  nameSpec ::= name produces name
            //
            case 89: {
                //#line 166 "LPGParser.g"
                setResult(
                    //#line 166 LPGParser.g
                    new nameSpec(getLeftIToken(), getRightIToken(),
                                 //#line 166 LPGParser.g
                                 (Iname)getRhsSym(1),
                                 //#line 166 LPGParser.g
                                 (Iproduces)getRhsSym(2),
                                 //#line 166 LPGParser.g
                                 (Iname)getRhsSym(3))
                //#line 166 LPGParser.g
                );
            break;
            }
            //
            // Rule 90:  name ::= SYMBOL
            //
            case 90: {
                //#line 168 "LPGParser.g"
                setResult(
                    //#line 168 LPGParser.g
                    new name0(getRhsIToken(1))
                //#line 168 LPGParser.g
                );
            break;
            }
            //
            // Rule 91:  name ::= MACRO_NAME
            //
            case 91: {
                //#line 169 "LPGParser.g"
                setResult(
                    //#line 169 LPGParser.g
                    new name1(getRhsIToken(1))
                //#line 169 LPGParser.g
                );
            break;
            }
            //
            // Rule 92:  name ::= EMPTY_KEY
            //
            case 92: {
                //#line 170 "LPGParser.g"
                setResult(
                    //#line 170 LPGParser.g
                    new name2(getRhsIToken(1))
                //#line 170 LPGParser.g
                );
            break;
            }
            //
            // Rule 93:  name ::= ERROR_KEY
            //
            case 93: {
                //#line 171 "LPGParser.g"
                setResult(
                    //#line 171 LPGParser.g
                    new name3(getRhsIToken(1))
                //#line 171 LPGParser.g
                );
            break;
            }
            //
            // Rule 94:  name ::= EOL_KEY
            //
            case 94: {
                //#line 172 "LPGParser.g"
                setResult(
                    //#line 172 LPGParser.g
                    new name4(getRhsIToken(1))
                //#line 172 LPGParser.g
                );
            break;
            }
            //
            // Rule 95:  name ::= IDENTIFIER_KEY
            //
            case 95: {
                //#line 173 "LPGParser.g"
                setResult(
                    //#line 173 LPGParser.g
                    new name5(getRhsIToken(1))
                //#line 173 LPGParser.g
                );
            break;
            }
            //
            // Rule 96:  notice_segment ::= action_segment
            //
            case 96: {
                //#line 176 "LPGParser.g"
                setResult(
                    //#line 176 LPGParser.g
                    new action_segmentList((action_segment)getRhsSym(1), true /* left recursive */)
                //#line 176 LPGParser.g
                );
            break;
            }
            //
            // Rule 97:  notice_segment ::= notice_segment action_segment
            //
            case 97: {
                //#line 176 "LPGParser.g"
                ((action_segmentList)getRhsSym(1)).addElement((action_segment)getRhsSym(2));
            break;
            }
            //
            // Rule 98:  rules_segment ::= action_segment_list nonTermList
            //
            case 98: {
                //#line 179 "LPGParser.g"
                setResult(
                    //#line 179 LPGParser.g
                    new rules_segment(getLeftIToken(), getRightIToken(),
                                      //#line 179 LPGParser.g
                                      (action_segmentList)getRhsSym(1),
                                      //#line 179 LPGParser.g
                                      (nonTermList)getRhsSym(2))
                //#line 179 LPGParser.g
                );
            break;
            }
            //
            // Rule 99:  nonTermList ::= $Empty
            //
            case 99: {
                //#line 181 "LPGParser.g"
                setResult(
                    //#line 181 LPGParser.g
                    new nonTermList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 181 LPGParser.g
                );
            break;
            }
            //
            // Rule 100:  nonTermList ::= nonTermList nonTerm
            //
            case 100: {
                //#line 181 "LPGParser.g"
                ((nonTermList)getRhsSym(1)).addElement((nonTerm)getRhsSym(2));
            break;
            }
            //
            // Rule 101:  nonTerm ::= ruleNameWithAttributes produces ruleList
            //
            case 101: {
                //#line 183 "LPGParser.g"
                setResult(
                    //#line 183 LPGParser.g
                    new nonTerm(getLeftIToken(), getRightIToken(),
                                //#line 183 LPGParser.g
                                (RuleName)getRhsSym(1),
                                //#line 183 LPGParser.g
                                (Iproduces)getRhsSym(2),
                                //#line 183 LPGParser.g
                                (ruleList)getRhsSym(3))
                //#line 183 LPGParser.g
                );
            break;
            }
            //
            // Rule 102:  ruleNameWithAttributes ::= SYMBOL
            //
            case 102: {
                //#line 186 "LPGParser.g"
                setResult(
                    //#line 186 LPGParser.g
                    new RuleName(getLeftIToken(), getRightIToken(),
                                 //#line 186 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(1)),
                                 //#line 186 LPGParser.g
                                 (ASTNodeToken)null,
                                 //#line 186 LPGParser.g
                                 (ASTNodeToken)null)
                //#line 186 LPGParser.g
                );
            break;
            }
            //
            // Rule 103:  ruleNameWithAttributes ::= SYMBOL MACRO_NAME$className
            //
            case 103: {
                //#line 187 "LPGParser.g"
                setResult(
                    //#line 187 LPGParser.g
                    new RuleName(getLeftIToken(), getRightIToken(),
                                 //#line 187 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(1)),
                                 //#line 187 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(2)),
                                 //#line 187 LPGParser.g
                                 (ASTNodeToken)null)
                //#line 187 LPGParser.g
                );
            break;
            }
            //
            // Rule 104:  ruleNameWithAttributes ::= SYMBOL MACRO_NAME$className MACRO_NAME$arrayElement
            //
            case 104: {
                //#line 188 "LPGParser.g"
                setResult(
                    //#line 188 LPGParser.g
                    new RuleName(getLeftIToken(), getRightIToken(),
                                 //#line 188 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(1)),
                                 //#line 188 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(2)),
                                 //#line 188 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(3)))
                //#line 188 LPGParser.g
                );
            break;
            }
            //
            // Rule 105:  ruleList ::= rule
            //
            case 105: {
                //#line 202 "LPGParser.g"
                setResult(
                    //#line 202 LPGParser.g
                    new ruleList((rule)getRhsSym(1), true /* left recursive */)
                //#line 202 LPGParser.g
                );
            break;
            }
            //
            // Rule 106:  ruleList ::= ruleList |$ rule
            //
            case 106: {
                //#line 202 "LPGParser.g"
                ((ruleList)getRhsSym(1)).addElement((rule)getRhsSym(3));
            break;
            }
            //
            // Rule 107:  produces ::= ::=
            //
            case 107: {
                //#line 204 "LPGParser.g"
                setResult(
                    //#line 204 LPGParser.g
                    new produces0(getRhsIToken(1))
                //#line 204 LPGParser.g
                );
            break;
            }
            //
            // Rule 108:  produces ::= ::=?
            //
            case 108: {
                //#line 205 "LPGParser.g"
                setResult(
                    //#line 205 LPGParser.g
                    new produces1(getRhsIToken(1))
                //#line 205 LPGParser.g
                );
            break;
            }
            //
            // Rule 109:  produces ::= ->
            //
            case 109: {
                //#line 206 "LPGParser.g"
                setResult(
                    //#line 206 LPGParser.g
                    new produces2(getRhsIToken(1))
                //#line 206 LPGParser.g
                );
            break;
            }
            //
            // Rule 110:  produces ::= ->?
            //
            case 110: {
                //#line 207 "LPGParser.g"
                setResult(
                    //#line 207 LPGParser.g
                    new produces3(getRhsIToken(1))
                //#line 207 LPGParser.g
                );
            break;
            }
            //
            // Rule 111:  rule ::= symWithAttrsList opt_action_segment
            //
            case 111: {
                //#line 209 "LPGParser.g"
                setResult(
                    //#line 209 LPGParser.g
                    new rule(getLeftIToken(), getRightIToken(),
                             //#line 209 LPGParser.g
                             (symWithAttrsList)getRhsSym(1),
                             //#line 209 LPGParser.g
                             (action_segment)getRhsSym(2))
                //#line 209 LPGParser.g
                );
            break;
            }
            //
            // Rule 112:  symWithAttrsList ::= $Empty
            //
            case 112: {
                //#line 211 "LPGParser.g"
                setResult(
                    //#line 211 LPGParser.g
                    new symWithAttrsList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 211 LPGParser.g
                );
            break;
            }
            //
            // Rule 113:  symWithAttrsList ::= symWithAttrsList symWithAttrs
            //
            case 113: {
                //#line 211 "LPGParser.g"
                ((symWithAttrsList)getRhsSym(1)).addElement((IsymWithAttrs)getRhsSym(2));
            break;
            }
            //
            // Rule 114:  symWithAttrs ::= EMPTY_KEY
            //
            case 114: {
                //#line 213 "LPGParser.g"
                setResult(
                    //#line 213 LPGParser.g
                    new symWithAttrs0(getRhsIToken(1))
                //#line 213 LPGParser.g
                );
            break;
            }
            //
            // Rule 115:  symWithAttrs ::= SYMBOL optAttrList
            //
            case 115: {
                //#line 214 "LPGParser.g"
                setResult(
                    //#line 214 LPGParser.g
                    new symWithAttrs1(getLeftIToken(), getRightIToken(),
                                      //#line 214 LPGParser.g
                                      new ASTNodeToken(getRhsIToken(1)),
                                      //#line 214 LPGParser.g
                                      (symAttrs)getRhsSym(2))
                //#line 214 LPGParser.g
                );
            break;
            }
            //
            // Rule 116:  optAttrList ::= $Empty
            //
            case 116: {
                //#line 217 "LPGParser.g"
                setResult(
                    //#line 217 LPGParser.g
                    new symAttrs(getLeftIToken(), getRightIToken(),
                                 //#line 217 LPGParser.g
                                 (ASTNodeToken)null)
                //#line 217 LPGParser.g
                );
            break;
            }
            //
            // Rule 117:  optAttrList ::= MACRO_NAME
            //
            case 117: {
                //#line 218 "LPGParser.g"
                setResult(
                    //#line 218 LPGParser.g
                    new symAttrs(getLeftIToken(), getRightIToken(),
                                 //#line 218 LPGParser.g
                                 new ASTNodeToken(getRhsIToken(1)))
                //#line 218 LPGParser.g
                );
            break;
            }
            //
            // Rule 118:  opt_action_segment ::= $Empty
            //
            case 118: {
                //#line 220 "LPGParser.g"
                setResult(null);
            break;
            }
            //
            // Rule 119:  opt_action_segment ::= action_segment
            //
            case 119:
                break;
            //
            // Rule 120:  action_segment ::= BLOCK
            //
            case 120: {
                //#line 222 "LPGParser.g"
                setResult(
                    //#line 222 LPGParser.g
                    new action_segment(this, getRhsIToken(1))
                //#line 222 LPGParser.g
                );
            break;
            }
            //
            // Rule 121:  start_segment ::= start_symbol
            //
            case 121: {
                //#line 227 "LPGParser.g"
                setResult(
                    //#line 227 LPGParser.g
                    new start_symbolList((Istart_symbol)getRhsSym(1), true /* left recursive */)
                //#line 227 LPGParser.g
                );
            break;
            }
            //
            // Rule 122:  start_segment ::= start_segment start_symbol
            //
            case 122: {
                //#line 227 "LPGParser.g"
                ((start_symbolList)getRhsSym(1)).addElement((Istart_symbol)getRhsSym(2));
            break;
            }
            //
            // Rule 123:  start_symbol ::= SYMBOL
            //
            case 123: {
                //#line 228 "LPGParser.g"
                setResult(
                    //#line 228 LPGParser.g
                    new start_symbol0(getRhsIToken(1))
                //#line 228 LPGParser.g
                );
            break;
            }
            //
            // Rule 124:  start_symbol ::= MACRO_NAME
            //
            case 124: {
                //#line 229 "LPGParser.g"
                setResult(
                    //#line 229 LPGParser.g
                    new start_symbol1(getRhsIToken(1))
                //#line 229 LPGParser.g
                );
            break;
            }
            //
            // Rule 125:  terminals_segment ::= terminal
            //
            case 125: {
                //#line 232 "LPGParser.g"
                setResult(
                    //#line 232 LPGParser.g
                    new terminalList((terminal)getRhsSym(1), true /* left recursive */)
                //#line 232 LPGParser.g
                );
            break;
            }
            //
            // Rule 126:  terminals_segment ::= terminals_segment terminal
            //
            case 126: {
                //#line 232 "LPGParser.g"
                ((terminalList)getRhsSym(1)).addElement((terminal)getRhsSym(2));
            break;
            }
            //
            // Rule 127:  terminal ::= terminal_symbol optTerminalAlias
            //
            case 127: {
                //#line 235 "LPGParser.g"
                setResult(
                    //#line 235 LPGParser.g
                    new terminal(getLeftIToken(), getRightIToken(),
                                 //#line 235 LPGParser.g
                                 (Iterminal_symbol)getRhsSym(1),
                                 //#line 235 LPGParser.g
                                 (optTerminalAlias)getRhsSym(2))
                //#line 235 LPGParser.g
                );
            break;
            }
            //
            // Rule 128:  optTerminalAlias ::= $Empty
            //
            case 128: {
                //#line 237 "LPGParser.g"
                setResult(null);
            break;
            }
            //
            // Rule 129:  optTerminalAlias ::= produces name
            //
            case 129: {
                //#line 237 "LPGParser.g"
                setResult(
                    //#line 237 LPGParser.g
                    new optTerminalAlias(getLeftIToken(), getRightIToken(),
                                         //#line 237 LPGParser.g
                                         (Iproduces)getRhsSym(1),
                                         //#line 237 LPGParser.g
                                         (Iname)getRhsSym(2))
                //#line 237 LPGParser.g
                );
            break;
            }
            //
            // Rule 130:  terminal_symbol ::= SYMBOL
            //
            case 130: {
                //#line 239 "LPGParser.g"
                setResult(
                    //#line 239 LPGParser.g
                    new terminal_symbol0(getRhsIToken(1))
                //#line 239 LPGParser.g
                );
            break;
            }
            //
            // Rule 131:  terminal_symbol ::= MACRO_NAME
            //
            case 131: {
                //#line 241 "LPGParser.g"
                setResult(
                    //#line 241 LPGParser.g
                    new terminal_symbol1(getRhsIToken(1))
                //#line 241 LPGParser.g
                );
            break;
            }
            //
            // Rule 132:  trailers_segment ::= action_segment_list
            //
            case 132:
                break;
            //
            // Rule 133:  types_segment ::= type_declarations
            //
            case 133: {
                //#line 247 "LPGParser.g"
                setResult(
                    //#line 247 LPGParser.g
                    new type_declarationsList((type_declarations)getRhsSym(1), true /* left recursive */)
                //#line 247 LPGParser.g
                );
            break;
            }
            //
            // Rule 134:  types_segment ::= types_segment type_declarations
            //
            case 134: {
                //#line 247 "LPGParser.g"
                ((type_declarationsList)getRhsSym(1)).addElement((type_declarations)getRhsSym(2));
            break;
            }
            //
            // Rule 135:  type_declarations ::= SYMBOL produces barSymbolList opt_action_segment
            //
            case 135: {
                //#line 249 "LPGParser.g"
                setResult(
                    //#line 249 LPGParser.g
                    new type_declarations(getLeftIToken(), getRightIToken(),
                                          //#line 249 LPGParser.g
                                          new ASTNodeToken(getRhsIToken(1)),
                                          //#line 249 LPGParser.g
                                          (Iproduces)getRhsSym(2),
                                          //#line 249 LPGParser.g
                                          (SYMBOLList)getRhsSym(3),
                                          //#line 249 LPGParser.g
                                          (action_segment)getRhsSym(4))
                //#line 249 LPGParser.g
                );
            break;
            }
            //
            // Rule 136:  barSymbolList ::= SYMBOL
            //
            case 136: {
                //#line 250 "LPGParser.g"
                setResult(
                    //#line 250 LPGParser.g
                    new SYMBOLList(new ASTNodeToken(getRhsIToken(1)), true /* left recursive */)
                //#line 250 LPGParser.g
                );
            break;
            }
            //
            // Rule 137:  barSymbolList ::= barSymbolList |$ SYMBOL
            //
            case 137: {
                //#line 250 "LPGParser.g"
                ((SYMBOLList)getRhsSym(1)).addElement(new ASTNodeToken(getRhsIToken(3)));
            break;
            }
            //
            // Rule 138:  predecessor_segment ::= $Empty
            //
            case 138: {
                //#line 253 "LPGParser.g"
                setResult(
                    //#line 253 LPGParser.g
                    new symbol_pairList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 253 LPGParser.g
                );
            break;
            }
            //
            // Rule 139:  predecessor_segment ::= predecessor_segment symbol_pair
            //
            case 139: {
                //#line 253 "LPGParser.g"
                ((symbol_pairList)getRhsSym(1)).addElement((symbol_pair)getRhsSym(2));
            break;
            }
            //
            // Rule 140:  symbol_pair ::= SYMBOL SYMBOL
            //
            case 140: {
                //#line 255 "LPGParser.g"
                setResult(
                    //#line 255 LPGParser.g
                    new symbol_pair(getLeftIToken(), getRightIToken(),
                                    //#line 255 LPGParser.g
                                    new ASTNodeToken(getRhsIToken(1)),
                                    //#line 255 LPGParser.g
                                    new ASTNodeToken(getRhsIToken(2)))
                //#line 255 LPGParser.g
                );
            break;
            }
            //
            // Rule 141:  recover_segment ::= $Empty
            //
            case 141: {
                //#line 258 "LPGParser.g"
                setResult(
                    //#line 258 LPGParser.g
                    new SYMBOLList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 258 LPGParser.g
                );
            break;
            }
            //
            // Rule 142:  recover_segment ::= recover_segment recover_symbol
            //
            case 142: {
                //#line 258 "LPGParser.g"
                setResult((SYMBOLList)getRhsSym(1));
            break;
            }
            //
            // Rule 143:  recover_symbol ::= SYMBOL
            //
            case 143: {
                //#line 260 "LPGParser.g"
                setResult(
                    //#line 260 LPGParser.g
                    new recover_symbol(getRhsIToken(1))
                //#line 260 LPGParser.g
                );
            break;
            }
            //
            // Rule 144:  END_KEY_OPT ::= $Empty
            //
            case 144: {
                //#line 263 "LPGParser.g"
                setResult(null);
            break;
            }
            //
            // Rule 145:  END_KEY_OPT ::= END_KEY
            //
            case 145: {
                //#line 264 "LPGParser.g"
                setResult(
                    //#line 264 LPGParser.g
                    new END_KEY_OPT(getRhsIToken(1))
                //#line 264 LPGParser.g
                );
            break;
            }
            //
            // Rule 146:  action_segment_list ::= $Empty
            //
            case 146: {
                //#line 266 "LPGParser.g"
                setResult(
                    //#line 266 LPGParser.g
                    new action_segmentList(getLeftIToken(), getRightIToken(), true /* left recursive */)
                //#line 266 LPGParser.g
                );
            break;
            }
            //
            // Rule 147:  action_segment_list ::= action_segment_list action_segment
            //
            case 147: {
                //#line 267 "LPGParser.g"
                ((action_segmentList)getRhsSym(1)).addElement((action_segment)getRhsSym(2));
            break;
            }
    //#line 330 "dtParserTemplateF.gi

    
            default:
                break;
        }
        return;
    }
}
}

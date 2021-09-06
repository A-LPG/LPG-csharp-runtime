namespace LpgExample.Ast
{

public abstract class AbstractResultVisitor : ResultVisitor, ResultArgumentVisitor
{
    public abstract object unimplementedVisitor(string s);

    public object visit(ASTNodeToken n) { return unimplementedVisitor("visit(ASTNodeToken)"); }
    public object visit(ASTNodeToken n, object o) { return  unimplementedVisitor("visit(ASTNodeToken, object)"); }

    public object visit(LPG n) { return unimplementedVisitor("visit(LPG)"); }
    public object visit(LPG n, object o) { return  unimplementedVisitor("visit(LPG, object)"); }

    public object visit(LPG_itemList n) { return unimplementedVisitor("visit(LPG_itemList)"); }
    public object visit(LPG_itemList n, object o) { return  unimplementedVisitor("visit(LPG_itemList, object)"); }

    public object visit(AliasSeg n) { return unimplementedVisitor("visit(AliasSeg)"); }
    public object visit(AliasSeg n, object o) { return  unimplementedVisitor("visit(AliasSeg, object)"); }

    public object visit(AstSeg n) { return unimplementedVisitor("visit(AstSeg)"); }
    public object visit(AstSeg n, object o) { return  unimplementedVisitor("visit(AstSeg, object)"); }

    public object visit(DefineSeg n) { return unimplementedVisitor("visit(DefineSeg)"); }
    public object visit(DefineSeg n, object o) { return  unimplementedVisitor("visit(DefineSeg, object)"); }

    public object visit(EofSeg n) { return unimplementedVisitor("visit(EofSeg)"); }
    public object visit(EofSeg n, object o) { return  unimplementedVisitor("visit(EofSeg, object)"); }

    public object visit(EolSeg n) { return unimplementedVisitor("visit(EolSeg)"); }
    public object visit(EolSeg n, object o) { return  unimplementedVisitor("visit(EolSeg, object)"); }

    public object visit(ErrorSeg n) { return unimplementedVisitor("visit(ErrorSeg)"); }
    public object visit(ErrorSeg n, object o) { return  unimplementedVisitor("visit(ErrorSeg, object)"); }

    public object visit(ExportSeg n) { return unimplementedVisitor("visit(ExportSeg)"); }
    public object visit(ExportSeg n, object o) { return  unimplementedVisitor("visit(ExportSeg, object)"); }

    public object visit(GlobalsSeg n) { return unimplementedVisitor("visit(GlobalsSeg)"); }
    public object visit(GlobalsSeg n, object o) { return  unimplementedVisitor("visit(GlobalsSeg, object)"); }

    public object visit(HeadersSeg n) { return unimplementedVisitor("visit(HeadersSeg)"); }
    public object visit(HeadersSeg n, object o) { return  unimplementedVisitor("visit(HeadersSeg, object)"); }

    public object visit(IdentifierSeg n) { return unimplementedVisitor("visit(IdentifierSeg)"); }
    public object visit(IdentifierSeg n, object o) { return  unimplementedVisitor("visit(IdentifierSeg, object)"); }

    public object visit(ImportSeg n) { return unimplementedVisitor("visit(ImportSeg)"); }
    public object visit(ImportSeg n, object o) { return  unimplementedVisitor("visit(ImportSeg, object)"); }

    public object visit(IncludeSeg n) { return unimplementedVisitor("visit(IncludeSeg)"); }
    public object visit(IncludeSeg n, object o) { return  unimplementedVisitor("visit(IncludeSeg, object)"); }

    public object visit(KeywordsSeg n) { return unimplementedVisitor("visit(KeywordsSeg)"); }
    public object visit(KeywordsSeg n, object o) { return  unimplementedVisitor("visit(KeywordsSeg, object)"); }

    public object visit(NamesSeg n) { return unimplementedVisitor("visit(NamesSeg)"); }
    public object visit(NamesSeg n, object o) { return  unimplementedVisitor("visit(NamesSeg, object)"); }

    public object visit(NoticeSeg n) { return unimplementedVisitor("visit(NoticeSeg)"); }
    public object visit(NoticeSeg n, object o) { return  unimplementedVisitor("visit(NoticeSeg, object)"); }

    public object visit(RulesSeg n) { return unimplementedVisitor("visit(RulesSeg)"); }
    public object visit(RulesSeg n, object o) { return  unimplementedVisitor("visit(RulesSeg, object)"); }

    public object visit(SoftKeywordsSeg n) { return unimplementedVisitor("visit(SoftKeywordsSeg)"); }
    public object visit(SoftKeywordsSeg n, object o) { return  unimplementedVisitor("visit(SoftKeywordsSeg, object)"); }

    public object visit(StartSeg n) { return unimplementedVisitor("visit(StartSeg)"); }
    public object visit(StartSeg n, object o) { return  unimplementedVisitor("visit(StartSeg, object)"); }

    public object visit(TerminalsSeg n) { return unimplementedVisitor("visit(TerminalsSeg)"); }
    public object visit(TerminalsSeg n, object o) { return  unimplementedVisitor("visit(TerminalsSeg, object)"); }

    public object visit(TrailersSeg n) { return unimplementedVisitor("visit(TrailersSeg)"); }
    public object visit(TrailersSeg n, object o) { return  unimplementedVisitor("visit(TrailersSeg, object)"); }

    public object visit(TypesSeg n) { return unimplementedVisitor("visit(TypesSeg)"); }
    public object visit(TypesSeg n, object o) { return  unimplementedVisitor("visit(TypesSeg, object)"); }

    public object visit(RecoverSeg n) { return unimplementedVisitor("visit(RecoverSeg)"); }
    public object visit(RecoverSeg n, object o) { return  unimplementedVisitor("visit(RecoverSeg, object)"); }

    public object visit(PredecessorSeg n) { return unimplementedVisitor("visit(PredecessorSeg)"); }
    public object visit(PredecessorSeg n, object o) { return  unimplementedVisitor("visit(PredecessorSeg, object)"); }

    public object visit(option_specList n) { return unimplementedVisitor("visit(option_specList)"); }
    public object visit(option_specList n, object o) { return  unimplementedVisitor("visit(option_specList, object)"); }

    public object visit(option_spec n) { return unimplementedVisitor("visit(option_spec)"); }
    public object visit(option_spec n, object o) { return  unimplementedVisitor("visit(option_spec, object)"); }

    public object visit(optionList n) { return unimplementedVisitor("visit(optionList)"); }
    public object visit(optionList n, object o) { return  unimplementedVisitor("visit(optionList, object)"); }

    public object visit(option n) { return unimplementedVisitor("visit(option)"); }
    public object visit(option n, object o) { return  unimplementedVisitor("visit(option, object)"); }

    public object visit(SYMBOLList n) { return unimplementedVisitor("visit(SYMBOLList)"); }
    public object visit(SYMBOLList n, object o) { return  unimplementedVisitor("visit(SYMBOLList, object)"); }

    public object visit(aliasSpecList n) { return unimplementedVisitor("visit(aliasSpecList)"); }
    public object visit(aliasSpecList n, object o) { return  unimplementedVisitor("visit(aliasSpecList, object)"); }

    public object visit(alias_lhs_macro_name n) { return unimplementedVisitor("visit(alias_lhs_macro_name)"); }
    public object visit(alias_lhs_macro_name n, object o) { return  unimplementedVisitor("visit(alias_lhs_macro_name, object)"); }

    public object visit(defineSpecList n) { return unimplementedVisitor("visit(defineSpecList)"); }
    public object visit(defineSpecList n, object o) { return  unimplementedVisitor("visit(defineSpecList, object)"); }

    public object visit(defineSpec n) { return unimplementedVisitor("visit(defineSpec)"); }
    public object visit(defineSpec n, object o) { return  unimplementedVisitor("visit(defineSpec, object)"); }

    public object visit(macro_segment n) { return unimplementedVisitor("visit(macro_segment)"); }
    public object visit(macro_segment n, object o) { return  unimplementedVisitor("visit(macro_segment, object)"); }

    public object visit(terminal_symbolList n) { return unimplementedVisitor("visit(terminal_symbolList)"); }
    public object visit(terminal_symbolList n, object o) { return  unimplementedVisitor("visit(terminal_symbolList, object)"); }

    public object visit(action_segmentList n) { return unimplementedVisitor("visit(action_segmentList)"); }
    public object visit(action_segmentList n, object o) { return  unimplementedVisitor("visit(action_segmentList, object)"); }

    public object visit(import_segment n) { return unimplementedVisitor("visit(import_segment)"); }
    public object visit(import_segment n, object o) { return  unimplementedVisitor("visit(import_segment, object)"); }

    public object visit(drop_commandList n) { return unimplementedVisitor("visit(drop_commandList)"); }
    public object visit(drop_commandList n, object o) { return  unimplementedVisitor("visit(drop_commandList, object)"); }

    public object visit(drop_ruleList n) { return unimplementedVisitor("visit(drop_ruleList)"); }
    public object visit(drop_ruleList n, object o) { return  unimplementedVisitor("visit(drop_ruleList, object)"); }

    public object visit(drop_rule n) { return unimplementedVisitor("visit(drop_rule)"); }
    public object visit(drop_rule n, object o) { return  unimplementedVisitor("visit(drop_rule, object)"); }

    public object visit(optMacroName n) { return unimplementedVisitor("visit(optMacroName)"); }
    public object visit(optMacroName n, object o) { return  unimplementedVisitor("visit(optMacroName, object)"); }

    public object visit(include_segment n) { return unimplementedVisitor("visit(include_segment)"); }
    public object visit(include_segment n, object o) { return  unimplementedVisitor("visit(include_segment, object)"); }

    public object visit(keywordSpecList n) { return unimplementedVisitor("visit(keywordSpecList)"); }
    public object visit(keywordSpecList n, object o) { return  unimplementedVisitor("visit(keywordSpecList, object)"); }

    public object visit(keywordSpec n) { return unimplementedVisitor("visit(keywordSpec)"); }
    public object visit(keywordSpec n, object o) { return  unimplementedVisitor("visit(keywordSpec, object)"); }

    public object visit(nameSpecList n) { return unimplementedVisitor("visit(nameSpecList)"); }
    public object visit(nameSpecList n, object o) { return  unimplementedVisitor("visit(nameSpecList, object)"); }

    public object visit(nameSpec n) { return unimplementedVisitor("visit(nameSpec)"); }
    public object visit(nameSpec n, object o) { return  unimplementedVisitor("visit(nameSpec, object)"); }

    public object visit(rules_segment n) { return unimplementedVisitor("visit(rules_segment)"); }
    public object visit(rules_segment n, object o) { return  unimplementedVisitor("visit(rules_segment, object)"); }

    public object visit(nonTermList n) { return unimplementedVisitor("visit(nonTermList)"); }
    public object visit(nonTermList n, object o) { return  unimplementedVisitor("visit(nonTermList, object)"); }

    public object visit(nonTerm n) { return unimplementedVisitor("visit(nonTerm)"); }
    public object visit(nonTerm n, object o) { return  unimplementedVisitor("visit(nonTerm, object)"); }

    public object visit(RuleName n) { return unimplementedVisitor("visit(RuleName)"); }
    public object visit(RuleName n, object o) { return  unimplementedVisitor("visit(RuleName, object)"); }

    public object visit(ruleList n) { return unimplementedVisitor("visit(ruleList)"); }
    public object visit(ruleList n, object o) { return  unimplementedVisitor("visit(ruleList, object)"); }

    public object visit(rule n) { return unimplementedVisitor("visit(rule)"); }
    public object visit(rule n, object o) { return  unimplementedVisitor("visit(rule, object)"); }

    public object visit(symWithAttrsList n) { return unimplementedVisitor("visit(symWithAttrsList)"); }
    public object visit(symWithAttrsList n, object o) { return  unimplementedVisitor("visit(symWithAttrsList, object)"); }

    public object visit(symAttrs n) { return unimplementedVisitor("visit(symAttrs)"); }
    public object visit(symAttrs n, object o) { return  unimplementedVisitor("visit(symAttrs, object)"); }

    public object visit(action_segment n) { return unimplementedVisitor("visit(action_segment)"); }
    public object visit(action_segment n, object o) { return  unimplementedVisitor("visit(action_segment, object)"); }

    public object visit(start_symbolList n) { return unimplementedVisitor("visit(start_symbolList)"); }
    public object visit(start_symbolList n, object o) { return  unimplementedVisitor("visit(start_symbolList, object)"); }

    public object visit(terminalList n) { return unimplementedVisitor("visit(terminalList)"); }
    public object visit(terminalList n, object o) { return  unimplementedVisitor("visit(terminalList, object)"); }

    public object visit(terminal n) { return unimplementedVisitor("visit(terminal)"); }
    public object visit(terminal n, object o) { return  unimplementedVisitor("visit(terminal, object)"); }

    public object visit(optTerminalAlias n) { return unimplementedVisitor("visit(optTerminalAlias)"); }
    public object visit(optTerminalAlias n, object o) { return  unimplementedVisitor("visit(optTerminalAlias, object)"); }

    public object visit(type_declarationsList n) { return unimplementedVisitor("visit(type_declarationsList)"); }
    public object visit(type_declarationsList n, object o) { return  unimplementedVisitor("visit(type_declarationsList, object)"); }

    public object visit(type_declarations n) { return unimplementedVisitor("visit(type_declarations)"); }
    public object visit(type_declarations n, object o) { return  unimplementedVisitor("visit(type_declarations, object)"); }

    public object visit(symbol_pairList n) { return unimplementedVisitor("visit(symbol_pairList)"); }
    public object visit(symbol_pairList n, object o) { return  unimplementedVisitor("visit(symbol_pairList, object)"); }

    public object visit(symbol_pair n) { return unimplementedVisitor("visit(symbol_pair)"); }
    public object visit(symbol_pair n, object o) { return  unimplementedVisitor("visit(symbol_pair, object)"); }

    public object visit(recover_symbol n) { return unimplementedVisitor("visit(recover_symbol)"); }
    public object visit(recover_symbol n, object o) { return  unimplementedVisitor("visit(recover_symbol, object)"); }

    public object visit(END_KEY_OPT n) { return unimplementedVisitor("visit(END_KEY_OPT)"); }
    public object visit(END_KEY_OPT n, object o) { return  unimplementedVisitor("visit(END_KEY_OPT, object)"); }

    public object visit(option_value0 n) { return unimplementedVisitor("visit(option_value0)"); }
    public object visit(option_value0 n, object o) { return  unimplementedVisitor("visit(option_value0, object)"); }

    public object visit(option_value1 n) { return unimplementedVisitor("visit(option_value1)"); }
    public object visit(option_value1 n, object o) { return  unimplementedVisitor("visit(option_value1, object)"); }

    public object visit(aliasSpec0 n) { return unimplementedVisitor("visit(aliasSpec0)"); }
    public object visit(aliasSpec0 n, object o) { return  unimplementedVisitor("visit(aliasSpec0, object)"); }

    public object visit(aliasSpec1 n) { return unimplementedVisitor("visit(aliasSpec1)"); }
    public object visit(aliasSpec1 n, object o) { return  unimplementedVisitor("visit(aliasSpec1, object)"); }

    public object visit(aliasSpec2 n) { return unimplementedVisitor("visit(aliasSpec2)"); }
    public object visit(aliasSpec2 n, object o) { return  unimplementedVisitor("visit(aliasSpec2, object)"); }

    public object visit(aliasSpec3 n) { return unimplementedVisitor("visit(aliasSpec3)"); }
    public object visit(aliasSpec3 n, object o) { return  unimplementedVisitor("visit(aliasSpec3, object)"); }

    public object visit(aliasSpec4 n) { return unimplementedVisitor("visit(aliasSpec4)"); }
    public object visit(aliasSpec4 n, object o) { return  unimplementedVisitor("visit(aliasSpec4, object)"); }

    public object visit(aliasSpec5 n) { return unimplementedVisitor("visit(aliasSpec5)"); }
    public object visit(aliasSpec5 n, object o) { return  unimplementedVisitor("visit(aliasSpec5, object)"); }

    public object visit(alias_rhs0 n) { return unimplementedVisitor("visit(alias_rhs0)"); }
    public object visit(alias_rhs0 n, object o) { return  unimplementedVisitor("visit(alias_rhs0, object)"); }

    public object visit(alias_rhs1 n) { return unimplementedVisitor("visit(alias_rhs1)"); }
    public object visit(alias_rhs1 n, object o) { return  unimplementedVisitor("visit(alias_rhs1, object)"); }

    public object visit(alias_rhs2 n) { return unimplementedVisitor("visit(alias_rhs2)"); }
    public object visit(alias_rhs2 n, object o) { return  unimplementedVisitor("visit(alias_rhs2, object)"); }

    public object visit(alias_rhs3 n) { return unimplementedVisitor("visit(alias_rhs3)"); }
    public object visit(alias_rhs3 n, object o) { return  unimplementedVisitor("visit(alias_rhs3, object)"); }

    public object visit(alias_rhs4 n) { return unimplementedVisitor("visit(alias_rhs4)"); }
    public object visit(alias_rhs4 n, object o) { return  unimplementedVisitor("visit(alias_rhs4, object)"); }

    public object visit(alias_rhs5 n) { return unimplementedVisitor("visit(alias_rhs5)"); }
    public object visit(alias_rhs5 n, object o) { return  unimplementedVisitor("visit(alias_rhs5, object)"); }

    public object visit(alias_rhs6 n) { return unimplementedVisitor("visit(alias_rhs6)"); }
    public object visit(alias_rhs6 n, object o) { return  unimplementedVisitor("visit(alias_rhs6, object)"); }

    public object visit(macro_name_symbol0 n) { return unimplementedVisitor("visit(macro_name_symbol0)"); }
    public object visit(macro_name_symbol0 n, object o) { return  unimplementedVisitor("visit(macro_name_symbol0, object)"); }

    public object visit(macro_name_symbol1 n) { return unimplementedVisitor("visit(macro_name_symbol1)"); }
    public object visit(macro_name_symbol1 n, object o) { return  unimplementedVisitor("visit(macro_name_symbol1, object)"); }

    public object visit(drop_command0 n) { return unimplementedVisitor("visit(drop_command0)"); }
    public object visit(drop_command0 n, object o) { return  unimplementedVisitor("visit(drop_command0, object)"); }

    public object visit(drop_command1 n) { return unimplementedVisitor("visit(drop_command1)"); }
    public object visit(drop_command1 n, object o) { return  unimplementedVisitor("visit(drop_command1, object)"); }

    public object visit(name0 n) { return unimplementedVisitor("visit(name0)"); }
    public object visit(name0 n, object o) { return  unimplementedVisitor("visit(name0, object)"); }

    public object visit(name1 n) { return unimplementedVisitor("visit(name1)"); }
    public object visit(name1 n, object o) { return  unimplementedVisitor("visit(name1, object)"); }

    public object visit(name2 n) { return unimplementedVisitor("visit(name2)"); }
    public object visit(name2 n, object o) { return  unimplementedVisitor("visit(name2, object)"); }

    public object visit(name3 n) { return unimplementedVisitor("visit(name3)"); }
    public object visit(name3 n, object o) { return  unimplementedVisitor("visit(name3, object)"); }

    public object visit(name4 n) { return unimplementedVisitor("visit(name4)"); }
    public object visit(name4 n, object o) { return  unimplementedVisitor("visit(name4, object)"); }

    public object visit(name5 n) { return unimplementedVisitor("visit(name5)"); }
    public object visit(name5 n, object o) { return  unimplementedVisitor("visit(name5, object)"); }

    public object visit(produces0 n) { return unimplementedVisitor("visit(produces0)"); }
    public object visit(produces0 n, object o) { return  unimplementedVisitor("visit(produces0, object)"); }

    public object visit(produces1 n) { return unimplementedVisitor("visit(produces1)"); }
    public object visit(produces1 n, object o) { return  unimplementedVisitor("visit(produces1, object)"); }

    public object visit(produces2 n) { return unimplementedVisitor("visit(produces2)"); }
    public object visit(produces2 n, object o) { return  unimplementedVisitor("visit(produces2, object)"); }

    public object visit(produces3 n) { return unimplementedVisitor("visit(produces3)"); }
    public object visit(produces3 n, object o) { return  unimplementedVisitor("visit(produces3, object)"); }

    public object visit(symWithAttrs0 n) { return unimplementedVisitor("visit(symWithAttrs0)"); }
    public object visit(symWithAttrs0 n, object o) { return  unimplementedVisitor("visit(symWithAttrs0, object)"); }

    public object visit(symWithAttrs1 n) { return unimplementedVisitor("visit(symWithAttrs1)"); }
    public object visit(symWithAttrs1 n, object o) { return  unimplementedVisitor("visit(symWithAttrs1, object)"); }

    public object visit(start_symbol0 n) { return unimplementedVisitor("visit(start_symbol0)"); }
    public object visit(start_symbol0 n, object o) { return  unimplementedVisitor("visit(start_symbol0, object)"); }

    public object visit(start_symbol1 n) { return unimplementedVisitor("visit(start_symbol1)"); }
    public object visit(start_symbol1 n, object o) { return  unimplementedVisitor("visit(start_symbol1, object)"); }

    public object visit(terminal_symbol0 n) { return unimplementedVisitor("visit(terminal_symbol0)"); }
    public object visit(terminal_symbol0 n, object o) { return  unimplementedVisitor("visit(terminal_symbol0, object)"); }

    public object visit(terminal_symbol1 n) { return unimplementedVisitor("visit(terminal_symbol1)"); }
    public object visit(terminal_symbol1 n, object o) { return  unimplementedVisitor("visit(terminal_symbol1, object)"); }


    public object visit(ASTNode n)
    {
        if (n is ASTNodeToken) return visit((ASTNodeToken) n);
        else if (n is LPG) return visit((LPG) n);
        else if (n is LPG_itemList) return visit((LPG_itemList) n);
        else if (n is AliasSeg) return visit((AliasSeg) n);
        else if (n is AstSeg) return visit((AstSeg) n);
        else if (n is DefineSeg) return visit((DefineSeg) n);
        else if (n is EofSeg) return visit((EofSeg) n);
        else if (n is EolSeg) return visit((EolSeg) n);
        else if (n is ErrorSeg) return visit((ErrorSeg) n);
        else if (n is ExportSeg) return visit((ExportSeg) n);
        else if (n is GlobalsSeg) return visit((GlobalsSeg) n);
        else if (n is HeadersSeg) return visit((HeadersSeg) n);
        else if (n is IdentifierSeg) return visit((IdentifierSeg) n);
        else if (n is ImportSeg) return visit((ImportSeg) n);
        else if (n is IncludeSeg) return visit((IncludeSeg) n);
        else if (n is KeywordsSeg) return visit((KeywordsSeg) n);
        else if (n is NamesSeg) return visit((NamesSeg) n);
        else if (n is NoticeSeg) return visit((NoticeSeg) n);
        else if (n is RulesSeg) return visit((RulesSeg) n);
        else if (n is SoftKeywordsSeg) return visit((SoftKeywordsSeg) n);
        else if (n is StartSeg) return visit((StartSeg) n);
        else if (n is TerminalsSeg) return visit((TerminalsSeg) n);
        else if (n is TrailersSeg) return visit((TrailersSeg) n);
        else if (n is TypesSeg) return visit((TypesSeg) n);
        else if (n is RecoverSeg) return visit((RecoverSeg) n);
        else if (n is PredecessorSeg) return visit((PredecessorSeg) n);
        else if (n is option_specList) return visit((option_specList) n);
        else if (n is option_spec) return visit((option_spec) n);
        else if (n is optionList) return visit((optionList) n);
        else if (n is option) return visit((option) n);
        else if (n is SYMBOLList) return visit((SYMBOLList) n);
        else if (n is aliasSpecList) return visit((aliasSpecList) n);
        else if (n is alias_lhs_macro_name) return visit((alias_lhs_macro_name) n);
        else if (n is defineSpecList) return visit((defineSpecList) n);
        else if (n is defineSpec) return visit((defineSpec) n);
        else if (n is macro_segment) return visit((macro_segment) n);
        else if (n is terminal_symbolList) return visit((terminal_symbolList) n);
        else if (n is action_segmentList) return visit((action_segmentList) n);
        else if (n is import_segment) return visit((import_segment) n);
        else if (n is drop_commandList) return visit((drop_commandList) n);
        else if (n is drop_ruleList) return visit((drop_ruleList) n);
        else if (n is drop_rule) return visit((drop_rule) n);
        else if (n is optMacroName) return visit((optMacroName) n);
        else if (n is include_segment) return visit((include_segment) n);
        else if (n is keywordSpecList) return visit((keywordSpecList) n);
        else if (n is keywordSpec) return visit((keywordSpec) n);
        else if (n is nameSpecList) return visit((nameSpecList) n);
        else if (n is nameSpec) return visit((nameSpec) n);
        else if (n is rules_segment) return visit((rules_segment) n);
        else if (n is nonTermList) return visit((nonTermList) n);
        else if (n is nonTerm) return visit((nonTerm) n);
        else if (n is RuleName) return visit((RuleName) n);
        else if (n is ruleList) return visit((ruleList) n);
        else if (n is rule) return visit((rule) n);
        else if (n is symWithAttrsList) return visit((symWithAttrsList) n);
        else if (n is symAttrs) return visit((symAttrs) n);
        else if (n is action_segment) return visit((action_segment) n);
        else if (n is start_symbolList) return visit((start_symbolList) n);
        else if (n is terminalList) return visit((terminalList) n);
        else if (n is terminal) return visit((terminal) n);
        else if (n is optTerminalAlias) return visit((optTerminalAlias) n);
        else if (n is type_declarationsList) return visit((type_declarationsList) n);
        else if (n is type_declarations) return visit((type_declarations) n);
        else if (n is symbol_pairList) return visit((symbol_pairList) n);
        else if (n is symbol_pair) return visit((symbol_pair) n);
        else if (n is recover_symbol) return visit((recover_symbol) n);
        else if (n is END_KEY_OPT) return visit((END_KEY_OPT) n);
        else if (n is option_value0) return visit((option_value0) n);
        else if (n is option_value1) return visit((option_value1) n);
        else if (n is aliasSpec0) return visit((aliasSpec0) n);
        else if (n is aliasSpec1) return visit((aliasSpec1) n);
        else if (n is aliasSpec2) return visit((aliasSpec2) n);
        else if (n is aliasSpec3) return visit((aliasSpec3) n);
        else if (n is aliasSpec4) return visit((aliasSpec4) n);
        else if (n is aliasSpec5) return visit((aliasSpec5) n);
        else if (n is alias_rhs0) return visit((alias_rhs0) n);
        else if (n is alias_rhs1) return visit((alias_rhs1) n);
        else if (n is alias_rhs2) return visit((alias_rhs2) n);
        else if (n is alias_rhs3) return visit((alias_rhs3) n);
        else if (n is alias_rhs4) return visit((alias_rhs4) n);
        else if (n is alias_rhs5) return visit((alias_rhs5) n);
        else if (n is alias_rhs6) return visit((alias_rhs6) n);
        else if (n is macro_name_symbol0) return visit((macro_name_symbol0) n);
        else if (n is macro_name_symbol1) return visit((macro_name_symbol1) n);
        else if (n is drop_command0) return visit((drop_command0) n);
        else if (n is drop_command1) return visit((drop_command1) n);
        else if (n is name0) return visit((name0) n);
        else if (n is name1) return visit((name1) n);
        else if (n is name2) return visit((name2) n);
        else if (n is name3) return visit((name3) n);
        else if (n is name4) return visit((name4) n);
        else if (n is name5) return visit((name5) n);
        else if (n is produces0) return visit((produces0) n);
        else if (n is produces1) return visit((produces1) n);
        else if (n is produces2) return visit((produces2) n);
        else if (n is produces3) return visit((produces3) n);
        else if (n is symWithAttrs0) return visit((symWithAttrs0) n);
        else if (n is symWithAttrs1) return visit((symWithAttrs1) n);
        else if (n is start_symbol0) return visit((start_symbol0) n);
        else if (n is start_symbol1) return visit((start_symbol1) n);
        else if (n is terminal_symbol0) return visit((terminal_symbol0) n);
        else if (n is terminal_symbol1) return visit((terminal_symbol1) n);
        throw new System.NotSupportedException("visit(" + n.GetType().ToString() + ")");
    }
    public object visit(ASTNode n, object o)
    {
        if (n is ASTNodeToken) return visit((ASTNodeToken) n, o);
        else if (n is LPG) return visit((LPG) n, o);
        else if (n is LPG_itemList) return visit((LPG_itemList) n, o);
        else if (n is AliasSeg) return visit((AliasSeg) n, o);
        else if (n is AstSeg) return visit((AstSeg) n, o);
        else if (n is DefineSeg) return visit((DefineSeg) n, o);
        else if (n is EofSeg) return visit((EofSeg) n, o);
        else if (n is EolSeg) return visit((EolSeg) n, o);
        else if (n is ErrorSeg) return visit((ErrorSeg) n, o);
        else if (n is ExportSeg) return visit((ExportSeg) n, o);
        else if (n is GlobalsSeg) return visit((GlobalsSeg) n, o);
        else if (n is HeadersSeg) return visit((HeadersSeg) n, o);
        else if (n is IdentifierSeg) return visit((IdentifierSeg) n, o);
        else if (n is ImportSeg) return visit((ImportSeg) n, o);
        else if (n is IncludeSeg) return visit((IncludeSeg) n, o);
        else if (n is KeywordsSeg) return visit((KeywordsSeg) n, o);
        else if (n is NamesSeg) return visit((NamesSeg) n, o);
        else if (n is NoticeSeg) return visit((NoticeSeg) n, o);
        else if (n is RulesSeg) return visit((RulesSeg) n, o);
        else if (n is SoftKeywordsSeg) return visit((SoftKeywordsSeg) n, o);
        else if (n is StartSeg) return visit((StartSeg) n, o);
        else if (n is TerminalsSeg) return visit((TerminalsSeg) n, o);
        else if (n is TrailersSeg) return visit((TrailersSeg) n, o);
        else if (n is TypesSeg) return visit((TypesSeg) n, o);
        else if (n is RecoverSeg) return visit((RecoverSeg) n, o);
        else if (n is PredecessorSeg) return visit((PredecessorSeg) n, o);
        else if (n is option_specList) return visit((option_specList) n, o);
        else if (n is option_spec) return visit((option_spec) n, o);
        else if (n is optionList) return visit((optionList) n, o);
        else if (n is option) return visit((option) n, o);
        else if (n is SYMBOLList) return visit((SYMBOLList) n, o);
        else if (n is aliasSpecList) return visit((aliasSpecList) n, o);
        else if (n is alias_lhs_macro_name) return visit((alias_lhs_macro_name) n, o);
        else if (n is defineSpecList) return visit((defineSpecList) n, o);
        else if (n is defineSpec) return visit((defineSpec) n, o);
        else if (n is macro_segment) return visit((macro_segment) n, o);
        else if (n is terminal_symbolList) return visit((terminal_symbolList) n, o);
        else if (n is action_segmentList) return visit((action_segmentList) n, o);
        else if (n is import_segment) return visit((import_segment) n, o);
        else if (n is drop_commandList) return visit((drop_commandList) n, o);
        else if (n is drop_ruleList) return visit((drop_ruleList) n, o);
        else if (n is drop_rule) return visit((drop_rule) n, o);
        else if (n is optMacroName) return visit((optMacroName) n, o);
        else if (n is include_segment) return visit((include_segment) n, o);
        else if (n is keywordSpecList) return visit((keywordSpecList) n, o);
        else if (n is keywordSpec) return visit((keywordSpec) n, o);
        else if (n is nameSpecList) return visit((nameSpecList) n, o);
        else if (n is nameSpec) return visit((nameSpec) n, o);
        else if (n is rules_segment) return visit((rules_segment) n, o);
        else if (n is nonTermList) return visit((nonTermList) n, o);
        else if (n is nonTerm) return visit((nonTerm) n, o);
        else if (n is RuleName) return visit((RuleName) n, o);
        else if (n is ruleList) return visit((ruleList) n, o);
        else if (n is rule) return visit((rule) n, o);
        else if (n is symWithAttrsList) return visit((symWithAttrsList) n, o);
        else if (n is symAttrs) return visit((symAttrs) n, o);
        else if (n is action_segment) return visit((action_segment) n, o);
        else if (n is start_symbolList) return visit((start_symbolList) n, o);
        else if (n is terminalList) return visit((terminalList) n, o);
        else if (n is terminal) return visit((terminal) n, o);
        else if (n is optTerminalAlias) return visit((optTerminalAlias) n, o);
        else if (n is type_declarationsList) return visit((type_declarationsList) n, o);
        else if (n is type_declarations) return visit((type_declarations) n, o);
        else if (n is symbol_pairList) return visit((symbol_pairList) n, o);
        else if (n is symbol_pair) return visit((symbol_pair) n, o);
        else if (n is recover_symbol) return visit((recover_symbol) n, o);
        else if (n is END_KEY_OPT) return visit((END_KEY_OPT) n, o);
        else if (n is option_value0) return visit((option_value0) n, o);
        else if (n is option_value1) return visit((option_value1) n, o);
        else if (n is aliasSpec0) return visit((aliasSpec0) n, o);
        else if (n is aliasSpec1) return visit((aliasSpec1) n, o);
        else if (n is aliasSpec2) return visit((aliasSpec2) n, o);
        else if (n is aliasSpec3) return visit((aliasSpec3) n, o);
        else if (n is aliasSpec4) return visit((aliasSpec4) n, o);
        else if (n is aliasSpec5) return visit((aliasSpec5) n, o);
        else if (n is alias_rhs0) return visit((alias_rhs0) n, o);
        else if (n is alias_rhs1) return visit((alias_rhs1) n, o);
        else if (n is alias_rhs2) return visit((alias_rhs2) n, o);
        else if (n is alias_rhs3) return visit((alias_rhs3) n, o);
        else if (n is alias_rhs4) return visit((alias_rhs4) n, o);
        else if (n is alias_rhs5) return visit((alias_rhs5) n, o);
        else if (n is alias_rhs6) return visit((alias_rhs6) n, o);
        else if (n is macro_name_symbol0) return visit((macro_name_symbol0) n, o);
        else if (n is macro_name_symbol1) return visit((macro_name_symbol1) n, o);
        else if (n is drop_command0) return visit((drop_command0) n, o);
        else if (n is drop_command1) return visit((drop_command1) n, o);
        else if (n is name0) return visit((name0) n, o);
        else if (n is name1) return visit((name1) n, o);
        else if (n is name2) return visit((name2) n, o);
        else if (n is name3) return visit((name3) n, o);
        else if (n is name4) return visit((name4) n, o);
        else if (n is name5) return visit((name5) n, o);
        else if (n is produces0) return visit((produces0) n, o);
        else if (n is produces1) return visit((produces1) n, o);
        else if (n is produces2) return visit((produces2) n, o);
        else if (n is produces3) return visit((produces3) n, o);
        else if (n is symWithAttrs0) return visit((symWithAttrs0) n, o);
        else if (n is symWithAttrs1) return visit((symWithAttrs1) n, o);
        else if (n is start_symbol0) return visit((start_symbol0) n, o);
        else if (n is start_symbol1) return visit((start_symbol1) n, o);
        else if (n is terminal_symbol0) return visit((terminal_symbol0) n, o);
        else if (n is terminal_symbol1) return visit((terminal_symbol1) n, o);
        else throw new System.NotSupportedException("visit(" + n.GetType().ToString() + ")");
    }
}
}


namespace LpgExample.Ast
{

public interface ResultVisitor
{
    object visit(ASTNodeToken n);
    object visit(LPG n);
    object visit(LPG_itemList n);
    object visit(AliasSeg n);
    object visit(AstSeg n);
    object visit(DefineSeg n);
    object visit(EofSeg n);
    object visit(EolSeg n);
    object visit(ErrorSeg n);
    object visit(ExportSeg n);
    object visit(GlobalsSeg n);
    object visit(HeadersSeg n);
    object visit(IdentifierSeg n);
    object visit(ImportSeg n);
    object visit(IncludeSeg n);
    object visit(KeywordsSeg n);
    object visit(NamesSeg n);
    object visit(NoticeSeg n);
    object visit(RulesSeg n);
    object visit(SoftKeywordsSeg n);
    object visit(StartSeg n);
    object visit(TerminalsSeg n);
    object visit(TrailersSeg n);
    object visit(TypesSeg n);
    object visit(RecoverSeg n);
    object visit(PredecessorSeg n);
    object visit(option_specList n);
    object visit(option_spec n);
    object visit(optionList n);
    object visit(option n);
    object visit(SYMBOLList n);
    object visit(aliasSpecList n);
    object visit(alias_lhs_macro_name n);
    object visit(defineSpecList n);
    object visit(defineSpec n);
    object visit(macro_segment n);
    object visit(terminal_symbolList n);
    object visit(action_segmentList n);
    object visit(import_segment n);
    object visit(drop_commandList n);
    object visit(drop_ruleList n);
    object visit(drop_rule n);
    object visit(optMacroName n);
    object visit(include_segment n);
    object visit(keywordSpecList n);
    object visit(keywordSpec n);
    object visit(nameSpecList n);
    object visit(nameSpec n);
    object visit(rules_segment n);
    object visit(nonTermList n);
    object visit(nonTerm n);
    object visit(RuleName n);
    object visit(ruleList n);
    object visit(rule n);
    object visit(symWithAttrsList n);
    object visit(symAttrs n);
    object visit(action_segment n);
    object visit(start_symbolList n);
    object visit(terminalList n);
    object visit(terminal n);
    object visit(optTerminalAlias n);
    object visit(type_declarationsList n);
    object visit(type_declarations n);
    object visit(symbol_pairList n);
    object visit(symbol_pair n);
    object visit(recover_symbol n);
    object visit(END_KEY_OPT n);
    object visit(option_value0 n);
    object visit(option_value1 n);
    object visit(aliasSpec0 n);
    object visit(aliasSpec1 n);
    object visit(aliasSpec2 n);
    object visit(aliasSpec3 n);
    object visit(aliasSpec4 n);
    object visit(aliasSpec5 n);
    object visit(alias_rhs0 n);
    object visit(alias_rhs1 n);
    object visit(alias_rhs2 n);
    object visit(alias_rhs3 n);
    object visit(alias_rhs4 n);
    object visit(alias_rhs5 n);
    object visit(alias_rhs6 n);
    object visit(macro_name_symbol0 n);
    object visit(macro_name_symbol1 n);
    object visit(drop_command0 n);
    object visit(drop_command1 n);
    object visit(name0 n);
    object visit(name1 n);
    object visit(name2 n);
    object visit(name3 n);
    object visit(name4 n);
    object visit(name5 n);
    object visit(produces0 n);
    object visit(produces1 n);
    object visit(produces2 n);
    object visit(produces3 n);
    object visit(symWithAttrs0 n);
    object visit(symWithAttrs1 n);
    object visit(start_symbol0 n);
    object visit(start_symbol1 n);
    object visit(terminal_symbol0 n);
    object visit(terminal_symbol1 n);

    object visit(ASTNode n);
}
}


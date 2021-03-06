
////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2007 IBM Corporation.
// All rights reserved. This program and the accompanying materials
// are made available under the terms of the Eclipse Public License v1.0
// which accompanies this distribution, and is available at
// http://www.eclipse.org/legal/epl-v10.html
//
//Contributors:
//    Philippe Charles (pcharles@us.ibm.com) - initial API and implementation

////////////////////////////////////////////////////////////////////////////////

namespace LpgExample
{


    //#line 123 "LexerTemplateF.gi

using LPG2.Runtime;
using System;

    //#line 7 "LPGLexer.gi



    //#line 130 "LexerTemplateF.gi

public class LPGLexer : object , RuleAction
{
    private LPGLexerLpgLexStream lexStream;
    
    private static ParseTable prs = new LPGLexerprs();
    public ParseTable getParseTable() { return prs; }

    private LexParser lexParser = new LexParser();
    public LexParser getParser() { return lexParser; }

    public int getToken(int i) { return lexParser.getToken(i); }
    public int getRhsFirstTokenIndex(int i) { return lexParser.getFirstToken(i); }
    public int getRhsLastTokenIndex(int i) { return lexParser.getLastToken(i); }

    public int getLeftSpan() { return lexParser.getToken(1); }
    public int getRightSpan() { return lexParser.getLastToken(); }

    public void resetKeywordLexer()
    {
        if (kwLexer == null)
              this.kwLexer = new LPGKWLexer(lexStream.getInputChars(), LPGParsersym.TK_MACRO_NAME);
        else this.kwLexer.setInputChars(lexStream.getInputChars());
    }

    public void reset(string filename, int tab) 
    {
        lexStream = new LPGLexerLpgLexStream(filename, tab);
        lexParser.reset((ILexStream) lexStream, prs, (RuleAction) this);
        resetKeywordLexer();
    }

    public void reset(char[] input_chars, string filename)
    {
        reset(input_chars, filename, 1);
    }
    
    public void reset(char[] input_chars, string filename, int tab)
    {
        lexStream = new LPGLexerLpgLexStream(input_chars, filename, tab);
        lexParser.reset((ILexStream) lexStream, prs, (RuleAction) this);
        resetKeywordLexer();
    }
    
    public LPGLexer(string filename, int tab)  
    {
        reset(filename, tab);
    }

    public LPGLexer(char[] input_chars, string filename, int tab)
    {
        reset(input_chars, filename, tab);
    }

    public LPGLexer(char[] input_chars, string filename)
    {
        reset(input_chars, filename, 1);
    }

    public LPGLexer() {}

    public ILexStream getILexStream() { return lexStream; }

    /**
     * @deprecated replaced by {@link #getILexStream()}
     */
    public ILexStream getLexStream() { return lexStream; }

    private void initializeLexer(IPrsStream prsStream, int start_offset, int end_offset)
    {
        if (lexStream.getInputChars() == null)
            throw new NullReferenceException("LexStream was not initialized");
        lexStream.setPrsStream(prsStream);
        prsStream.makeToken(start_offset, end_offset, 0); // Token list must start with a bad token
    }

    private void addEOF(IPrsStream prsStream, int end_offset)
    {
        prsStream.makeToken(end_offset, end_offset, LPGParsersym.TK_EOF_TOKEN); // and end with the end of file token
        prsStream.setStreamLength(prsStream.getSize());
    }

    public void lexer(IPrsStream prsStream)
    {
        lexer(null, prsStream);
    }
    
    public void lexer(Monitor monitor, IPrsStream prsStream)
    {
        initializeLexer(prsStream, 0, -1);
        lexParser.parseCharacters(monitor);  // Lex the input characters
        addEOF(prsStream, lexStream.getStreamIndex());
    }

    public void lexer(IPrsStream prsStream, int start_offset, int end_offset)
    {
        lexer(null, prsStream, start_offset, end_offset);
    }
    
    public void lexer(Monitor monitor, IPrsStream prsStream, int start_offset, int end_offset)
    {
        if (start_offset <= 1)
             initializeLexer(prsStream, 0, -1);
        else initializeLexer(prsStream, start_offset - 1, start_offset - 1);

        lexParser.parseCharacters(monitor, start_offset, end_offset);

        addEOF(prsStream, (end_offset >= lexStream.getStreamIndex() ? lexStream.getStreamIndex() : end_offset + 1));
    }
    
   

    /**
     * If a parse stream was not passed to this Lexical analyser then we
     * simply report a lexical error. Otherwise, we produce a bad token.
     */
    public void reportLexicalError(int startLoc, int endLoc) {
        IPrsStream prs_stream = lexStream.getIPrsStream();
        if (prs_stream == null)
            lexStream.reportLexicalError(startLoc, endLoc);
        else {
            //
            // Remove any token that may have been processed that fall in the
            // range of the lexical error... then add one error token that spans
            // the error range.
            //
            for (int i = prs_stream.getSize() - 1; i > 0; i--) {
                if (prs_stream.getStartOffset(i) >= startLoc)
                     prs_stream.removeLastToken();
                else break;
            }
            prs_stream.makeToken(startLoc, endLoc, 0); // add an error token to the prsStream
        }        
    }

    //#line 12 "LPGLexer.gi

 
    //#line 5 "LexerBasicMapF.gi

    //
    // The Lexer contains an array of characters as the input stream to be parsed.
    // There are methods to retrieve and classify characters.
    // The lexparser "token" is implemented simply as the index of the next character in the array.
    // The Lexer : the abstract class LpgLexStream with an implementation of the abstract
    // method getKind.  The template defines the Lexer class and the lexer() method.
    // A driver creates the action class, "Lexer", passing an Option object to the constructor.
    //
    LPGKWLexer kwLexer;
   public  bool printTokens=false;
    private const int ECLIPSE_TAB_VALUE = 4;

    public int [] getKeywordKinds() { return kwLexer.getKeywordKinds(); }

    public LPGLexer(string filename) : this(filename, ECLIPSE_TAB_VALUE)
    {
       
        this.kwLexer = new LPGKWLexer(lexStream.getInputChars(), LPGParsersym.TK_MACRO_NAME);
    }

    /**
     * @deprecated function replaced by {@link #reset(char [] content, string filename)}
     */
    public void initialize(char [] content, string filename)
    {
        reset(content, filename);
    }
    
     void makeToken(int left_token, int right_token, int kind)
    {
        lexStream.makeToken(left_token, right_token, kind);
    }
    
     void makeToken(int kind)
    {
        int startOffset = getLeftSpan(),
            endOffset = getRightSpan();
        lexStream.makeToken(startOffset, endOffset, kind);
        if (printTokens) printValue(startOffset, endOffset);
    }

     void makeComment(int kind)
    {
        int startOffset = getLeftSpan(),
            endOffset = getRightSpan();
        lexStream.getIPrsStream().makeAdjunct(startOffset, endOffset, kind);
    }

     void skipToken()
    {
        if (printTokens) printValue(getLeftSpan(), getRightSpan());
    }
    
     void checkForKeyWord()
    {
        int startOffset = getLeftSpan(),
            endOffset = getRightSpan(),
            kwKind = kwLexer.lexer(startOffset, endOffset);
        lexStream.makeToken(startOffset, endOffset, kwKind);
        if (printTokens) printValue(startOffset, endOffset);
    }
    
    //
    // This flavor of checkForKeyWord is necessary when the default kind
    // (which is returned when the keyword filter doesn't match) is something
    // other than _IDENTIFIER.
    //
     void checkForKeyWord(int defaultKind)
    {
        int startOffset = getLeftSpan(),
            endOffset = getRightSpan(),
            kwKind = kwLexer.lexer(startOffset, endOffset);
        if (kwKind == LPGParsersym.TK_MACRO_NAME)
            kwKind = defaultKind;
        lexStream.makeToken(startOffset, endOffset, kwKind);
        if (printTokens) printValue(startOffset, endOffset);
    }
    
     void printValue(int startOffset, int endOffset)
    {
        string s = new string(lexStream.getInputChars(), startOffset, endOffset - startOffset + 1);
         Console.Out.Write(s);
    }

    //
    //
    //
     class LPGLexerLpgLexStream : LpgLexStream
    {
    public static int[] tokenKind =
    {
        LPGLexersym.Char_CtlCharNotWS,    // 000    0x00
        LPGLexersym.Char_CtlCharNotWS,    // 001    0x01
        LPGLexersym.Char_CtlCharNotWS,    // 002    0x02
        LPGLexersym.Char_CtlCharNotWS,    // 003    0x03
        LPGLexersym.Char_CtlCharNotWS,    // 004    0x04
        LPGLexersym.Char_CtlCharNotWS,    // 005    0x05
        LPGLexersym.Char_CtlCharNotWS,    // 006    0x06
        LPGLexersym.Char_CtlCharNotWS,    // 007    0x07
        LPGLexersym.Char_CtlCharNotWS,    // 008    0x08
        LPGLexersym.Char_HT,              // 009    0x09
        LPGLexersym.Char_LF,              // 010    0x0A
        LPGLexersym.Char_CtlCharNotWS,    // 011    0x0B
        LPGLexersym.Char_FF,              // 012    0x0C
        LPGLexersym.Char_CR,              // 013    0x0D
        LPGLexersym.Char_CtlCharNotWS,    // 014    0x0E
        LPGLexersym.Char_CtlCharNotWS,    // 015    0x0F
        LPGLexersym.Char_CtlCharNotWS,    // 016    0x10
        LPGLexersym.Char_CtlCharNotWS,    // 017    0x11
        LPGLexersym.Char_CtlCharNotWS,    // 018    0x12
        LPGLexersym.Char_CtlCharNotWS,    // 019    0x13
        LPGLexersym.Char_CtlCharNotWS,    // 020    0x14
        LPGLexersym.Char_CtlCharNotWS,    // 021    0x15
        LPGLexersym.Char_CtlCharNotWS,    // 022    0x16
        LPGLexersym.Char_CtlCharNotWS,    // 023    0x17
        LPGLexersym.Char_CtlCharNotWS,    // 024    0x18
        LPGLexersym.Char_CtlCharNotWS,    // 025    0x19
        LPGLexersym.Char_CtlCharNotWS,    // 026    0x1A
        LPGLexersym.Char_CtlCharNotWS,    // 027    0x1B
        LPGLexersym.Char_CtlCharNotWS,    // 028    0x1C
        LPGLexersym.Char_CtlCharNotWS,    // 029    0x1D
        LPGLexersym.Char_CtlCharNotWS,    // 030    0x1E
        LPGLexersym.Char_CtlCharNotWS,    // 031    0x1F
        LPGLexersym.Char_Space,           // 032    0x20
        LPGLexersym.Char_Exclamation,     // 033    0x21
        LPGLexersym.Char_DoubleQuote,     // 034    0x22
        LPGLexersym.Char_Sharp,           // 035    0x23
        LPGLexersym.Char_DollarSign,      // 036    0x24
        LPGLexersym.Char_Percent,         // 037    0x25
        LPGLexersym.Char_Ampersand,       // 038    0x26
        LPGLexersym.Char_SingleQuote,     // 039    0x27
        LPGLexersym.Char_LeftParen,       // 040    0x28
        LPGLexersym.Char_RightParen,      // 041    0x29
        LPGLexersym.Char_Star,            // 042    0x2A
        LPGLexersym.Char_Plus,            // 043    0x2B
        LPGLexersym.Char_Comma,           // 044    0x2C
        LPGLexersym.Char_Minus,           // 045    0x2D
        LPGLexersym.Char_Dot,             // 046    0x2E
        LPGLexersym.Char_Slash,           // 047    0x2F
        LPGLexersym.Char_0,               // 048    0x30
        LPGLexersym.Char_1,               // 049    0x31
        LPGLexersym.Char_2,               // 050    0x32
        LPGLexersym.Char_3,               // 051    0x33
        LPGLexersym.Char_4,               // 052    0x34
        LPGLexersym.Char_5,               // 053    0x35
        LPGLexersym.Char_6,               // 054    0x36
        LPGLexersym.Char_7,               // 055    0x37
        LPGLexersym.Char_8,               // 056    0x38
        LPGLexersym.Char_9,               // 057    0x39
        LPGLexersym.Char_Colon,           // 058    0x3A
        LPGLexersym.Char_SemiColon,       // 059    0x3B
        LPGLexersym.Char_LessThan,        // 060    0x3C
        LPGLexersym.Char_Equal,           // 061    0x3D
        LPGLexersym.Char_GreaterThan,     // 062    0x3E
        LPGLexersym.Char_QuestionMark,    // 063    0x3F
        LPGLexersym.Char_AtSign,          // 064    0x40
        LPGLexersym.Char_A,               // 065    0x41
        LPGLexersym.Char_B,               // 066    0x42
        LPGLexersym.Char_C,               // 067    0x43
        LPGLexersym.Char_D,               // 068    0x44
        LPGLexersym.Char_E,               // 069    0x45
        LPGLexersym.Char_F,               // 070    0x46
        LPGLexersym.Char_G,               // 071    0x47
        LPGLexersym.Char_H,               // 072    0x48
        LPGLexersym.Char_I,               // 073    0x49
        LPGLexersym.Char_J,               // 074    0x4A
        LPGLexersym.Char_K,               // 075    0x4B
        LPGLexersym.Char_L,               // 076    0x4C
        LPGLexersym.Char_M,               // 077    0x4D
        LPGLexersym.Char_N,               // 078    0x4E
        LPGLexersym.Char_O,               // 079    0x4F
        LPGLexersym.Char_P,               // 080    0x50
        LPGLexersym.Char_Q,               // 081    0x51
        LPGLexersym.Char_R,               // 082    0x52
        LPGLexersym.Char_S,               // 083    0x53
        LPGLexersym.Char_T,               // 084    0x54
        LPGLexersym.Char_U,               // 085    0x55
        LPGLexersym.Char_V,               // 086    0x56
        LPGLexersym.Char_W,               // 087    0x57
        LPGLexersym.Char_X,               // 088    0x58
        LPGLexersym.Char_Y,               // 089    0x59
        LPGLexersym.Char_Z,               // 090    0x5A
        LPGLexersym.Char_LeftBracket,     // 091    0x5B
        LPGLexersym.Char_BackSlash,       // 092    0x5C
        LPGLexersym.Char_RightBracket,    // 093    0x5D
        LPGLexersym.Char_Caret,           // 094    0x5E
        LPGLexersym.Char__,               // 095    0x5F
        LPGLexersym.Char_BackQuote,       // 096    0x60
        LPGLexersym.Char_a,               // 097    0x61
        LPGLexersym.Char_b,               // 098    0x62
        LPGLexersym.Char_c,               // 099    0x63
        LPGLexersym.Char_d,               // 100    0x64
        LPGLexersym.Char_e,               // 101    0x65
        LPGLexersym.Char_f,               // 102    0x66
        LPGLexersym.Char_g,               // 103    0x67
        LPGLexersym.Char_h,               // 104    0x68
        LPGLexersym.Char_i,               // 105    0x69
        LPGLexersym.Char_j,               // 106    0x6A
        LPGLexersym.Char_k,               // 107    0x6B
        LPGLexersym.Char_l,               // 108    0x6C
        LPGLexersym.Char_m,               // 109    0x6D
        LPGLexersym.Char_n,               // 110    0x6E
        LPGLexersym.Char_o,               // 111    0x6F
        LPGLexersym.Char_p,               // 112    0x70
        LPGLexersym.Char_q,               // 113    0x71
        LPGLexersym.Char_r,               // 114    0x72
        LPGLexersym.Char_s,               // 115    0x73
        LPGLexersym.Char_t,               // 116    0x74
        LPGLexersym.Char_u,               // 117    0x75
        LPGLexersym.Char_v,               // 118    0x76
        LPGLexersym.Char_w,               // 119    0x77
        LPGLexersym.Char_x,               // 120    0x78
        LPGLexersym.Char_y,               // 121    0x79
        LPGLexersym.Char_z,               // 122    0x7A
        LPGLexersym.Char_LeftBrace,       // 123    0x7B
        LPGLexersym.Char_VerticalBar,     // 124    0x7C
        LPGLexersym.Char_RightBrace,      // 125    0x7D
        LPGLexersym.Char_Tilde,           // 126    0x7E

        LPGLexersym.Char_AfterASCII,      // for all chars in range 128..65534
        LPGLexersym.Char_EOF              // for '\uffff' or 65535 
    };
            
    public  override int getKind(int i)  // Classify character at ith location
    {
        int c = (i >= getStreamLength() ? '\uffff' : getCharValue(i));
        return (c < 128 // ASCII Character
                  ? tokenKind[c]
                  : c == '\uffff'
                       ? LPGLexersym.Char_EOF
                       : LPGLexersym.Char_AfterASCII);
    }

    public override string[] orderedExportedSymbols() { return LPGParsersym.orderedTerminalSymbols; }

    public LPGLexerLpgLexStream(string filename, int tab) :base(filename, tab)
    {
        
    }

    public LPGLexerLpgLexStream(char[] input_chars, string filename, int tab): base(input_chars, filename, tab)
    {
       
    }

    public LPGLexerLpgLexStream(char[] input_chars, string filename): base(input_chars, filename, 1)
    {
       
    }
    }

    //#line 268 "LexerTemplateF.gi

    public void ruleAction(int ruleNumber)
    {
        switch(ruleNumber)
        {

            //
            // Rule 1:  Token ::= white
            //
            case 1: { 
             skipToken();             break;
            }

            //
            // Rule 2:  Token ::= singleLineComment
            //
            case 2: { 
             makeComment(LPGParsersym.TK_SINGLE_LINE_COMMENT);             break;
            }

            //
            // Rule 4:  Token ::= MacroSymbol
            //
            case 4: { 
             checkForKeyWord();            break;
            }

            //
            // Rule 5:  Token ::= Symbol
            //
            case 5: { 
             checkForKeyWord(LPGParsersym.TK_SYMBOL);            break;
            }

            //
            // Rule 6:  Token ::= Block
            //
            case 6: { 
             makeToken(LPGParsersym.TK_BLOCK);            break;
            }

            //
            // Rule 7:  Token ::= Equivalence
            //
            case 7: { 
             makeToken(LPGParsersym.TK_EQUIVALENCE);            break;
            }

            //
            // Rule 8:  Token ::= Equivalence ?
            //
            case 8: { 
             makeToken(LPGParsersym.TK_PRIORITY_EQUIVALENCE);            break;
            }

            //
            // Rule 9:  Token ::= #
            //
            case 9: { 
             makeToken(LPGParsersym.TK_SHARP);            break;
            }

            //
            // Rule 10:  Token ::= Arrow
            //
            case 10: { 
             makeToken(LPGParsersym.TK_ARROW);            break;
            }

            //
            // Rule 11:  Token ::= Arrow ?
            //
            case 11: { 
             makeToken(LPGParsersym.TK_PRIORITY_ARROW);            break;
            }

            //
            // Rule 12:  Token ::= |
            //
            case 12: { 
             makeToken(LPGParsersym.TK_OR_MARKER);            break;
            }

            //
            // Rule 13:  Token ::= [
            //
            case 13: { 
             makeToken(LPGParsersym.TK_LEFT_BRACKET);            break;
            }

            //
            // Rule 14:  Token ::= ]
            //
            case 14: { 
             makeToken(LPGParsersym.TK_RIGHT_BRACKET);            break;
            }

            //
            // Rule 859:  OptionLines ::= OptionLineList
            //
            case 859: { 
            
                  // What ever needs to happen after the options have been 
                  // scanned must happen here.
                    break;
            }
      
            //
            // Rule 868:  options ::= % oO pP tT iI oO nN sS
            //
            case 868: { 
            
                  makeToken(getLeftSpan(), getRightSpan(), LPGParsersym.TK_OPTIONS_KEY);
                    break;
            }
      
            //
            // Rule 869:  OptionComment ::= singleLineComment
            //
            case 869: { 
             makeComment(LPGParsersym.TK_SINGLE_LINE_COMMENT);             break;
            }

            //
            // Rule 893:  separator ::= ,$comma
            //
            case 893: { 
              makeToken(getLeftSpan(), getRightSpan(), LPGParsersym.TK_COMMA);             break;
            }

            //
            // Rule 894:  option ::= action_block$ab optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite ,$comma1 optionWhite block_begin$bb optionWhite ,$comma2 optionWhite block_end$be optionWhite )$rp optionWhite
            //
            case 894: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(15), getRhsLastTokenIndex(15), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(17), getRhsLastTokenIndex(17), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 897:  option ::= ast_block$ab optionWhite =$eq optionWhite ($lp optionWhite block_begin$bb optionWhite ,$comma2 optionWhite block_end$be optionWhite )$rp optionWhite
            //
            case 897: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);

                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 902:  option ::= ast_directory$ad optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 902: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 905:  option ::= ast_type$at optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 905: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 908:  option ::= attributes$a optionWhite
            //
            case 908: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 909:  option ::= no attributes$a optionWhite
            //
            case 909: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 911:  option ::= automatic_ast$a optionWhite
            //
            case 911: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 912:  option ::= no automatic_ast$a optionWhite
            //
            case 912: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 913:  option ::= automatic_ast$aa optionWhite =$eq optionWhite automatic_ast_value$val optionWhite
            //
            case 913: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 917:  option ::= backtrack$b optionWhite
            //
            case 917: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 918:  option ::= no backtrack$b optionWhite
            //
            case 918: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 920:  option ::= byte$b optionWhite
            //
            case 920: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 921:  option ::= no byte$b optionWhite
            //
            case 921: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 923:  option ::= conflicts$c optionWhite
            //
            case 923: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 924:  option ::= no conflicts$c optionWhite
            //
            case 924: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 926:  option ::= dat_directory$dd optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 926: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 929:  option ::= dat_file$df optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 929: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 931:  option ::= dcl_file$df optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 931: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 933:  option ::= def_file$df optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 933: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 935:  option ::= debug$d optionWhite
            //
            case 935: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 936:  option ::= no debug$d optionWhite
            //
            case 936: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 938:  option ::= edit$e optionWhite
            //
            case 938: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 939:  option ::= no edit$e optionWhite
            //
            case 939: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 941:  option ::= error_maps$e optionWhite
            //
            case 941: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 942:  option ::= no error_maps$e optionWhite
            //
            case 942: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 945:  option ::= escape$e optionWhite =$eq optionWhite anyNonWhiteChar$val optionWhite
            //
            case 945: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                
                    break;
            }
      
            //
            // Rule 947:  option ::= export_terminals$et optionWhite =$eq optionWhite filename$fn optionWhite
            //
            case 947: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 948:  option ::= export_terminals$et optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite )$rp optionWhite
            //
            case 948: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 949:  option ::= export_terminals$et optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite ,$comma optionWhite export_prefix$ep optionWhite )$rp optionWhite
            //
            case 949: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 950:  option ::= export_terminals$et optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite ,$comma1 optionWhite export_prefix$ep optionWhite ,$comma2 optionWhite export_suffix$es optionWhite )$rp optionWhite
            //
            case 950: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(15), getRhsLastTokenIndex(15), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(17), getRhsLastTokenIndex(17), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 955:  option ::= extends_parsetable$e optionWhite
            //
            case 955: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 956:  option ::= no extends_parsetable$e optionWhite
            //
            case 956: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 957:  option ::= extends_parsetable$ep optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 957: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 960:  option ::= factory$f optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 960: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 962:  option ::= file_prefix$fp optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 962: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 965:  option ::= filter$f optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 965: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 967:  option ::= first$f optionWhite
            //
            case 967: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 968:  option ::= no first$f optionWhite
            //
            case 968: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 970:  option ::= follow$f optionWhite
            //
            case 970: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 971:  option ::= no follow$f optionWhite
            //
            case 971: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 973:  option ::= goto_default$g optionWhite
            //
            case 973: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 974:  option ::= no goto_default$g optionWhite
            //
            case 974: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 977:  option ::= headers$h optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite ,$comma1 optionWhite block_begin$bb optionWhite ,$comma2 optionWhite block_end$be optionWhite )$rp optionWhite
            //
            case 977: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(15), getRhsLastTokenIndex(15), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(17), getRhsLastTokenIndex(17), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 979:  option ::= imp_file$if optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 979: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 982:  option ::= import_terminals$it optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 982: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 985:  option ::= include_directory$id optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 985: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 989:  option ::= lalr_level$l optionWhite
            //
            case 989: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 990:  option ::= no lalr_level$l optionWhite
            //
            case 990: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 991:  option ::= lalr_level$l optionWhite =$eq optionWhite number$val optionWhite
            //
            case 991: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 996:  option ::= list$l optionWhite
            //
            case 996: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 997:  option ::= no list$l optionWhite
            //
            case 997: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 999:  option ::= margin$m optionWhite =$eq optionWhite number$val optionWhite
            //
            case 999: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1001:  option ::= max_cases$mc optionWhite =$eq optionWhite number$val optionWhite
            //
            case 1001: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1004:  option ::= names$n optionWhite
            //
            case 1004: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1005:  option ::= no names$n optionWhite
            //
            case 1005: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1006:  option ::= names$n optionWhite =$eq optionWhite names_value$val optionWhite
            //
            case 1006: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1011:  option ::= nt_check$n optionWhite
            //
            case 1011: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1012:  option ::= no nt_check$n optionWhite
            //
            case 1012: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1015:  option ::= or_marker$om optionWhite =$eq optionWhite anyNonWhiteChar$val optionWhite
            //
            case 1015: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1018:  option ::= out_directory$dd optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1018: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1021:  option ::= parent_saved$ps optionWhite
            //
            case 1021: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1022:  option ::= no parent_saved$ps optionWhite
            //
            case 1022: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1025:  option ::= package$p optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1025: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1027:  option ::= parsetable_interfaces$pi optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1027: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1031:  option ::= prefix$p optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1031: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1033:  option ::= priority$p optionWhite
            //
            case 1033: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1034:  option ::= no priority$p optionWhite
            //
            case 1034: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1036:  option ::= programming_language$pl optionWhite =$eq optionWhite programming_language_value$val optionWhite
            //
            case 1036: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1040:  option ::= prs_file$pf optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1040: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1043:  option ::= quiet$q optionWhite
            //
            case 1043: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1044:  option ::= no quiet$q optionWhite
            //
            case 1044: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1046:  option ::= read_reduce$r optionWhite
            //
            case 1046: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1047:  option ::= no read_reduce$r optionWhite
            //
            case 1047: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1050:  option ::= remap_terminals$r optionWhite
            //
            case 1050: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1051:  option ::= no remap_terminals$r optionWhite
            //
            case 1051: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            }

            //
            // Rule 1054:  option ::= scopes$s optionWhite
            //
            case 1054: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1055:  option ::= no scopes$s optionWhite
            //
            case 1055: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1057:  option ::= serialize$s optionWhite
            //
            case 1057: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1058:  option ::= no serialize$s optionWhite
            //
            case 1058: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1060:  option ::= shift_default$s optionWhite
            //
            case 1060: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1061:  option ::= no shift_default$s optionWhite
            //
            case 1061: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1064:  option ::= single_productions$s optionWhite
            //
            case 1064: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1065:  option ::= no single_productions$s optionWhite
            //
            case 1065: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1068:  option ::= slr$s optionWhite
            //
            case 1068: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1069:  option ::= no slr$s optionWhite
            //
            case 1069: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1071:  option ::= soft_keywords$s optionWhite
            //
            case 1071: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1072:  option ::= no soft_keywords$s optionWhite
            //
            case 1072: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1076:  option ::= states$s optionWhite
            //
            case 1076: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1077:  option ::= no states$s optionWhite
            //
            case 1077: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1079:  option ::= suffix$s optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1079: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1081:  option ::= sym_file$sf optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1081: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1084:  option ::= tab_file$tf optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1084: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1087:  option ::= template$t optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1087: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1089:  option ::= trailers$t optionWhite =$eq optionWhite ($lp optionWhite filename$fn optionWhite ,$comma1 optionWhite block_begin$bb optionWhite ,$comma2 optionWhite block_end$be optionWhite )$rp optionWhite
            //
            case 1089: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_LEFT_PAREN);
                  makeToken(getRhsFirstTokenIndex(7), getRhsLastTokenIndex(7), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(9), getRhsLastTokenIndex(9), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(11), getRhsLastTokenIndex(11), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(13), getRhsLastTokenIndex(13), LPGParsersym.TK_COMMA);
                  makeToken(getRhsFirstTokenIndex(15), getRhsLastTokenIndex(15), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(17), getRhsLastTokenIndex(17), LPGParsersym.TK_RIGHT_PAREN);
                    break;
            }
      
            //
            // Rule 1091:  option ::= table$t optionWhite
            //
            case 1091: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1092:  option ::= no table$t optionWhite
            //
            case 1092: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1093:  option ::= table$t optionWhite =$eq optionWhite programming_language_value$val optionWhite
            //
            case 1093: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1095:  option ::= trace$t optionWhite
            //
            case 1095: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1096:  option ::= no trace$t optionWhite
            //
            case 1096: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1097:  option ::= trace$t optionWhite =$eq optionWhite trace_value$val optionWhite
            //
            case 1097: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1102:  option ::= variables$v optionWhite
            //
            case 1102: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1103:  option ::= no variables$v optionWhite
            //
            case 1103: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1104:  option ::= variables$v optionWhite =$eq optionWhite variables_value$val optionWhite
            //
            case 1104: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1111:  option ::= verbose$v optionWhite
            //
            case 1111: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1112:  option ::= no verbose$v optionWhite
            //
            case 1112: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1114:  option ::= visitor$v optionWhite
            //
            case 1114: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1115:  option ::= no visitor$v optionWhite
            //
            case 1115: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1116:  option ::= visitor$v optionWhite =$eq optionWhite visitor_value$val optionWhite
            //
            case 1116: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1121:  option ::= visitor_type$vt optionWhite =$eq optionWhite Value$val optionWhite
            //
            case 1121: { 
            
                  makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);
                  makeToken(getRhsFirstTokenIndex(3), getRhsLastTokenIndex(3), LPGParsersym.TK_EQUAL);
                  makeToken(getRhsFirstTokenIndex(5), getRhsLastTokenIndex(5), LPGParsersym.TK_SYMBOL);
                    break;
            }
      
            //
            // Rule 1124:  option ::= warnings$w optionWhite
            //
            case 1124: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1125:  option ::= no warnings$w optionWhite
            //
            case 1125: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1127:  option ::= xreference$x optionWhite
            //
            case 1127: { 
              makeToken(getRhsFirstTokenIndex(1), getRhsLastTokenIndex(1), LPGParsersym.TK_SYMBOL);             break;
            } 

            //
            // Rule 1128:  option ::= no xreference$x optionWhite
            //
            case 1128: { 
              makeToken(getRhsFirstTokenIndex(2), getRhsLastTokenIndex(2), LPGParsersym.TK_SYMBOL);             break;
            } 

    //#line 272 "LexerTemplateF.gi

    
            default:
                break;
        }
        return;
    }
}
}

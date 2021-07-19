
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

public class LPGKWLexerprs : LPG2.Runtime.ParseTable, LPGKWLexersym {
    public const int ERROR_SYMBOL = 0;
    public  int getErrorSymbol() { return ERROR_SYMBOL; }

    public const int SCOPE_UBOUND = 0;
    public  int getScopeUbound() { return SCOPE_UBOUND; }

    public const int SCOPE_SIZE = 0;
    public  int getScopeSize() { return SCOPE_SIZE; }

    public const int MAX_NAME_LENGTH = 0;
    public  int getMaxNameLength() { return MAX_NAME_LENGTH; }

    public const int NUM_STATES = 145;
    public  int getNumStates() { return NUM_STATES; }

    public const int NT_OFFSET = 30;
    public  int getNtOffset() { return NT_OFFSET; }

    public const int LA_STATE_OFFSET = 208;
    public  int getLaStateOffset() { return LA_STATE_OFFSET; }

    public const int MAX_LA = 0;
    public  int getMaxLa() { return MAX_LA; }

    public const int NUM_RULES = 29;
    public  int getNumRules() { return NUM_RULES; }

    public const int NUM_NONTERMINALS = 3;
    public  int getNumNonterminals() { return NUM_NONTERMINALS; }

    public const int NUM_SYMBOLS = 33;
    public  int getNumSymbols() { return NUM_SYMBOLS; }

    public const int SEGMENT_SIZE = 8192;
    public  int getSegmentSize() { return SEGMENT_SIZE; }

    public const int START_STATE = 30;
    public  int getStartState() { return START_STATE; }

    public const int IDENTIFIER_SYMBOL = 0;
    public  int getIdentifier_SYMBOL() { return IDENTIFIER_SYMBOL; }

    public const int EOFT_SYMBOL = 27;
    public  int getEoftSymbol() { return EOFT_SYMBOL; }

    public const int EOLT_SYMBOL = 31;
    public  int getEoltSymbol() { return EOLT_SYMBOL; }

    public const int ACCEPT_ACTION = 178;
    public  int getAcceptAction() { return ACCEPT_ACTION; }

    public const int ERROR_ACTION = 179;
    public  int getErrorAction() { return ERROR_ACTION; }

    public const bool BACKTRACK = false;
    public  bool getBacktrack() { return BACKTRACK; }

    public   int getStartSymbol() { return lhs(0); }
    public   bool isValidForParser() { return LPGKWLexersym.isValidForParser; }


    public interface IsNullable {
        public static sbyte[] _isNullable = {0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0
        };
    };
    public static sbyte[] _isNullable = IsNullable._isNullable;
    public   bool isNullable(int index) { return _isNullable[index] != 0; }

    public interface ProsthesesIndex {
        public static sbyte[] _prosthesesIndex = {0,
            2,3,1
        };
    };
    public static sbyte[] _prosthesesIndex = ProsthesesIndex._prosthesesIndex;
    public   int prosthesesIndex(int index) { return _prosthesesIndex[index]; }

    public interface IsKeyword {
        public static sbyte[] _isKeyword = {0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0
        };
    };
    public static sbyte[] _isKeyword = IsKeyword._isKeyword;
    public   bool isKeyword(int index) { return _isKeyword[index] != 0; }

    public interface BaseCheck {
        public static sbyte[] _baseCheck = {0,
            6,4,7,24,10,12,6,4,6,4,
            4,7,8,8,11,7,8,9,13,6,
            7,10,8,6,6,9,6,1,1
        };
    };
    public static sbyte[] _baseCheck = BaseCheck._baseCheck;
    public   int baseCheck(int index) { return _baseCheck[index]; }
    public static sbyte [] _rhs = _baseCheck;
    public   int rhs(int index) { return _rhs[index]; }

    public interface BaseAction {
        public static short[] _baseAction = {
            1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,1,1,
            1,1,1,1,1,1,1,1,2,2,
            26,33,34,37,1,39,12,44,45,62,
            22,65,67,17,35,51,68,14,5,70,
            30,71,72,73,77,80,42,79,82,86,
            85,87,54,88,95,96,97,100,99,103,
            105,109,112,117,113,115,120,121,125,124,
            123,130,131,8,132,133,134,136,139,143,
            145,146,147,149,148,156,153,157,161,162,
            165,159,167,166,176,178,180,184,185,186,
            174,57,168,190,191,194,196,198,201,203,
            206,205,207,210,215,213,217,211,219,221,
            225,228,229,230,223,233,239,234,241,244,
            245,247,248,250,253,237,259,262,255,263,
            265,267,271,273,276,277,278,281,282,283,
            288,286,292,296,298,293,303,287,305,307,
            308,311,313,312,317,319,320,179,179
        };
    };
    public static short[] _baseAction = BaseAction._baseAction;
    public   int baseAction(int index) { return _baseAction[index]; }
    public static short [] _lhs = _baseAction;
    public   int lhs(int index) { return _lhs[index]; }

    public interface TermCheck {
        public static sbyte[] _termCheck = {0,
            0,1,2,3,0,5,6,0,8,9,
            10,0,1,0,3,11,0,10,18,3,
            4,0,22,23,13,0,10,14,12,0,
            9,10,3,12,0,1,0,3,0,1,
            6,0,26,0,0,20,21,4,4,5,
            0,8,2,0,16,14,0,7,2,3,
            7,0,1,27,0,1,0,0,15,0,
            0,0,0,7,7,5,0,8,0,0,
            8,0,1,12,0,0,0,0,4,11,
            3,15,13,8,0,0,0,11,0,0,
            4,2,0,9,0,0,11,5,0,1,
            6,0,0,15,0,4,0,1,6,0,
            0,1,0,0,0,6,12,3,5,0,
            0,0,0,0,4,0,7,4,0,4,
            9,19,0,5,0,0,0,0,0,17,
            2,6,0,11,8,0,0,2,0,7,
            0,0,6,2,0,0,0,0,24,5,
            4,4,25,0,14,0,18,0,3,0,
            1,16,5,0,0,0,13,3,3,0,
            0,8,2,0,1,0,1,0,0,10,
            0,1,0,1,0,0,0,10,3,0,
            0,5,0,9,0,6,0,3,0,7,
            0,5,0,13,0,1,6,0,0,0,
            3,3,0,0,16,13,0,8,0,1,
            0,9,2,0,0,2,0,0,15,0,
            0,2,0,7,0,19,12,10,0,7,
            2,0,0,1,0,0,0,6,2,5,
            0,17,0,1,4,0,0,0,2,4,
            0,0,0,3,3,0,0,0,11,7,
            3,0,0,2,9,0,1,0,0,2,
            14,9,0,1,0,1,0,0,2,2,
            0,0,0,2,4,3,0,1,0,0,
            0,2,0,5,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0,
            0,0,0,0,0,0,0,0,0,0
        };
    };
    public static sbyte[] _termCheck = TermCheck._termCheck;
    public   int termCheck(int index) { return _termCheck[index]; }

    public interface TermAction {
        public static short[] _termAction = {0,
            179,43,38,35,179,36,40,179,45,44,
            37,179,50,179,49,73,179,105,39,63,
            62,179,42,41,48,179,64,72,65,179,
            58,56,75,57,179,68,179,66,179,47,
            67,179,61,179,179,34,34,51,54,53,
            179,52,69,179,46,81,179,70,127,128,
            189,179,55,178,179,59,179,179,190,179,
            179,179,179,60,71,76,179,74,179,179,
            78,179,83,77,179,179,179,179,85,82,
            87,79,80,84,179,179,179,86,179,179,
            89,90,179,187,179,179,88,181,179,93,
            92,179,179,91,179,94,179,95,96,179,
            179,99,179,179,179,98,97,100,101,179,
            179,179,179,179,104,179,103,108,179,109,
            106,102,179,110,179,179,179,179,179,107,
            203,113,179,111,114,179,179,206,179,116,
            179,179,117,199,179,179,179,179,112,204,
            120,129,115,179,118,179,119,179,122,179,
            124,121,123,179,179,179,186,126,188,179,
            179,125,180,179,131,179,132,179,179,130,
            179,200,179,134,179,179,179,133,135,179,
            179,195,179,136,179,137,179,138,179,139,
            179,191,179,140,179,182,142,179,179,179,
            202,143,179,179,141,145,179,144,179,196,
            179,146,193,179,179,192,179,179,147,179,
            179,205,179,149,179,152,148,150,179,151,
            197,179,179,155,179,179,179,153,201,156,
            179,154,179,158,157,179,179,179,184,159,
            179,179,179,161,194,179,179,179,160,162,
            163,179,179,185,164,179,165,179,179,198,
            168,166,179,167,179,169,179,179,170,171,
            179,179,179,174,172,173,179,175,179,179,
            179,183,179,176
        };
    };
    public static short[] _termAction = TermAction._termAction;
    public   int termAction(int index) { return _termAction[index]; }
    public   int asb(int index) { return 0; }
    public   int asr(int index) { return 0; }
    public   int nasb(int index) { return 0; }
    public   int nasr(int index) { return 0; }
    public   int terminalIndex(int index) { return 0; }
    public   int nonterminalIndex(int index) { return 0; }
    public   int scopePrefix(int index) { return 0;}
    public   int scopeSuffix(int index) { return 0;}
    public   int scopeLhs(int index) { return 0;}
    public   int scopeLa(int index) { return 0;}
    public   int scopeStateSet(int index) { return 0;}
    public   int scopeRhs(int index) { return 0;}
    public   int scopeState(int index) { return 0;}
    public   int inSymb(int index) { return 0;}
    public   string name(int index) { return null; }
    public   int originalState(int state) { return 0; }
    public   int asi(int state) { return 0; }
    public   int nasi(int state) { return 0; }
    public   int inSymbol(int state) { return 0; }

    /**
     * assert(! goto_default);
     */
    public   int ntAction(int state, int sym) {
        return _baseAction[state + sym];
    }

    /**
     * assert(! shift_default);
     */
    public   int tAction(int state, int sym) {
        int i = _baseAction[state],
            k = i + sym;
        return _termAction[_termCheck[k] == sym ? k : i];
    }
    public   int lookAhead(int la_state, int sym) {
        int k = la_state + sym;
        return _termAction[_termCheck[k] == sym ? k : la_state];
    }
}}

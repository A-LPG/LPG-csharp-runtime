using System.Collections;

namespace LPG2.Runtime
{



    public interface IPrsStream : TokenStream
    {
        IMessageHandler getMessageHandler();
        void setMessageHandler(IMessageHandler errMsg);

        ILexStream getILexStream();

        /**
     * @deprecated replaced by {@link #getILexStream()}
     */
        ILexStream getLexStream();

        void setLexStream(ILexStream lexStream);

        /**
     * @deprecated replaced by {@link #getFirstRealToken()}
     *
     */
        int getFirstErrorToken(int i);

        /**
     * @deprecated replaced by {@link #getLastRealToken()}
     *
     */
        int getLastErrorToken(int i);

        void makeToken(int startLoc, int endLoc, int kind);

        void makeAdjunct(int startLoc, int endLoc, int kind);

        void removeLastToken();

        int getLineCount();

        int getSize();

        void remapTerminalSymbols(string[] ordered_parser_symbols, int eof_symbol);

        //throws UndefinedEofSymbolException,
        //    NullExportedSymbolsException,
        //    NullTerminalSymbolsException,
        //    UnimplementedTerminalsException;

        string[] orderedTerminalSymbols();

        int mapKind(int kind);

        void resetTokenStream();

        int getStreamIndex();

        void setStreamIndex(int index);

        void setStreamLength();

        void setStreamLength(int len);

        void addToken(IToken token);

        void addAdjunct(IToken adjunct);

        string[] orderedExportedSymbols();

        ArrayList getTokens();

        ArrayList getAdjuncts();

        IToken[] getFollowingAdjuncts(int i);

        IToken[] getPrecedingAdjuncts(int i);

        IToken getIToken(int i);

        string getTokenText(int i);

        int getStartOffset(int i);

        int getEndOffset(int i);

        int getLineOffset(int i);

        int getLineNumberOfCharAt(int i);

        int getColumnOfCharAt(int i);

        int getTokenLength(int i);

        int getLineNumberOfTokenAt(int i);

        int getEndLineNumberOfTokenAt(int i);

        int getColumnOfTokenAt(int i);

        int getEndColumnOfTokenAt(int i);

        char[] getInputChars();

        byte[] getInputBytes();

        string ToString(int first_token, int last_token);

        string ToString(IToken t1, IToken t2);

        int getTokenIndexAtCharacter(int offset);

        IToken getTokenAtCharacter(int offset);

        IToken getTokenAt(int i);

        void dumpTokens();

        void dumpToken(int i);

        int makeErrorToken(int first, int last, int error, int kind);
    }
}
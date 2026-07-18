namespace LPG2.Runtime
{

    public interface IToken
    {
        int getKind();
        void setKind(int kind);

        int getStartOffset();
        void setStartOffset(int startOffset);

        int getEndOffset();
        void setEndOffset(int endOffset);

        int getTokenIndex();
        void setTokenIndex(int i);

        int getAdjunctIndex();
        void setAdjunctIndex(int i);

        IToken[] getPrecedingAdjuncts();
        IToken[] getFollowingAdjuncts();

        ILexStream getILexStream();

        /**
     * @deprecated replaced by {@link #getILexStream()}
     */
        ILexStream getLexStream();

        IPrsStream getIPrsStream();

        /**
     * @deprecated replaced by {@link #getIPrsStream()}
     */
        IPrsStream getPrsStream();

        int getLine();
        int getColumn();
        int getEndLine();
        int getEndColumn();

        /**
     * @deprecated replaced by ToString()
     */
        string getValue(char[] inputChars);

     
    }

    public static class TokenConstants
    {
        public const char EOF = '\uffff';
    }
}

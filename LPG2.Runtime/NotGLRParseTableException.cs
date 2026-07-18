using System;

namespace LPG2.Runtime
{
    public class NotGLRParseTableException : Exception
    {
        private readonly string str;

        public NotGLRParseTableException()
        {
            str = "NotGLRParseTableException";
        }

        public NotGLRParseTableException(string str)
        {
            this.str = str;
        }

        public override string ToString()
        {
            return str;
        }
    }
}

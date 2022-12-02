using System;

namespace OmieSharp.Exceptions
{
    [Serializable]
    public class AuthenticationException : OmieSharpException
    {
        public AuthenticationException()
            : base("Authentication Error")
        {

        }

        public AuthenticationException(string message)
            : base(message)
        {

        }

        public AuthenticationException(string message, Exception baseException)
            : base(message, baseException)
        {

        }
    }
}

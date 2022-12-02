using System;

namespace OmieSharp.Exceptions
{
    [Serializable]
    public class InvalidServiceUrlException : OmieSharpException
    {
        public InvalidServiceUrlException()
            : base("Invalid Service Url")
        {

        }

        public InvalidServiceUrlException(string message)
            : base(message)
        {

        }

        public InvalidServiceUrlException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

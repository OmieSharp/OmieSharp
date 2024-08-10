namespace OmieSharp.Exceptions
{
    [Serializable]
    public class OmieSharpException : Exception
    {
        public OmieSharpException()
        {

        }

        public OmieSharpException(string message)
            : base(message)
        {

        }

        public OmieSharpException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}

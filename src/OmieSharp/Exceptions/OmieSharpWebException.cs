namespace OmieSharp.Exceptions
{
    [Serializable]
    public class OmieSharpWebException : OmieSharpException
    {
        public System.Net.HttpStatusCode HttpStatusCode { get; set; }
        public string? JsonRequest { get; set; }
        public string? JsonResponse { get; set; }

        public OmieSharpWebException()
            : base("OmieSharp WebException")
        {

        }

        public OmieSharpWebException(string message)
            : base(message)
        {

        }

        public OmieSharpWebException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public OmieSharpWebException(System.Net.HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }

        public OmieSharpWebException(System.Net.HttpStatusCode httpStatusCode, string message, string? jsonRequest, string? jsonResponse)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
            JsonRequest = jsonRequest;
            JsonResponse = jsonResponse;
        }

        public OmieSharpWebException(System.Net.HttpStatusCode httpStatusCode, string message, Exception innerException)
            : base(message, innerException)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}

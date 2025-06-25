namespace OmieSharp.Exceptions;

public class OmieSharpDuplicateRequestException : OmieSharpException
{
    const string MESSAGE = "Omie Request Duplicated";

    public OmieSharpDuplicateRequestException() : base(MESSAGE)
    {
        
    }

    public OmieSharpDuplicateRequestException(Exception innerException)
        : base(MESSAGE, innerException)
    {

    }
}

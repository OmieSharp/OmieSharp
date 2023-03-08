using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ErrorResponse
{
    [JsonPropertyName("faultstring")]
    public string? ErrorMessage { get; set; }

    [JsonPropertyName("faultcode")]
    public string? ErrorCode { get; set; }
}

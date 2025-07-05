using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaCorrenteStatus
{
    [JsonPropertyName("nCodCC")]
    public long CodCC { get; set; }

    [JsonPropertyName("cCodCCInt")]
    public string? CodCCInt { get; set; }

    [JsonPropertyName("cCodStatus")]
    public string? CodStatus { get; set; }

    [JsonPropertyName("cDesStatus")]
    public string? DesStatus { get; set; }
}

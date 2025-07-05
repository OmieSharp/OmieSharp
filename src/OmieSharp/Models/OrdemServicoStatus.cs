using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoStatus
{
    [JsonPropertyName("cCodIntOS")]
    public string? CodIntOS { get; set; }

    [JsonPropertyName("nCodOS")]
    public long CodOS { get; set; }
    
    [JsonPropertyName("cNumOS")]
    public string? NumOS { get; set; }

    [JsonPropertyName("cCodStatus")]
    public string? CodStatus { get; set; }

    [JsonPropertyName("cDescStatus")]
    public string? DescStatus { get; set; }

    [JsonIgnore]
    public bool Success => (CodStatus ?? "999").Equals("0");
}

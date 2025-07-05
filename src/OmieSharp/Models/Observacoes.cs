using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Observacoes
{
    [JsonPropertyName("cObsOS")]
    public string? ObsOS { get; set; }
}

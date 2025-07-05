using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class AlterarCadastroServicoResponse
{
    [JsonPropertyName("cCodIntServ")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodIntServ { get; set; }

    [JsonPropertyName("nCodServ")]
    public long CodServ { get; set; }

    [JsonPropertyName("cCodStatus")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodStatus { get; set; }

    [JsonPropertyName("cDescStatus")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DescStatus { get; set; }
}

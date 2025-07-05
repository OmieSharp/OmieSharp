using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class CadastroServicoCabecalho
{
    [JsonPropertyName("cDescricao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Descricao { get; set; }

    [JsonPropertyName("cCodigo")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Codigo { get; set; }

    [JsonPropertyName("cIdTrib")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? IdTrib { get; set; }

    [JsonPropertyName("cCodServMun")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodServMun { get; set; }

    [JsonPropertyName("cCodLC116")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodLC116 { get; set; }

    [JsonPropertyName("nIdNBS")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? IdNbs { get; set; }

    [JsonPropertyName("nPrecoUnit")]
    public decimal PrecoUnit { get; set; }

    [JsonPropertyName("cCodCateg")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodCateg { get; set; }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Boleto
{
    [JsonPropertyName("cGerado")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Gerado { get; set; }

    [JsonPropertyName("cNumBancario")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumBancario { get; set; }

    [JsonPropertyName("cNumBoleto")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumBoleto { get; set; }

    [JsonPropertyName("dDtEmBol")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataEmBol { get; set; }

    [JsonPropertyName("nPerJuros")]
    public int PerJuros { get; set; }

    [JsonPropertyName("nPerMulta")]
    public int PerMulta { get; set; }
}

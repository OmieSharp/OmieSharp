using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoInfoCadastro
{
    [JsonPropertyName("cAmbiente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Ambiente { get; set; }

    [JsonPropertyName("cCancelada")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? CanceladaSN { get; set; }

    [JsonPropertyName("cFaturada")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FaturadaSN { get; set; }

    [JsonPropertyName("cHrAlt")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraAlt { get; set; }

    [JsonPropertyName("cHrInc")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraInc { get; set; }

    [JsonPropertyName("dDtAlt")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataAlt { get; set; }

    [JsonPropertyName("dDtInc")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataInc { get; set; }

    [JsonPropertyName("cHrFat")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraFat { get; set; }

    [JsonPropertyName("dDtFat")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataFat { get; set; }
}

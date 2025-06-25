using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoInfoCadastro
{
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cAmbiente { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cCancelada { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cFaturada { get; set; }

    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? cHrAlt { get; set; }

    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? cHrInc { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dDtAlt { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dDtInc { get; set; }

    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? cHrFat { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dDtFat { get; set; }
}

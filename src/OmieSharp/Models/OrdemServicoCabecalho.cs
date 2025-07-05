using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoCabecalho
{
    [JsonPropertyName("cCodIntOS")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodIntOS { get; set; }

    [JsonPropertyName("cCodParc")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodParc { get; set; }

    [JsonPropertyName("cEtapa")]
    [JsonConverter(typeof(EnumJsonConverter<EtapasOS>))]
    public EtapasOS Etapa { get; set; }

    [JsonPropertyName("cNumOS")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumOS { get; set; }

    [JsonPropertyName("dDtPrevisao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataPrevisao { get; set; }

    [JsonPropertyName("nCodCli")]
    public long? CodCli { get; set; }

    [JsonPropertyName("nCodOS")]
    public long? CodOS { get; set; }

    [JsonPropertyName("nQtdeParc")]
    public int? QtdeParc { get; set; }

    [JsonPropertyName("nValorTotal")]
    public decimal? ValorTotal { get; set; }

    [JsonPropertyName("nValorTotalImpRet")]
    public decimal? ValorTotalImpRet { get; set; }
}

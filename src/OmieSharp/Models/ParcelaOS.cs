using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ParcelaOS
{
    [JsonPropertyName("dDtVenc")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataVenc { get; set; }

    [JsonPropertyName("nDias")]
    public int? NumeroDias { get; set; }
    
    [JsonPropertyName("nParcela")]
    public int? NumeroParcela { get; set; }

    [JsonPropertyName("nPercentual")]
    public decimal? Percentual { get; set; }

    [JsonPropertyName("nValor")]
    public decimal? Valor { get; set; }
}

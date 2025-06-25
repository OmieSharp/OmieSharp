using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ParcelaOS
{
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dDtVenc { get; set; }

    public int? nDias { get; set; }
    public int? nParcela { get; set; }
    public decimal? nPercentual { get; set; }
    public decimal? nValor { get; set; }
}

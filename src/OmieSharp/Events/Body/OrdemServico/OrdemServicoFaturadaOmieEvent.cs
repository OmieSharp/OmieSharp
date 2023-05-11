using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico
{
    public class OrdemServicoFaturadaOmieEvent : BaseOrdemServicoOmieEvent
    {
        [JsonPropertyName("faturada")]
        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? faturada { get; set; }

        [JsonPropertyName("dataFaturado")]
        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? DataFaturado { get; set; }

        [JsonPropertyName("horaFaturado")]
        [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
        public TimeOnly? HoraFaturado { get; set; }
    }
}

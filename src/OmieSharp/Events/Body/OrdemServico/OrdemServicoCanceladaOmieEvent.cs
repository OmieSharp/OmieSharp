using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico
{
    public class OrdemServicoCanceladaOmieEvent : BaseOrdemServicoOmieEvent
    {
        [JsonPropertyName("cancelada")]
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? Cancelada { get; set; }

        [JsonPropertyName("dataCancelado")]
        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? DataCancelado { get; set; }
    }
}

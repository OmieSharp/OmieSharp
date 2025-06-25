using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico;

public class OrdemServicoIncluidaOmieEvent : BaseOrdemServicoOmieEvent
{
    [JsonPropertyName("dataInclusao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataInclusao { get; set; }
}

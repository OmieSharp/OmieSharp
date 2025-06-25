using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico;

public class OrdemServicoAlteracaOmieEvent : BaseOrdemServicoOmieEvent
{
    [JsonPropertyName("dataAlteracao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataAlteracao { get; set; }
}

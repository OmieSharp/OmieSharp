using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico;

public class OrdemServicoAlteradaOmieEvent : BaseOrdemServicoOmieEvent
{
    [JsonPropertyName("dataAlteracao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataAlteracao { get; set; }

    [JsonPropertyName("horaFaturado")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraAlteracao { get; set; }
}

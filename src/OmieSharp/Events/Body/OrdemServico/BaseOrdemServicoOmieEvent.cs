using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.OrdemServico
{
    public abstract class BaseOrdemServicoOmieEvent : BaseOmieEvent
    {
        [JsonPropertyName("codigoCategoria")]
        public string? CodigoCategoria { get; set; }

        [JsonPropertyName("codigoIntegracao")]
        public string? CodigoIntegracao { get; set; }

        [JsonPropertyName("dataPrevisao")]
        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? DataPrevisao { get; set; }

        [JsonPropertyName("etapa")]
        public string? Etapa { get; set; }

        [JsonPropertyName("horaInclusao")]
        [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
        public TimeOnly? HoraInclusao { get; set; }

        [JsonPropertyName("idCliente")]
        public long IdCliente { get; set; }

        [JsonPropertyName("idContaCorrente")]
        public long IdContaCorrente { get; set; }

        [JsonPropertyName("idOrdemServico")]
        public long IdOrdemServico { get; set; }

        [JsonPropertyName("numeroOrdemServico")]
        public string? NumeroOrdemServico { get; set; }

        [JsonPropertyName("usuarioInclusao")]
        public string? UsuarioInclusao { get; set; }

        [JsonPropertyName("valorOrdemServico")]
        public decimal ValorOrdemServico { get; set; }
    }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body
{
    public class OrdemServicoCanceladaOmieEvent : BaseOmieEvent
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cancelada { get; set; }

        public string? codigoCategoria { get; set; }
        public string? codigoIntegracao { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? dataCancelado { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? dataPrevisao { get; set; }

        public string? etapa { get; set; }
        public string? horaCancelado { get; set; }
        public long idCliente { get; set; }
        public long idContaCorrente { get; set; }
        public long idOrdemServico { get; set; }
        public string? numeroOrdemServico { get; set; }
        public string? usuarioCancelado { get; set; }
        public decimal valorOrdemServico { get; set; }
    }
}

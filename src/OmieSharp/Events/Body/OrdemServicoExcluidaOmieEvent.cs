using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body
{
    public class OrdemServicoExcluidaOmieEvent : BaseOmieEvent
    {
        public string? codigoCategoria { get; set; }
        public string? codigoIntegracao { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? dataPrevisao { get; set; }

        public string? etapa { get; set; }
        public long idCliente { get; set; }
        public long idContaCorrente { get; set; }
        public long idOrdemServico { get; set; }
        public string? numeroOrdemServico { get; set; }
        public decimal valorOrdemServico { get; set; }
    }
}

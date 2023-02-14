using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoCabecalho
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodIntOS { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodParc { get; set; }

        [JsonConverter(typeof(EnumJsonConverter<EtapasOS>))]
        public EtapasOS cEtapa { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cNumOS { get; set; }

        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly? dDtPrevisao { get; set; }

        public long? nCodCli { get; set; }

        public long? nCodOS { get; set; }

        public int? nQtdeParc { get; set; }

        public decimal? nValorTotal { get; set; }

        public decimal? nValorTotalImpRet { get; set; }
    }
}

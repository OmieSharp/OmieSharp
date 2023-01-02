using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoServicosImpostos
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarIRRF { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarISS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cFixarPIS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemIRRF { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemPIS { get; set; }

        public bool lDeduzISS { get; set; }

        public decimal nAliqCOFINS { get; set; }

        public decimal nAliqCSLL { get; set; }

        public decimal nAliqINSS { get; set; }

        public decimal nAliqIRRF { get; set; }

        public decimal nAliqISS { get; set; }

        public decimal nAliqPIS { get; set; }

        public decimal nAliqRedBaseCOFINS { get; set; }

        public decimal nAliqRedBaseINSS { get; set; }

        public decimal nAliqRedBasePIS { get; set; }

        public decimal nBaseISS { get; set; }

        public decimal nTotDeducao { get; set; }

        public decimal nValorCOFINS { get; set; }

        public decimal nValorCSLL { get; set; }

        public decimal nValorINSS { get; set; }

        public decimal nValorIRRF { get; set; }

        public decimal nValorISS { get; set; }

        public decimal nValorPIS { get; set; }
    }
}

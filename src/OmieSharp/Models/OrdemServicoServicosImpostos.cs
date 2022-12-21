using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoServicosImpostos
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarIRRF { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarISS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cFixarPIS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemIRRF { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemPIS { get; set; }

        public bool lDeduzISS { get; set; }

        public int nAliqCOFINS { get; set; }

        public int nAliqCSLL { get; set; }

        public int nAliqINSS { get; set; }

        public int nAliqIRRF { get; set; }

        public int nAliqISS { get; set; }

        public int nAliqPIS { get; set; }

        public int nAliqRedBaseCOFINS { get; set; }

        public int nAliqRedBaseINSS { get; set; }

        public int nAliqRedBasePIS { get; set; }

        public int nBaseISS { get; set; }

        public int nTotDeducao { get; set; }

        public int nValorCOFINS { get; set; }

        public int nValorCSLL { get; set; }

        public int nValorINSS { get; set; }

        public int nValorIRRF { get; set; }

        public double nValorISS { get; set; }

        public int nValorPIS { get; set; }
    }
}

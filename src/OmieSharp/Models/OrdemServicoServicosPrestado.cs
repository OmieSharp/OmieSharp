using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoServicosPrestado
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cCodCategItem { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cCodServLC116 { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cCodServMun { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cDadosAdicItem { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cDescServ { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cNaoGerarFinanceiro { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cRetemISS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cTpDesconto { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public string? cTribServ { get; set; }

        public OrdemServicoServicosImpostos impostos { get; set; }

        public int nAliqDesconto { get; set; }

        public int nCodServico { get; set; }

        public int nIdItem { get; set; }

        public int nQtde { get; set; }

        public int nSeqItem { get; set; }

        public int nValUnit { get; set; }

        public int nValorAcrescimos { get; set; }

        public int nValorDesconto { get; set; }

        public int nValorOutrasRetencoes { get; set; }
    }
}

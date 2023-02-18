using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoServicosPrestado
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodCategItem { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodServLC116 { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodServMun { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cDadosAdicItem { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cDescServ { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cNaoGerarFinanceiro { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetemISS { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cTpDesconto { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cTribServ { get; set; }

        public OrdemServicoServicosImpostos? impostos { get; set; }

        public decimal? nAliqDesconto { get; set; }

        public long? nCodServico { get; set; }

        public long? nIdItem { get; set; }

        public decimal nQtde { get; set; }

        public int? nSeqItem { get; set; }

        public decimal? nValUnit { get; set; }

        public decimal? nValorAcrescimos { get; set; }

        public decimal? nValorDesconto { get; set; }

        public decimal? nValorOutrasRetencoes { get; set; }
    }
}

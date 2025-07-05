using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoServicosPrestado
{
    [JsonPropertyName("cCodCategItem")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodCategItem { get; set; }

    [JsonPropertyName("cCodServLC116")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodServLC116 { get; set; }

    [JsonPropertyName("cCodServMun")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodServMun { get; set; }

    [JsonPropertyName("cDadosAdicItem")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DadosAdicItem { get; set; }

    [JsonPropertyName("cDescServ")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DescServ { get; set; }

    [JsonPropertyName("cNaoGerarFinanceiro")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? NaoGerarFinanceiroSN { get; set; }

    [JsonPropertyName("cRetemISS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIssSN { get; set; }

    [JsonPropertyName("cTpDesconto")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? TpDesconto { get; set; }

    [JsonPropertyName("cTribServ")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? TribServ { get; set; }
    
    [JsonPropertyName("impostos")]
    public OrdemServicoServicosImpostos? Impostos { get; set; }

    [JsonPropertyName("nAliqDesconto")]
    public decimal? AliqDesconto { get; set; }

    [JsonPropertyName("nCodServico")]
    public long? CodServico { get; set; }

    [JsonPropertyName("nIdItem")]
    public long? IdItem { get; set; }

    [JsonPropertyName("nQtde")]
    public decimal Qtde { get; set; }

    [JsonPropertyName("nSeqItem")]
    public int? SeqItem { get; set; }

    [JsonPropertyName("nValUnit")]
    public decimal? ValUnit { get; set; }

    [JsonPropertyName("nValorAcrescimos")]
    public decimal? ValorAcrescimos { get; set; }

    [JsonPropertyName("nValorDesconto")]
    public decimal? ValorDesconto { get; set; }

    [JsonPropertyName("nValorOutrasRetencoes")]
    public decimal? ValorOutrasRetencoes { get; set; }
}

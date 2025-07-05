using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ServicoTomado
{
    /// <summary>
    /// Número da Nota Fiscal.
    /// </summary>
    [JsonPropertyName("numero_nf")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroNf { get; set; }

    /// <summary>
    /// Série da Nota Fiscal.
    /// </summary>
    [JsonPropertyName("serie_nf")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? SerieNf { get; set; }

    /// <summary>
    /// Código do serviço (LC116).
    /// </summary>
    [JsonPropertyName("codigo_servico")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoServico { get; set; }

    /// <summary>
    /// Valor total da Nota Fiscal.
    /// </summary>
    [JsonPropertyName("valor_nf")]
    public decimal ValorNf { get; set; }

    /// <summary>
    /// CST do PIS (Código da Situação Tributária).
    /// </summary>
    [JsonPropertyName("cst_pis")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CstPis { get; set; }

    /// <summary>
    /// Base de cálculo do PIS.
    /// </summary>
    [JsonPropertyName("base_pis")]
    public decimal BasePis { get; set; }

    /// <summary>
    /// Alíquota do PIS (%).
    /// </summary>
    [JsonPropertyName("aliquota_pis")]
    public decimal AliquotaPis { get; set; }

    /// <summary>
    /// Valor do PIS.
    /// </summary>
    [JsonPropertyName("valor_pis")]
    public decimal ValorPis { get; set; }

    /// <summary>
    /// CST do COFINS (Código da Situação Tributária).
    /// </summary>
    [JsonPropertyName("cst_cofins")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CstCofins { get; set; }

    /// <summary>
    /// Base de cálculo do COFINS.
    /// </summary>
    [JsonPropertyName("base_cofins")]
    public decimal BaseCofins { get; set; }

    /// <summary>
    /// Alíquota do COFINS (%).
    /// </summary>
    [JsonPropertyName("aliquota_cofins")]
    public decimal AliquotaCofins { get; set; }

    /// <summary>
    /// Valor do PIS.
    /// </summary>
    [JsonPropertyName("valor_cofins")]
    public decimal ValorCofins { get; set; }
}
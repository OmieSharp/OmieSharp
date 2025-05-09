using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ServicoTomado
{
    /// <summary>
    /// Número da Nota Fiscal.
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_nf { get; set; }

    /// <summary>
    /// Série da Nota Fiscal.
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? serie_nf { get; set; }

    /// <summary>
    /// Código do serviço (LC116).
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_servico { get; set; }

    /// <summary>
    /// Valor total da Nota Fiscal.
    /// </summary>
    public decimal valor_nf { get; set; }

    /// <summary>
    /// CST do PIS (Código da Situação Tributária).
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cst_pis { get; set; }

    /// <summary>
    /// Base de cálculo do PIS.
    /// </summary>
    public decimal base_pis { get; set; }

    /// <summary>
    /// Alíquota do PIS (%).
    /// </summary>
    public decimal aliquota_pis { get; set; }

    /// <summary>
    /// Valor do PIS.
    /// </summary>
    public decimal valor_pis { get; set; }

    /// <summary>
    /// CST do COFINS (Código da Situação Tributária).
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cst_cofins { get; set; }

    /// <summary>
    /// Base de cálculo do COFINS.
    /// </summary>
    public decimal base_cofins { get; set; }

    /// <summary>
    /// Alíquota do COFINS (%).
    /// </summary>
    public decimal aliquota_cofins { get; set; }

    /// <summary>
    /// Valor do PIS.
    /// </summary>
    public decimal valor_cofins { get; set; }
}
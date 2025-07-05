using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class DistribuicaoDepartamento
{
    /// <summary>
    /// Código do Departamento
    /// </summary>
    [JsonPropertyName("cCodDep")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoDepartamento { get; set; }

    /// <summary>
    /// Descrição do Departamento
    /// </summary>
    [JsonPropertyName("cDesDep")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DescricaoDepartamento { get; set; }

    /// <summary>
    /// Valor do rateio
    /// </summary>
    [JsonPropertyName("nValDep")]
    public decimal ValorRateio { get; set; }

    /// <summary>
    /// Percentual do rateio
    /// </summary>
    [JsonPropertyName("nPerDep")]
    public decimal PercentualRateio { get; set; }
}
using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class DistribuicaoDepartamento
{
    /// <summary>
    /// Código do Departamento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cCodDep { get; set; }

    /// <summary>
    /// Descrição do Departamento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cDesDep { get; set; }

    /// <summary>
    /// Valor do rateio
    /// </summary>
    public decimal nValDep { get; set; }

    /// <summary>
    /// Percentual do rateio
    /// </summary>
    public decimal nPerDep { get; set; }
}
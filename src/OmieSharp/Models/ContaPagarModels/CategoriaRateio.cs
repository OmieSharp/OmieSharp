using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class CategoriaRateio
{
    /// <summary>
    /// Código da Categoria
    /// </summary>
    [JsonPropertyName("codigo_categoria")]
    public string? CodigoCategoria { get; set; }

    /// <summary>
    /// Valor do Rateio
    /// </summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>
    /// Percentual da categoria
    /// </summary>
    [JsonPropertyName("percentual")]
    public decimal Percentual { get; set; }
}
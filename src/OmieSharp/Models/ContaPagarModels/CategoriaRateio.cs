namespace OmieSharp.Models.ContaPagarModels;

public class CategoriaRateio
{
    /// <summary>
    /// Código da Categoria
    /// </summary>
    public string? codigo_categoria { get; set; }

    /// <summary>
    /// Valor do Rateio
    /// </summary>
    public decimal valor { get; set; }

    /// <summary>
    /// Percentual da categoria
    /// </summary>
    public decimal percentual { get; set; }
}
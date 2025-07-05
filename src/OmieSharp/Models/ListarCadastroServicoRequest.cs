using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarCadastroServicoRequest
{
    [JsonPropertyName("nPagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("nRegPorPagina")]
    public int RegistrosPorPagina { get; set; }

    [JsonPropertyName("cOrdenarPor")]
    public string? OrdenarPor { get; set; }

    [JsonPropertyName("cOrdemDecrescente")]
    public string? OrdemDecrescente { get; set; }

    [JsonPropertyName("dInclusaoInicial")]
    public string? DataInclusaoInicial { get; set; }

    [JsonPropertyName("hInclusaoInicial")]
    public string? HoraInclusaoInicial { get; set; }

    [JsonPropertyName("dInclusaoFinal")]
    public string? DataInclusaoFinal { get; set; }

    [JsonPropertyName("hInclusaoFinal")]
    public string? HoraInclusaoFinal { get; set; }

    [JsonPropertyName("dAlteracaoInicial")]
    public string? DataAlteracaoInicial { get; set; }

    [JsonPropertyName("hAlteracaoInicial")]
    public string? HoraAlteracaoInicial { get; set; }

    [JsonPropertyName("dAlteracaoFinal")]
    public string? DataAlteracaoFinal { get; set; }

    [JsonPropertyName("hAlteracaoFinal")]
    public string? HoraAlteracaoFinal { get; set; }

    [JsonPropertyName("cDescricao")]
    public string? Descricao { get; set; }

    [JsonPropertyName("cCodigo")]
    public string? Codigo { get; set; }

    [JsonPropertyName("inativo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? InativoSN { get; set; }

    [JsonPropertyName("cExibirProdutos")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExibirProdutosSN { get; set; }

    public ListarCadastroServicoRequest(int nPagina = 1, int nRegPorPagina = 50)
    {
        this.Pagina = nPagina;
        this.RegistrosPorPagina = nRegPorPagina;
    }
}

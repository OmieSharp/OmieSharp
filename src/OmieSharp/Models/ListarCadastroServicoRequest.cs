using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarCadastroServicoRequest
{
    public int nPagina { get; set; }
    
    public int nRegPorPagina { get; set; }

    public string? cOrdenarPor { get; set; }

    public string? cOrdemDecrescente { get; set; }

    public string? dInclusaoInicial { get; set; }
    public string? hInclusaoInicial { get; set; }

    public string? dInclusaoFinal { get; set; }
    public string? hInclusaoFinal { get; set; }

    public string? dAlteracaoInicial { get; set; }
    public string? hAlteracaoInicial { get; set; }

    public string? dAlteracaoFinal { get; set; }
    public string? hAlteracaoFinal { get; set; }

    public string? cDescricao { get; set; }

    public string? cCodigo { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? inativo { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cExibirProdutos { get; set; }

    public ListarCadastroServicoRequest(int nPagina = 1, int nRegPorPagina = 50)
    {
        this.nPagina = nPagina;
        this.nRegPorPagina = nRegPorPagina;
    }
}

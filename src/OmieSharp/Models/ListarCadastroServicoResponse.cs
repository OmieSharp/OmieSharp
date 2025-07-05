using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarCadastroServicoResponse
{
    [JsonPropertyName("nPagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("nTotPaginas")]
    public int TotalPaginas { get; set; }

    [JsonPropertyName("nRegistros")]
    public int Registros { get; set; }

    [JsonPropertyName("nTotRegistros")]
    public int TotalRegistros { get; set; }

    [JsonPropertyName("cadastros")]
    public List<CadastroServico> Cadastros { get; set; }

    public ListarCadastroServicoResponse()
    {
        Pagina = 1;
        Cadastros = [];
    }
}

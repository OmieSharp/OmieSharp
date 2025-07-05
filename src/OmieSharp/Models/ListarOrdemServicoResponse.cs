using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarOrdemServicoResponse
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("total_de_paginas")]
    public int TotalPaginas { get; set; }

    [JsonPropertyName("registros")]
    public int Registros { get; set; }

    [JsonPropertyName("total_de_registros")]
    public int TotalRegistros { get; set; }

    [JsonPropertyName("osCadastro")]
    public List<OrdemServico> OrdemServicos { get; set; }

    public ListarOrdemServicoResponse()
    {
        OrdemServicos = new List<OrdemServico>();
    }
}

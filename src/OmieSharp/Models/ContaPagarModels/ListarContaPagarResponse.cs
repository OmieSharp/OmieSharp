using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ListarContaPagarResponse
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("total_de_paginas")]
    public int TotalPaginas { get; set; }

    [JsonPropertyName("registros")]
    public int Registros { get; set; }

    [JsonPropertyName("total_de_registros")]
    public int TotalRegistros { get; set; }

    [JsonPropertyName("conta_pagar_cadastro")]
    public List<ContaPagar> ContaPagarCadastro { get; set; }

    public ListarContaPagarResponse()
    {
        ContaPagarCadastro = [];
    }
}

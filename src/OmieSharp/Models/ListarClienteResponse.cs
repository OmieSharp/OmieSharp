using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarClienteResponse
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("total_de_paginas")]
    public int TotalPaginas { get; set; }

    [JsonPropertyName("registros")]
    public int Registros { get; set; }

    [JsonPropertyName("total_de_registros")]
    public int TotalRegistros { get; set; }

    [JsonPropertyName("clientes_cadastro")]
    public List<ClienteCadastro>? ClientesCadastro { get; set; }

    public ListarClienteResponse()
    {
        Pagina = 1;
        ClientesCadastro = new List<ClienteCadastro>();
    }
}

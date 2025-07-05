using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarContaCorrenteResponse
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("total_de_paginas")]
    public int TotalPaginas { get; set; }

    [JsonPropertyName("registros")]
    public int Registros { get; set; }

    [JsonPropertyName("total_de_registros")]
    public int TotalRegistros { get; set; }

    [JsonPropertyName("ListarContasCorrentes")]
    public List<ContaCorrente> ListarContasCorrentes { get; set; }

    public ListarContaCorrenteResponse()
    {
        Pagina = 0;
        TotalPaginas = 0;
        Registros = 0;
        TotalRegistros = 0;
        ListarContasCorrentes = [];
    }
}

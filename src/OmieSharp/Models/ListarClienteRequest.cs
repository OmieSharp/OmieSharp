using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarClienteRequest
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("registros_por_pagina")]
    public int RegistrosPorPagina { get; set; }

    [JsonPropertyName("apenas_importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ApenasImportadoApiSN { get; set; }

    [JsonPropertyName("ordenar_por")]
    public string? OrdenarPor { get; set; }

    [JsonPropertyName("ordem_decrescente")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? OrdemDecrescenteSN { get; set; }

    [JsonPropertyName("filtrar_por_data_de")]
    public string? FiltrarPorDataDe { get; set; }

    [JsonPropertyName("filtrar_por_data_ate")]
    public string? FiltrarPorDataAte { get; set; }

    [JsonPropertyName("filtrar_por_hora_de")]
    public string? FiltrarPorHoraDe { get; set; }

    [JsonPropertyName("filtrar_por_hora_ate")]
    public string? FiltrarPorHoraAte { get; set; }

    [JsonPropertyName("filtrar_apenas_alteracao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasAlteracaoSN { get; set; }

    [JsonPropertyName("clientesFiltro")]
    public ClientFiltro? ClientesFiltro { get; set; }

    [JsonPropertyName("clientesPorCodigo")]
    public List<ClienteCadastroChave>? ClientesPorCodigo { get; set; }

    [JsonPropertyName("exibir_caracteristicas")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExibirCaracteristicasSN { get; set; }

    public ListarClienteRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
    {
        this.Pagina = pagina;
        this.RegistrosPorPagina = registros_por_pagina;
        this.ApenasImportadoApiSN = apenas_importado_api;
    }
}

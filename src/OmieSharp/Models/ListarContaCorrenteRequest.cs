using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ListarContaCorrenteRequest
{
    [JsonPropertyName("pagina")]
    public int Pagina { get; set; }

    [JsonPropertyName("registros_por_pagina")]
    public int RegistrosPorPagina { get; set; }

    [JsonPropertyName("apenas_importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ApenasImportadoApiSN { get; set; }

    [JsonPropertyName("codigo")]
    public long? Codigo { get; set; }

    [JsonPropertyName("codigo_integracao")]
    public string? CodigoIntegracao { get; set; }

    [JsonPropertyName("ordenar_por")]
    public string? OrdenarPor { get; set; }

    [JsonPropertyName("ordem_decrescente")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? OrdemDecrescenteSN { get; set; }

    [JsonPropertyName("filtrar_por_data_de")]
    public string? FiltrarPorDataDe { get; set; }

    [JsonPropertyName("filtrar_por_data_ate")]
    public string? FiltrarPorDataAte { get; set; }

    [JsonPropertyName("filtrar_apenas_inclusao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasInclusaoSN { get; set; }

    [JsonPropertyName("filtrar_apenas_alteracao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasAlteracaoSN { get; set; }

    [JsonPropertyName("filtrar_apenas_ativo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasAtivoSN { get; set; }

    public ListarContaCorrenteRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
    {
        this.Pagina = pagina;
        this.RegistrosPorPagina = registros_por_pagina;
        this.ApenasImportadoApiSN = apenas_importado_api;
    }
}

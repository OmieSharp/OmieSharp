using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ListarOrdemServicoRequest
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
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorDataDe { get; set; }

    [JsonPropertyName("filtrar_por_data_ate")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorDataAte { get; set; }

    [JsonPropertyName("filtrar_apenas_inclusao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasInclusaoSN { get; set; }

    [JsonPropertyName("filtrar_apenas_alteracao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FiltrarApenasAlteracaoSN { get; set; }

    [JsonPropertyName("filtrar_por_codigo")]
    public List<OrdemServicoChave>? FiltrarPorCodigo { get; set; }

    [JsonPropertyName("filtrar_por_status")]
    public string? FiltrarPorStatus { get; set; }

    [JsonPropertyName("filtrar_por_etapa")]
    public string? FiltrarPorEtapa { get; set; }

    [JsonPropertyName("filtrar_por_cliente")]
    public int? FiltrarPorCliente { get; set; }

    [JsonPropertyName("cExibirDespesas")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExibirDespesasSN { get; set; }

    [JsonPropertyName("cExibirProdutos")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExibirProdutosSN { get; set; }

    [JsonPropertyName("cTipoFat")]
    public string? CTipoFat { get; set; }

    public ListarOrdemServicoRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
    {
        this.Pagina = pagina;
        this.RegistrosPorPagina = registros_por_pagina;
        this.ApenasImportadoApiSN = apenas_importado_api;
    }
}

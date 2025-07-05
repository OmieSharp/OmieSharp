using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ListarContaPagarRequest
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

    [JsonPropertyName("filtrar_por_emissao_de")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorEmissaoDe { get; set; }

    [JsonPropertyName("filtrar_por_emissao_ate")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorEmissaoAte { get; set; }

    [JsonPropertyName("filtrar_por_registro_de")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorRegistroDe { get; set; }

    [JsonPropertyName("filtrar_por_registro_ate")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? FiltrarPorRegistroAte { get; set; }

    [JsonPropertyName("filtrar_conta_corrente")]
    public long? FiltrarContaCorrente { get; set; }

    [JsonPropertyName("filtrar_cliente")]
    public long? FiltrarCliente { get; set; }

    [JsonPropertyName("filtrar_por_cpf_cnpj")]
    public string? FiltrarPorCpfCnpj { get; set; }

    [JsonPropertyName("filtrar_por_status")]
    public string? FiltrarPorStatus { get; set; }

    [JsonPropertyName("filtrar_por_projeto")]
    public long? FiltrarPorProjeto { get; set; }

    [JsonPropertyName("filtrar_por_vendedor")]
    public long? FiltrarPorVendedor { get; set; }
    
    [JsonPropertyName("exibir_obs")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExibirObsSN { get; set; }

    public ListarContaPagarRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
    {
        this.Pagina = pagina;
        this.RegistrosPorPagina = registros_por_pagina;
        this.ApenasImportadoApiSN = apenas_importado_api;
    }
}

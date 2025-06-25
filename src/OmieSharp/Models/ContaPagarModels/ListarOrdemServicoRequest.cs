using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ListarOrdemServicoRequest
{
    public int pagina { get; set; }
    public int registros_por_pagina { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? apenas_importado_api { get; set; }

    public string? ordenar_por { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ordem_decrescente { get; set; }


    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? filtrar_por_data_de { get; set; }
    
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? filtrar_por_data_ate { get; set; }


    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? filtrar_apenas_inclusao { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? filtrar_apenas_alteracao { get; set; }

    public List<OrdemServicoChave>? filtrar_por_codigo { get; set; }

    public string? filtrar_por_status { get; set; }

    public string? filtrar_por_etapa { get; set; }

    public int? filtrar_por_cliente { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cExibirDespesas { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cExibirProdutos { get; set; }

    public string? cTipoFat { get; set; }

    public ListarOrdemServicoRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
    {
        this.pagina = pagina;
        this.registros_por_pagina = registros_por_pagina;
        this.apenas_importado_api = apenas_importado_api;
    }
}

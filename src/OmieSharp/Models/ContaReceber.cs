using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaReceber
{
    public long codigo_lancamento_omie { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_lancamento_integracao { get; set; }

    public long codigo_cliente_fornecedor { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_cliente_fornecedor_integracao { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_vencimento { get; set; }

    public decimal valor_documento { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_categoria { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_previsao { get; set; }

    //public List<Categoria> categorias { get; set; }

    public long id_conta_corrente { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_documento { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_parcela { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_tipo_documento { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_documento_fiscal { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_pedido { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? chave_nfe { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? observacao { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_barras_ficha_compensacao { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_cmc7_cheque { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_emissao { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? id_origem { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? operacao { get; set; }

    public decimal valor_pis { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_pis { get; set; }

    public decimal valor_cofins { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_cofins { get; set; }

    public decimal valor_csll { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_csll { get; set; }

    public decimal valor_ir { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_ir { get; set; }

    public decimal valor_iss { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_iss { get; set; }

    public decimal valor_inss { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_inss { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? bloqueado { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? bloquear_baixa { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? importado_api { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? baixar_documento { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? conciliar_documento { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? acao { get; set; }

    //public object lancamento_detalhe { get; set; }
    //public List<object> distribuicao { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? status_titulo { get; set; }

    public int codigo_vendedor { get; set; }
    
    public int codigo_projeto { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? nsu { get; set; }

    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_registro { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? tipo_agrupamento { get; set; }

    public Info? info { get; set; }

    public Boleto? boleto { get; set; }

    public long nCodPedido { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? bloquear_exclusao { get; set; }

    public long nCodOS { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cPedidoCliente { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cNumeroContrato { get; set; }

    //public object recebimento { get; set; }
    //public object repeticao { get; set; }
}

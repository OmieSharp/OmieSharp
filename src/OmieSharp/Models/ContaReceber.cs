using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaReceber
{
    [JsonPropertyName("codigo_lancamento_omie")]
    public long CodigoLancamentoOmie { get; set; }

    [JsonPropertyName("codigo_lancamento_integracao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoLancamentoIntegracao { get; set; }

    [JsonPropertyName("codigo_cliente_fornecedor")]
    public long CodigoClienteFornecedor { get; set; }

    [JsonPropertyName("codigo_cliente_fornecedor_integracao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoClienteFornecedorIntegracao { get; set; }

    [JsonPropertyName("data_vencimento")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataVencimento { get; set; }

    [JsonPropertyName("valor_documento")]
    public decimal ValorDocumento { get; set; }

    [JsonPropertyName("codigo_categoria")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoCategoria { get; set; }

    [JsonPropertyName("data_previsao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataPrevisao { get; set; }

    //public List<Categoria> categorias { get; set; }

    [JsonPropertyName("id_conta_corrente")]
    public long IdContaCorrente { get; set; }

    [JsonPropertyName("numero_documento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroDocumento { get; set; }

    [JsonPropertyName("numero_parcela")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroParcela { get; set; }

    [JsonPropertyName("codigo_tipo_documento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoTipoDocumento { get; set; }

    [JsonPropertyName("numero_documento_fiscal")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroDocumentoFiscal { get; set; }

    [JsonPropertyName("numero_pedido")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroPedido { get; set; }

    [JsonPropertyName("chave_nfe")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ChaveNfe { get; set; }

    [JsonPropertyName("observacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Observacao { get; set; }

    [JsonPropertyName("codigo_barras_ficha_compensacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoBarrasFichaCompensacao { get; set; }

    [JsonPropertyName("codigo_cmc7_cheque")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoCmc7Cheque { get; set; }

    [JsonPropertyName("data_emissao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataEmissao { get; set; }

    [JsonPropertyName("id_origem")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? IdOrigem { get; set; }

    [JsonPropertyName("operacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Operacao { get; set; }

    [JsonPropertyName("valor_pis")]
    public decimal ValorPis { get; set; }

    [JsonPropertyName("retem_pis")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemPisSN { get; set; }

    [JsonPropertyName("valor_cofins")]
    public decimal ValorCofins { get; set; }

    [JsonPropertyName("retem_cofins")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCofinsSN { get; set; }

    [JsonPropertyName("valor_csll")]
    public decimal ValorCsll { get; set; }

    [JsonPropertyName("retem_csll")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCsllSN { get; set; }

    [JsonPropertyName("valor_ir")]
    public decimal ValorIr { get; set; }
    
    [JsonPropertyName("retem_ir")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIrSN { get; set; }

    [JsonPropertyName("valor_iss")]
    public decimal ValorIss { get; set; }

    [JsonPropertyName("retem_iss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIssSN { get; set; }

    [JsonPropertyName("valor_inss")]
    public decimal ValorInss { get; set; }

    [JsonPropertyName("retem_inss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemInssSN { get; set; }

    [JsonPropertyName("bloqueado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloqueadoSN { get; set; }

    [JsonPropertyName("bloquear_baixa")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloquearBaixaSN { get; set; }

    [JsonPropertyName("importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ImportadoApiSN { get; set; }

    [JsonPropertyName("baixar_documento")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BaixarDocumentoSN { get; set; }

    [JsonPropertyName("conciliar_documento")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ConciliarDocumentoSN { get; set; }

    [JsonPropertyName("acao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Acao { get; set; }

    //public object lancamento_detalhe { get; set; }
    //public List<object> distribuicao { get; set; }

    [JsonPropertyName("status_titulo")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? StatusTitulo { get; set; }

    [JsonPropertyName("codigo_vendedor")]
    public int CodigoVendedor { get; set; }

    [JsonPropertyName("codigo_projeto")]
    public int CodigoProjeto { get; set; }

    [JsonPropertyName("nsu")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Nsu { get; set; }

    [JsonPropertyName("data_registro")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataRegistro { get; set; }

    [JsonPropertyName("tipo_agrupamento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? TipoAgrupamento { get; set; }

    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    [JsonPropertyName("boleto")]
    public Boleto? Boleto { get; set; }

    [JsonPropertyName("nCodPedido")]
    public long CodPedido { get; set; }

    [JsonPropertyName("bloquear_exclusao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloquearExclusaoSN { get; set; }

    [JsonPropertyName("nCodOS")]
    public long CodOS { get; set; }

    [JsonPropertyName("cPedidoCliente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? PedidoCliente { get; set; }
    
    [JsonPropertyName("cNumeroContrato")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroContrato { get; set; }

    //public object recebimento { get; set; }
    //public object repeticao { get; set; }
}

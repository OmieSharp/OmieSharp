using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.ContaReceber;

public abstract class BaseContaReceberOmieEvent : BaseOmieEvent
{
    [JsonPropertyName("baixa_bloqueada")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BaixaBloqueada { get; set; }

    [JsonPropertyName("bloqueado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? Bloqueado { get; set; }

    [JsonPropertyName("boleto_gerado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BoletoGerado { get; set; }

    [JsonPropertyName("chave_nfe")]
    public string? ChaveNfe { get; set; }

    [JsonPropertyName("codigo_categoria")]
    public string? CodigoCategoria { get; set; }

    [JsonPropertyName("codigo_cliente_fornecedor")]
    public long CodigoClienteFornecedor { get; set; }

    [JsonPropertyName("codigo_cmc7_cheque")]
    public string? CodigoCmc7Cheque { get; set; }

    [JsonPropertyName("codigo_lancamento_integracao")]
    public string? CodigoLancamentoIntegracao { get; set; }

    [JsonPropertyName("codigo_lancamento_omie")]
    public long CodigoLancamentoOmie { get; set; }

    [JsonPropertyName("codigo_projeto")]
    public long CodigoProjeto { get; set; }
    
    [JsonPropertyName("codigo_tipo_documento")]
    public string? CodigoTipoDocumento { get; set; }

    [JsonPropertyName("codigo_vendedor")]
    public long CodigoVendedor { get; set; }

    [JsonPropertyName("data_emissao")]
    public DateTime DataEmissao { get; set; }

    [JsonPropertyName("data_previsao")]
    public DateTime DataPrevisao { get; set; }

    [JsonPropertyName("data_registro")]
    public DateTime DataRegistro { get; set; }

    [JsonPropertyName("data_vencimento")]
    public DateTime DataVencimento { get; set; }

    [JsonPropertyName("id_conta_corrente")]
    public long IdContaCorrente { get; set; }

    [JsonPropertyName("id_origem")]
    public string? IdOrigem { get; set; }

    [JsonPropertyName("nsu")]
    public string? Nsu { get; set; }

    [JsonPropertyName("numero_documento")]
    public string? NumeroDocumento { get; set; }

    [JsonPropertyName("numero_documento_fiscal")]
    public string? NumeroDocumentoFiscal { get; set; }

    [JsonPropertyName("numero_parcela")]
    public string? NumeroParcela { get; set; }

    [JsonPropertyName("numero_pedido")]
    public string? NumeroPedido { get; set; }

    [JsonPropertyName("observacao")]
    public string? Observacao { get; set; }

    [JsonPropertyName("operacao")]
    public string? Operacao { get; set; }

    [JsonPropertyName("pix_gerado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PixGerado { get; set; }

    [JsonPropertyName("retem_cofins")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCofins { get; set; }

    [JsonPropertyName("retem_csll")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCsll { get; set; }

    [JsonPropertyName("retem_inss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemInss { get; set; }

    [JsonPropertyName("retem_ir")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIr { get; set; }

    [JsonPropertyName("retem_iss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIss { get; set; }

    [JsonPropertyName("retem_pis")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemPis { get; set; }

    [JsonPropertyName("situacao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? Situacao { get; set; }

    [JsonPropertyName("valor_cofins")]
    public decimal ValorCofins { get; set; }

    [JsonPropertyName("valor_csll")]
    public decimal ValorCsll { get; set; }

    [JsonPropertyName("valor_documento")]
    public decimal ValorDocumento { get; set; }

    [JsonPropertyName("valor_inss")]
    public decimal ValorInss { get; set; }

    [JsonPropertyName("valor_ir")]
    public decimal ValorIr { get; set; }

    [JsonPropertyName("valor_iss")]
    public decimal ValorIss { get; set; }

    [JsonPropertyName("valor_pis")]
    public decimal ValorPis { get; set; }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ContaPagar
{
    /// <summary>
    /// Código do Lançamento de Contas a Pagar
    /// </summary>
    [JsonPropertyName("codigo_lancamento_omie")]
    public long CodigoLancamentoOmie { get; set; }

    /// <summary>
    /// Código de Integração do Lançamento de Contas a Pagar
    /// </summary>
    [JsonPropertyName("codigo_lancamento_integracao")]
    public string? CodigoLancamentoIntegracao { get; set; }

    /// <summary>
    /// Código do Favorecido / Fornecedor
    /// </summary>
    [JsonPropertyName("codigo_cliente_fornecedor")]
    public long CodigoClienteFornecedor { get; set; }

    /// <summary>
    /// Código de Integração do Favorecido / Fornecedor
    /// </summary>
    [JsonPropertyName("codigo_cliente_fornecedor_integracao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoClienteFornecedorIntegracao { get; set; }

    /// <summary>
    /// Data de Vencimento
    /// </summary>
    [JsonPropertyName("data_vencimento")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataVencimento { get; set; }

    /// <summary>
    /// Valor da Conta
    /// </summary>
    [JsonPropertyName("valor_documento")]
    public decimal? ValorDocumento { get; set; }

    /// <summary>
    /// Código da Categoria
    /// </summary>
    [JsonPropertyName("codigo_categoria")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoCategoria { get; set; }

    /// <summary>
    /// Rateio de Categoria
    /// </summary>
    [JsonPropertyName("categorias")]
    public List<CategoriaRateio>? Categorias { get; set; }

    /// <summary>
    /// Data da Previsão de Pagamento
    /// </summary>
    [JsonPropertyName("data_previsao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataPrevisao { get; set; }

    /// <summary>
    /// Código da Conta Corrente
    /// </summary>
    [JsonPropertyName("id_conta_corrente")]
    public long IdContaCorrente { get; set; }

    /// <summary>
    /// Número da Nota Fiscal
    /// </summary>
    [JsonPropertyName("numero_documento_fiscal")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroDocumentoFiscal { get; set; }

    /// <summary>
    /// Data de Emissão
    /// </summary>
    [JsonPropertyName("data_emissao")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataEmissao { get; set; }

    /// <summary>
    /// Data de Registro
    /// </summary>
    [JsonPropertyName("data_entrada")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataEntrada { get; set; }

    /// <summary>
    /// Código do Projeto
    /// </summary>
    [JsonPropertyName("codigo_projeto")]
    public long CodigoProjeto { get; set; }

    /// <summary>
    /// Observações
    /// </summary>
    [JsonPropertyName("observacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Observacao { get; set; }

    /// <summary>
    /// Valor do PIS
    /// </summary>
    [JsonPropertyName("valor_pis")]
    public decimal? ValorPis { get; set; }

    /// <summary>
    /// Reter PIS
    /// </summary>
    [JsonPropertyName("retem_pis")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemPisSN { get; set; }

    /// <summary>
    /// Valor do PIS
    /// </summary>
    [JsonPropertyName("valor_cofins")]
    public decimal? ValorCofins { get; set; }

    /// <summary>
    /// Reter COFINS
    /// </summary>
    [JsonPropertyName("retem_cofins")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCofinsSN { get; set; }

    /// <summary>
    /// Valor CSLL
    /// </summary>
    [JsonPropertyName("valor_csll")]
    public decimal? ValorCsll { get; set; }

    /// <summary>
    /// Reter CSLL
    /// </summary>
    [JsonPropertyName("retem_csll")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCsllSN { get; set; }

    /// <summary>
    /// Valor IR
    /// </summary>
    [JsonPropertyName("valor_ir")]
    public decimal? ValorIr { get; set; }

    /// <summary>
    /// Reter IR
    /// </summary>
    [JsonPropertyName("retem_ir")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIrSN { get; set; }

    /// <summary>
    /// Valor ISS
    /// </summary>
    [JsonPropertyName("valor_iss")]
    public decimal? ValorIss { get; set; }

    /// <summary>
    /// Reter ISS
    /// </summary>
    [JsonPropertyName("retem_iss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIssSN { get; set; }

    /// <summary>
    /// Valor INSS
    /// </summary>
    [JsonPropertyName("valor_inss")]
    public decimal? ValorInss { get; set; }

    /// <summary>
    /// Reter INSS
    /// </summary>
    [JsonPropertyName("retem_inss")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemInssSN { get; set; }

    /// <summary>
    /// Distribuição por Departamentos
    /// </summary>
    [JsonPropertyName("distribuicao")]
    public List<DistribuicaoDepartamento>? Distribuicao { get; set; }

    /// <summary>
    /// Número do Pedido
    /// </summary>
    [JsonPropertyName("numero_pedido")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroPedido { get; set; }

    /// <summary>
    /// Código do Tipo de Documento
    /// </summary>
    [JsonPropertyName("codigo_tipo_documento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoTipoDocumento { get; set; }

    /// <summary>
    /// Número do Documento
    /// </summary>
    [JsonPropertyName("numero_documento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroDocumento { get; set; }

    /// <summary>
    /// Número da parcela
    /// </summary>
    [JsonPropertyName("numero_parcela")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroParcela { get; set; }

    /// <summary>
    /// Chave da NFe
    /// </summary>
    [JsonPropertyName("chave_nfe")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ChaveNfe { get; set; }

    /// <summary>
    /// Código de Barras (de Cobrança Bancária, de Concessionária ou de Impostos)
    /// </summary>
    [JsonPropertyName("codigo_barras_ficha_compensacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoBarrasFichaCompensacao { get; set; }

    /// <summary>
    /// Código do Vendedor
    /// </summary>
    [JsonPropertyName("codigo_vendedor")]
    public long CodigoVendedor { get; set; }

    /// <summary>
    /// Código da Origem
    /// </summary>
    [JsonPropertyName("id_origem")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? IdOrigem { get; set; }

    /// <summary>
    /// Informações sobre a criação/alteração do lançamento de Contas a Pagar
    /// </summary>
    [JsonPropertyName("info")]
    public Info? Info { get; set; }

    /// <summary>
    /// Código da Operação
    /// </summary>
    [JsonPropertyName("operacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Operacao { get; set; }

    /// <summary>
    /// Status do Título
    /// </summary>
    [JsonPropertyName("status_titulo")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? StatusTitulo { get; set; }

    /// <summary>
    /// Importado pela API (S/N)
    /// </summary>
    [JsonPropertyName("importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ImportadoApiSN { get; set; }

    /// <summary>
    /// Bloqueia a exclusão do registro (S/N)
    /// </summary>
    [JsonPropertyName("bloquear_exclusao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloquearExclusaoSN { get; set; }

    /// <summary>
    /// Dados do CNAB e Integração Bancária
    /// </summary>
    [JsonPropertyName("cnab_integracao_bancaria")]
    public CnabIntegracaoBancaria? CnabIntegracaoBancaria { get; set; }

    /// <summary>
    /// Informações da aba de Serviço Tomado da Ordem de Serviço
    /// </summary>
    [JsonPropertyName("servico_tomado")]
    public ServicoTomado? ServicoTomado { get; set; }

    /// <summary>
    /// Valor a pagar
    /// </summary>
    [JsonPropertyName("valor_pag")]
    public decimal? ValorPag { get; set; }

    /// <summary>
    /// Aprendizado de rateio de departamento
    /// </summary>
    [JsonPropertyName("aprendizado_rateio")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? AprendizadoRateio { get; set; }
    
    public ContaPagar()
    {

    }

    public ContaPagar(string? codigo_lancamento_integracao, int codigo_cliente_fornecedor, DateOnly? data_vencimento, int valor_documento, string? codigo_categoria, DateOnly? data_previsao, int id_conta_corrente)
    {
        this.CodigoLancamentoIntegracao = codigo_lancamento_integracao;
        this.CodigoClienteFornecedor = codigo_cliente_fornecedor;
        this.DataVencimento = data_vencimento;
        this.ValorDocumento = valor_documento;
        this.CodigoCategoria = codigo_categoria;
        this.DataPrevisao = data_previsao;
        this.IdContaCorrente = id_conta_corrente;
    }
}

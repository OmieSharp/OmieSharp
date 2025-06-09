using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ContaPagar
{
    /// <summary>
    /// Código do Lançamento de Contas a Pagar
    /// </summary>
    public long codigo_lancamento_omie { get; set; }

    /// <summary>
    /// Código de Integração do Lançamento de Contas a Pagar
    /// </summary>
    public string? codigo_lancamento_integracao { get; set; }

    /// <summary>
    /// Código do Favorecido / Fornecedor
    /// </summary>
    public long codigo_cliente_fornecedor { get; set; }

    /// <summary>
    /// Código de Integração do Favorecido / Fornecedor
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_cliente_fornecedor_integracao { get; set; }

    /// <summary>
    /// Data de Vencimento
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_vencimento { get; set; }

    /// <summary>
    /// Valor da Conta
    /// </summary>
    public decimal valor_documento { get; set; }

    /// <summary>
    /// Código da Categoria
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_categoria { get; set; }

    /// <summary>
    /// Rateio de Categoria
    /// </summary>
    public List<CategoriaRateio>? categorias { get; set; }

    /// <summary>
    /// Data da Previsão de Pagamento
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_previsao { get; set; }

    /// <summary>
    /// Código da Conta Corrente
    /// </summary>
    public long id_conta_corrente { get; set; }

    /// <summary>
    /// Número da Nota Fiscal
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_documento_fiscal { get; set; }

    /// <summary>
    /// Data de Emissão
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_emissao { get; set; }

    /// <summary>
    /// Data de Registro
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? data_entrada { get; set; }

    /// <summary>
    /// Código do Projeto
    /// </summary>
    public long codigo_projeto { get; set; }

    /// <summary>
    /// Observações
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? observacao { get; set; }

    /// <summary>
    /// Valor do PIS
    /// </summary>
    public decimal valor_pis { get; set; }

    /// <summary>
    /// Reter PIS
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_pis { get; set; }

    /// <summary>
    /// Valor do PIS
    /// </summary>
    public decimal valor_cofins { get; set; }

    /// <summary>
    /// Reter COFINS
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_cofins { get; set; }

    /// <summary>
    /// Valor CSLL
    /// </summary>
    public decimal valor_csll { get; set; }

    /// <summary>
    /// Reter CSLL
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_csll { get; set; }

    /// <summary>
    /// Valor IR
    /// </summary>
    public decimal valor_ir { get; set; }

    /// <summary>
    /// Reter IR
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_ir { get; set; }

    /// <summary>
    /// Valor ISS
    /// </summary>
    public decimal valor_iss { get; set; }

    /// <summary>
    /// Reter ISS
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_iss { get; set; }

    /// <summary>
    /// Valor INSS
    /// </summary>
    public decimal valor_inss { get; set; }

    /// <summary>
    /// Reter INSS
    /// </summary>
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? retem_inss { get; set; }

    /// <summary>
    /// Distribuição por Departamentos
    /// </summary>
    public List<DistribuicaoDepartamento>? distribuicao { get; set; }

    /// <summary>
    /// Número do Pedido
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_pedido { get; set; }

    /// <summary>
    /// Código do Tipo de Documento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_tipo_documento { get; set; }

    /// <summary>
    /// Número do Documento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_documento { get; set; }

    /// <summary>
    /// Número da parcela
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? numero_parcela { get; set; }

    /// <summary>
    /// Chave da NFe
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? chave_nfe { get; set; }

    /// <summary>
    /// Código de Barras (de Cobrança Bancária, de Concessionária ou de Impostos)
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_barras_ficha_compensacao { get; set; }

    /// <summary>
    /// Código do Vendedor
    /// </summary>
    public long codigo_vendedor { get; set; }

    /// <summary>
    /// Código da Origem
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? id_origem { get; set; }

    /// <summary>
    /// Informações sobre a criação/alteração do lançamento de Contas a Pagar
    /// </summary>
    public Info? info { get; set; }

    /// <summary>
    /// Código da Operação
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? operacao { get; set; }

    /// <summary>
    /// Status do Título
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? status_titulo { get; set; }

    /// <summary>
    /// Importado pela API (S/N)
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? importado_api { get; set; }

    /// <summary>
    /// Bloqueia a exclusão do registro (S/N)
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? bloquear_exclusao { get; set; }

    /// <summary>
    /// Dados do CNAB e Integração Bancária
    /// </summary>
    public CnabIntegracaoBancaria? cnab_integracao_bancaria { get; set; }

    /// <summary>
    /// Informações da aba de Serviço Tomado da Ordem de Serviço
    /// </summary>
    public ServicoTomado? servico_tomado { get; set; }

    /// <summary>
    /// Valor a pagar
    /// </summary>
    public decimal valor_pag { get; set; }

    /// <summary>
    /// Aprendizado de rateio de departamento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? aprendizado_rateio { get; set; }
    
    public ContaPagar()
    {

    }

    public ContaPagar(string? codigo_lancamento_integracao, int codigo_cliente_fornecedor, DateOnly? data_vencimento, int valor_documento, string? codigo_categoria, DateOnly? data_previsao, int id_conta_corrente)
    {
        this.codigo_lancamento_integracao = codigo_lancamento_integracao;
        this.codigo_cliente_fornecedor = codigo_cliente_fornecedor;
        this.data_vencimento = data_vencimento;
        this.valor_documento = valor_documento;
        this.codigo_categoria = codigo_categoria;
        this.data_previsao = data_previsao;
        this.id_conta_corrente = id_conta_corrente;
    }
}

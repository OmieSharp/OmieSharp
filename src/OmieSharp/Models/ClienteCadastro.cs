using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ClienteCadastro
{
    [JsonPropertyName("codigo_cliente_omie")]
    public long CodigoClienteOmie { get; set; }

    [JsonPropertyName("codigo_cliente_integracao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoClienteIntegracao { get; set; }

    [JsonPropertyName("razao_social")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? RazaoSocial { get; set; }

    [JsonPropertyName("cnpj_cpf")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CnpjCpf { get; set; }

    [JsonPropertyName("nome_fantasia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NomeFantasia { get; set; }

    [JsonPropertyName("telefone1_ddd")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone1Ddd { get; set; }

    [JsonPropertyName("telefone1_numero")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone1Numero { get; set; }

    [JsonPropertyName("contato")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Contato { get; set; }

    [JsonPropertyName("endereco")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Endereco { get; set; }

    [JsonPropertyName("endereco_numero")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? EnderecoNumero { get; set; }

    [JsonPropertyName("bairro")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Bairro { get; set; }

    [JsonPropertyName("complemento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Complemento { get; set; }

    [JsonPropertyName("estado")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Estado { get; set; }

    [JsonPropertyName("cidade")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Cidade { get; set; }

    [JsonPropertyName("cep")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Cep { get; set; }

    [JsonPropertyName("codigo_pais")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoPais { get; set; }

    [JsonPropertyName("separar_endereco")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? SepararEnderecoSN { get; set; }

    [JsonPropertyName("pesquisar_cep")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PesquisarCepSN { get; set; }

    [JsonPropertyName("telefone2_ddd")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone2Ddd { get; set; }

    [JsonPropertyName("telefone2_numero")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone2Numero { get; set; }

    [JsonPropertyName("fax_ddd")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? FaxDdd { get; set; }

    [JsonPropertyName("fax_numero")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? FaxNumero { get; set; }

    [JsonPropertyName("email")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Email { get; set; }

    [JsonPropertyName("homepage")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Homepage { get; set; }

    [JsonPropertyName("inscricao_estadual")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? InscricaoEstadual { get; set; }

    [JsonPropertyName("inscricao_municipal")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? InscricaoMunicipal { get; set; }

    [JsonPropertyName("inscricao_suframa")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? InscricaoSuframa { get; set; }

    [JsonPropertyName("optante_simples_nacional")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? OptanteSimplesNacionalSN { get; set; }

    [JsonPropertyName("tipo_atividade")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoTipoAtividade { get; set; }

    [JsonPropertyName("cnae")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Cnae { get; set; }

    [JsonPropertyName("produtor_rural")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ProdutorRuralSN { get; set; }

    [JsonPropertyName("contribuinte")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ContribuinteSN { get; set; }

    [JsonPropertyName("observacao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Observacao { get; set; }

    [JsonPropertyName("obs_detalhadas")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ObsDetalhadas { get; set; }

    [JsonPropertyName("recomendacao_atraso")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? RecomendacaoAtraso { get; set; }

    [JsonPropertyName("tags")]
    public List<Tag>? Tags { get; set; }

    [JsonPropertyName("pessoa_fisica")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PessoaFisicaSN { get; set; }

    [JsonPropertyName("exterior")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ExteriorSN { get; set; }

    [JsonPropertyName("logradouro")]
    public string? Logradouro { get; set; }

    [JsonPropertyName("importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ImportadoApiSN { get; set; }

    [JsonPropertyName("bloqueado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloqueadoSN { get; set; }

    [JsonPropertyName("cidade_ibge")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CidadeIbge { get; set; }

    [JsonPropertyName("valor_limite_credito")]
    public decimal ValorLimiteCredito { get; set; }

    [JsonPropertyName("bloquear_faturamento")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloquearFaturamentoSN { get; set; }

    /// <summary>
    /// NIF - Número de Identificação Fiscal (Apenas para estrangeiros)
    /// </summary>
    [JsonPropertyName("nif")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Nif { get; set; }

    [JsonPropertyName("documento_exterior")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DocumentoExterior { get; set; }

    [JsonPropertyName("inativo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? InativoSN { get; set; }

    [JsonPropertyName("bloquear_exclusao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloquearExclusaoSN { get; set; }

    [JsonPropertyName("recomendacoes")]
    public Recomendacoes? Recomendacoes { get; set; }

    [JsonPropertyName("enderecoEntrega")]
    public EnderecoEntrega? EnderecoEntrega { get; set; }

    [JsonPropertyName("dadosBancarios")]
    public DadosBancarios? DadosBancarios { get; set; }

    [JsonPropertyName("caracteristicas")]
    public List<Caracteristica>? Caracteristicas { get; set; }

    [JsonPropertyName("info")]
    public Info? Info { get; set; }
}

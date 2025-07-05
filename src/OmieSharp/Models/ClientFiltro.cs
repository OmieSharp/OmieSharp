using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ClientFiltro
{
    [JsonPropertyName("codigo_cliente_omie")]
    public long? CodigoClienteOmie { get; set; }

    [JsonPropertyName("codigo_cliente_integracao")]
    public string? CodigoClienteIntegracao { get; set; }

    [JsonPropertyName("cnpj_cpf")]
    public string? CnpjCpf { get; set; }

    [JsonPropertyName("razao_social")]
    public string? RazaoSocial { get; set; }

    [JsonPropertyName("nome_fantasia")]
    public string? NomeFantasia { get; set; }

    [JsonPropertyName("endereco")]
    public string? Endereco { get; set; }

    [JsonPropertyName("bairro")]
    public string? Bairro { get; set; }

    [JsonPropertyName("cidade")]
    public string? Cidade { get; set; }

    [JsonPropertyName("estado")]
    public string? Estado { get; set; }

    [JsonPropertyName("cep")]
    public string? Cep { get; set; }

    [JsonPropertyName("contato")]
    public string? Contato { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("homepage")]
    public string? Homepage { get; set; }

    [JsonPropertyName("inscricao_municipal")]
    public string? InscricaoMunicipal { get; set; }

    [JsonPropertyName("inscricao_estadual")]
    public string? InscricaoEstadual { get; set; }

    [JsonPropertyName("inscricao_suframa")]
    public string? InscricaoSuframa { get; set; }

    [JsonPropertyName("pessoa_fisica")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PessoaFisicaSN { get; set; }

    [JsonPropertyName("optante_simples_nacional")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? OptanteSimplesNacionalSN { get; set; }

    [JsonPropertyName("inativo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? InativoSN { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class EnderecoEntrega
{
    [JsonPropertyName("entBairro")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Bairro { get; set; }

    [JsonPropertyName("entCEP")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CEP { get; set; }

    [JsonPropertyName("entCidade")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Cidade { get; set; }

    [JsonPropertyName("entEndereco")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Endereco { get; set; }

    [JsonPropertyName("entEstado")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Estado { get; set; }

    [JsonPropertyName("entIE")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? IE { get; set; }

    [JsonPropertyName("entRazaoSocial")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? RazaoSocial { get; set; }

    [JsonPropertyName("entTelefone")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone { get; set; }
}

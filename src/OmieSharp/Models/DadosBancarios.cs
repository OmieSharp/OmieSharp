using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class DadosBancarios
{
    [JsonPropertyName("agencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Agencia { get; set; }

    [JsonPropertyName("codigo_banco")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoBanco { get; set; }

    [JsonPropertyName("conta_corrente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ContaCorrente { get; set; }

    [JsonPropertyName("doc_titular")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DocTitular { get; set; }

    [JsonPropertyName("nome_titular")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NomeTitular { get; set; }

    [JsonPropertyName("transf_padrao")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? TransfPadraoSN { get; set; }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoEmail
{
    [JsonPropertyName("cEnvBoleto")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? EnvBoletoSN { get; set; }

    [JsonPropertyName("cEnvLink")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? EnvLinkSN { get; set; }

    [JsonPropertyName("cEnvRecibo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? EnvReciboSN { get; set; }

    [JsonPropertyName("cEnvViaUnica")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? EnvViaUnicaSN { get; set; }

    [JsonPropertyName("cEnviarPara")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? EnviarPara { get; set; }
}

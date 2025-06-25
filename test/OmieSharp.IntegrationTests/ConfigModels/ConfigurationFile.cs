using System.Text.Json.Serialization;

namespace OmieSharp.IntegrationTests.ConfigModels;

internal class ConfigurationFile
{
    [JsonPropertyName("appKey")]
    public string? AppKey { get; set; }

    [JsonPropertyName("appSecret")]
    public string? AppSecret { get; set; }

    [JsonPropertyName("codigo_cliente_omie")]
    public long codigo_cliente_omie { get; set; } = 0;

    [JsonPropertyName("codigo_lancamento_omie")]
    public long codigo_lancamento_omie { get; set; } = 0;
}

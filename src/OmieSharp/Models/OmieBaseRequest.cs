using System.Text.Json.Serialization;

namespace OmieSharp.Models;

internal class OmieBaseRequest<T>
{
    [JsonPropertyName("call")]
    public string Call { get; private set; }

    [JsonPropertyName("app_key")]
    public string AppKey { get; private set; }

    [JsonPropertyName("app_secret")]
    public string AppSecret { get; private set; }

    [JsonPropertyName("param")]
    public List<T> Param { get; private set; }

    public OmieBaseRequest(string call, string app_key, string app_secret, T param)
    {
        this.Call = call;
        this.AppKey = app_key;
        this.AppSecret = app_secret;
        this.Param = [param];
    }
}

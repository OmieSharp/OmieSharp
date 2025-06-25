using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoEmail
{
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cEnvBoleto { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cEnvLink { get; set; }
    
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cEnvRecibo { get; set; }

    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? cEnvViaUnica { get; set; }

    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cEnviarPara { get; set; }
}

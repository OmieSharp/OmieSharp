using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoEmail
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnvBoleto { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnvLink { get; set; }
        
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnvRecibo { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnvViaUnica { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnviarPara { get; set; }
    }
}

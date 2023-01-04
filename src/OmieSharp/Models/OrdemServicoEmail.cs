using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoEmail
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cEnvBoleto { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cEnvLink { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cEnvRecibo { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cEnvViaUnica { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cEnviarPara { get; set; }
    }
}

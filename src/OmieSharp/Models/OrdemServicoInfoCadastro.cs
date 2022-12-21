using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoInfoCadastro
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cAmbiente { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCancelada { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cFaturada { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cHrAlt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cHrInc { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? dDtAlt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? dDtInc { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cHrFat { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? dDtFat { get; set; }
    }
}

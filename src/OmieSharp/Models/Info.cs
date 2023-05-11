using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class Info
    {
        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? cImpAPI { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? dAlt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? dInc { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? hAlt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? hInc { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? uAlt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? uInc { get; set; }
    }
}

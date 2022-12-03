using static OmieSharp.Utils.JsonUtils;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class Info
    {
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cImpAPI { get; set; }

        public string? dAlt { get; set; }
        public string? dInc { get; set; }
        public string? hAlt { get; set; }
        public string? hInc { get; set; }
        public string? uAlt { get; set; }
        public string? uInc { get; set; }
    }
}

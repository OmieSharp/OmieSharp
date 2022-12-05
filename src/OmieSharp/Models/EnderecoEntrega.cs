using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class EnderecoEntrega
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entBairro { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entCEP { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entCidade { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entEndereco { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entEstado { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entIE { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entRazaoSocial { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? entTelefone { get; set; }
    }
}

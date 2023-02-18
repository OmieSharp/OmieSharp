using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class CadastroServicoCabecalho
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cDescricao { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodigo { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cIdTrib { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodServMun { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodLC116 { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? nIdNBS { get; set; }

        public decimal nPrecoUnit { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodCateg { get; set; }
    }
}

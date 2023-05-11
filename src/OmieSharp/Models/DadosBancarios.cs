using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class DadosBancarios
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? agencia { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? codigo_banco { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? conta_corrente { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? doc_titular { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? nome_titular { get; set; }
        
        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? transf_padrao { get; set; }
    }
}

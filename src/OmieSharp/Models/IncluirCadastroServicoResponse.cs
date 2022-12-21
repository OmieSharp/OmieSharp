using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class IncluirCadastroServicoResponse
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string cCodIntServ { get; set; }

        public long nCodServ { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string cCodStatus { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string cDescStatus { get; set; }
    }
}

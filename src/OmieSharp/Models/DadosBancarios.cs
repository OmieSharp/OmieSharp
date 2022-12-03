using static OmieSharp.Utils.JsonUtils;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class DadosBancarios
    {
        public string? agencia { get; set; }
        public string? codigo_banco { get; set; }
        public string? conta_corrente { get; set; }
        public string? doc_titular { get; set; }
        public string? nome_titular { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? transf_padrao { get; set; }
    }
}

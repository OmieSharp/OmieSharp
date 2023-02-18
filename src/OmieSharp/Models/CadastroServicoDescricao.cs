using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class CadastroServicoDescricao
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cDescrCompleta { get; set; }
    }
}

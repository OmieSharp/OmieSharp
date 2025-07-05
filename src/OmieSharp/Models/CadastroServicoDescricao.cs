using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class CadastroServicoDescricao
{
    [JsonPropertyName("cDescrCompleta")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DescrCompleta { get; set; }
}

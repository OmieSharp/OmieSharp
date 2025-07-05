using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Caracteristica
{
    [JsonPropertyName("campo")]
    public string Campo { get; set; }

    [JsonPropertyName("conteudo")]
    public string Conteudo { get; set; }

    public Caracteristica(string campo, string conteudo)
    {
        this.Campo = campo;
        this.Conteudo = conteudo;
    }
}

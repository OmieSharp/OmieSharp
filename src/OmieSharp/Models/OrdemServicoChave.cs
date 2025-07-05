using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoChave
{
    [JsonPropertyName("cCodIntOS")]
    public string? CodIntOS { get; private set; }

    [JsonPropertyName("nCodOS")]
    public int? CodOS { get; private set; }

    [JsonPropertyName("cNumOS")]
    public string? NumOS { get; private set; }

    [JsonConstructor]
    public OrdemServicoChave(string? cCodIntOS = null, int? nCodOS = null, string? cNumOS = null)
    {
        this.CodIntOS = cCodIntOS;
        this.CodOS = nCodOS;
        this.NumOS = cNumOS;
    }

    public OrdemServicoChave(string cCodIntOS)
    {
        this.CodIntOS = cCodIntOS;
    }

    public OrdemServicoChave(int nCodOS)
    {
        this.CodOS = nCodOS;
    }
}

using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoChave
{
    public string? cCodIntOS { get; private set; }
    public int? nCodOS { get; private set; }
    public string? cNumOS { get; private set; }

    [JsonConstructor]
    public OrdemServicoChave(string? cCodIntOS = null, int? nCodOS = null, string? cNumOS = null)
    {
        this.cCodIntOS = cCodIntOS;
        this.nCodOS = nCodOS;
        this.cNumOS = cNumOS;
    }

    public OrdemServicoChave(string cCodIntOS)
    {
        this.cCodIntOS = cCodIntOS;
    }

    public OrdemServicoChave(int nCodOS)
    {
        this.nCodOS = nCodOS;
    }
}

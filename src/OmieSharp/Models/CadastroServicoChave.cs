using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class CadastroServicoChave
{
    [JsonPropertyName("cCodIntServ")]
    public string? CodIntServ { get; private set; }

    [JsonPropertyName("nCodServ")]
    public long? CodServ { get; private set; }

    public CadastroServicoChave(string cCodIntServ)
    {
        this.CodIntServ = cCodIntServ;
    }

    public CadastroServicoChave(long nCodServ)
    {
        this.CodServ = nCodServ;
    }

    [JsonConstructor]
    public CadastroServicoChave(string? codIntServ, long? codServ)
    {
        this.CodIntServ = codIntServ;
        this.CodServ = codServ;
    }   
}

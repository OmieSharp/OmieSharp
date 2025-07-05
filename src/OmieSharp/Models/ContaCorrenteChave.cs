using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaCorrenteChave
{
    [JsonPropertyName("cCodCCInt")]
    public string? CodCCInt { get; private set; }

    [JsonPropertyName("nCodCC")]
    public long? CodCC { get; private set; }
    
    [JsonConstructor]
    public ContaCorrenteChave(string? cCodCCInt = null, long? nCodCC = null)
    {
        this.CodCCInt = cCodCCInt;
        this.CodCC = nCodCC;
    }

    public ContaCorrenteChave(string cCodCCInt)
    {
        this.CodCCInt = cCodCCInt;
    }

    public ContaCorrenteChave(long nCodCC)
    {
        this.CodCC = nCodCC;
    }
}

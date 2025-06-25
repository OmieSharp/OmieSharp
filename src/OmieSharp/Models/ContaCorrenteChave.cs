using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaCorrenteChave
{
    public string? cCodCCInt { get; private set; }
    public long? nCodCC { get; private set; }
    
    [JsonConstructor]
    public ContaCorrenteChave(string? cCodCCInt = null, long? nCodCC = null)
    {
        this.cCodCCInt = cCodCCInt;
        this.nCodCC = nCodCC;
    }

    public ContaCorrenteChave(string cCodCCInt)
    {
        this.cCodCCInt = cCodCCInt;
    }

    public ContaCorrenteChave(long nCodCC)
    {
        this.nCodCC = nCodCC;
    }
}

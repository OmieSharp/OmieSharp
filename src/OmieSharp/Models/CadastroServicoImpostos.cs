using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class CadastroServicoImpostos
{
    [JsonPropertyName("nAliqISS")]
    public decimal AliqIss { get; set; }

    [JsonPropertyName("cRetISS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetIssSN { get; set; }

    [JsonPropertyName("nAliqPIS")]
    public decimal AliqPis { get; set; }

    [JsonPropertyName("cRetPIS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetPisSN { get; set; }

    [JsonPropertyName("nAliqCOFINS")]
    public decimal AliqCofins { get; set; }
    
    [JsonPropertyName("cRetCOFINS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetCofinsSN { get; set; }

    [JsonPropertyName("nAliqCSLL")]
    public decimal AliqCsll { get; set; }

    [JsonPropertyName("cRetCSLL")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetCsllSN { get; set; }

    [JsonPropertyName("nAliqIR")]
    public decimal AliqIr { get; set; }

    [JsonPropertyName("cRetIR")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetIrSN { get; set; }

    [JsonPropertyName("nAliqINSS")]
    public decimal AliqInss { get; set; }

    [JsonPropertyName("cRetINSS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetInssSN { get; set; }

    [JsonPropertyName("nRedBaseINSS")]
    public decimal RedBaseInss { get; set; }

    [JsonPropertyName("nRedBaseCOFINS")]
    public decimal RedBaseCofinsSN { get; set; }

    [JsonPropertyName("nRedBasePIS")]
    public decimal RedBasePis { get; set; }

    [JsonPropertyName("lDeduzISS")]
    public bool DeduzIssSN { get; set; }
}

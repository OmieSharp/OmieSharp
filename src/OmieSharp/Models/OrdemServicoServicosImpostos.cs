using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoServicosImpostos
{
    [JsonPropertyName("cFixarCOFINS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarCofinsSN { get; set; }

    [JsonPropertyName("cFixarCSLL")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarCsllSN { get; set; }

    [JsonPropertyName("cFixarINSS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarInssSN { get; set; }

    [JsonPropertyName("cFixarIRRF")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarIrrfSN { get; set; }

    [JsonPropertyName("cFixarISS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarIssSN { get; set; }

    [JsonPropertyName("cFixarPIS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? FixarPisSN { get; set; }

    [JsonPropertyName("cRetemCOFINS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCofinsSN { get; set; }

    [JsonPropertyName("cRetemCSLL")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemCsllSN { get; set; }

    [JsonPropertyName("cRetemINSS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemInssSN { get; set; }

    [JsonPropertyName("cRetemIRRF")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemIrrfSN { get; set; }

    [JsonPropertyName("cRetemPIS")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? RetemPisSN { get; set; }

    [JsonPropertyName("lDeduzISS")]
    public bool DeduzIssSN { get; set; }

    [JsonPropertyName("nAliqCOFINS")]
    public decimal AliqCofins { get; set; }

    [JsonPropertyName("nAliqCSLL")]
    public decimal AliqCsll { get; set; }

    [JsonPropertyName("nAliqINSS")]
    public decimal AliqInss { get; set; }

    [JsonPropertyName("nAliqIRRF")]
    public decimal AliqIrrf { get; set; }

    [JsonPropertyName("nAliqISS")]
    public decimal AliqIss { get; set; }

    [JsonPropertyName("nAliqPIS")]
    public decimal AliqPis { get; set; }

    [JsonPropertyName("nAliqRedBaseCOFINS")]
    public decimal AliqRedBaseCofins { get; set; }

    [JsonPropertyName("nAliqRedBaseINSS")]
    public decimal AliqRedBaseInss { get; set; }

    [JsonPropertyName("nAliqRedBasePIS")]
    public decimal AliqRedBasePis { get; set; }

    [JsonPropertyName("nBaseISS")]
    public decimal BaseIss { get; set; }

    [JsonPropertyName("nTotDeducao")]
    public decimal TotDeducao { get; set; }

    [JsonPropertyName("nValorCOFINS")]
    public decimal ValorCofins { get; set; }

    [JsonPropertyName("nValorCSLL")]
    public decimal ValorCsll { get; set; }

    [JsonPropertyName("nValorINSS")]
    public decimal ValorInss { get; set; }

    [JsonPropertyName("nValorIRRF")]
    public decimal ValorIrrf { get; set; }

    [JsonPropertyName("nValorISS")]
    public decimal ValorIss { get; set; }

    [JsonPropertyName("nValorPIS")]
    public decimal ValorPis { get; set; }
}

using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServicoInformacoesAdicionais
{
    [JsonPropertyName("cCidPrestServ")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CidPrestServ { get; set; }

    [JsonPropertyName("cCodCateg")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodCateg { get; set; }

    [JsonPropertyName("cDadosAdicNF")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DadosAdicNF { get; set; }

    [JsonPropertyName("nCodCC")]
    public long? CodCC { get; set; }
}

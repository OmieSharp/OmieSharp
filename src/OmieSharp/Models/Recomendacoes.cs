using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Recomendacoes
{
    [JsonPropertyName("codigo_transportadora")]
    public int CodigoTransportadora { get; set; }

    [JsonPropertyName("gerar_boletos")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? GerarBoletosSN { get; set; }

    [JsonPropertyName("codigo_vendedor")]
    public int? CodigoVendedor { get; set; }

    [JsonPropertyName("email_fatura")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? EmailFatura { get; set; }

    [JsonPropertyName("numero_parcelas")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroParcelas { get; set; }
}

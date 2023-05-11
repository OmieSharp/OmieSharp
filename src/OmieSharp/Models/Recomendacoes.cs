using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class Recomendacoes
    {
        public int codigo_transportadora { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? gerar_boletos { get; set; }

        public int? codigo_vendedor { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? email_fatura { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? numero_parcelas { get; set; }
    }
}

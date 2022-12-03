using static OmieSharp.Utils.JsonUtils;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class Recomendacoes
    {
        public int codigo_transportadora { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? gerar_boletos { get; set; }

        public int? codigo_vendedor { get; set; }
        public string? email_fatura { get; set; }
        public string? numero_parcelas { get; set; }
    }
}

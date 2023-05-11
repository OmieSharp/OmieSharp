using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class Boleto
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cGerado { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cNumBancario { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cNumBoleto { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? dDtEmBol { get; set; }

        public int nPerJuros { get; set; }

        public int nPerMulta { get; set; }
    }
}

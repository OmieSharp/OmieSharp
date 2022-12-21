using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class OrdemServicoInformacoesAdicionais
    {
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCidPrestServ { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodCateg { get; set; }

        public long? nCodCC { get; set; }
    }
}

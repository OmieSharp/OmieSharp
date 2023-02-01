using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class CadastroServicoImpostos
    {
        public decimal nAliqISS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetISS { get; set; }

        public decimal nAliqPIS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetPIS { get; set; }

        public decimal nAliqCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetCOFINS { get; set; }

        public decimal nAliqCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetCSLL { get; set; }

        public decimal nAliqIR { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetIR { get; set; }

        public decimal nAliqINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetINSS { get; set; }

        public decimal nRedBaseINSS { get; set; }

        public decimal nRedBaseCOFINS { get; set; }

        public decimal nRedBasePIS { get; set; }
        
        public bool lDeduzISS { get; set; }
    }
}

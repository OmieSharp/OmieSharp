using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class CadastroServicoImpostos
    {
        public int nAliqISS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetISS { get; set; }

        public int nAliqPIS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetPIS { get; set; }

        public int nAliqCOFINS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetCOFINS { get; set; }

        public int nAliqCSLL { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetCSLL { get; set; }

        public int nAliqIR { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetIR { get; set; }

        public int nAliqINSS { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? cRetINSS { get; set; }

        public int nRedBaseINSS { get; set; }

        public int nRedBaseCOFINS { get; set; }

        public int nRedBasePIS { get; set; }
        
        public bool lDeduzISS { get; set; }
    }
}

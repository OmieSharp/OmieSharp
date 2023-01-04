using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ListarContaCorrenteRequest
    {
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? apenas_importado_api { get; set; }

        public long? codigo { get; set; }
        public string? codigo_integracao { get; set; }
        public string? ordenar_por { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? ordem_decrescente { get; set; }

        public string? filtrar_por_data_de { get; set; }
        public string? filtrar_por_data_ate { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? filtrar_apenas_inclusao { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? filtrar_apenas_alteracao { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? filtrar_apenas_ativo { get; set; }

        public ListarContaCorrenteRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
        {
            this.pagina = pagina;
            this.registros_por_pagina = registros_por_pagina;
            this.apenas_importado_api = apenas_importado_api;
        }
    }
}

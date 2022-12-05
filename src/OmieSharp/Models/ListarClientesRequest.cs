using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ListarClientesRequest
    {
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? apenas_importado_api { get; set; }

        public string? ordenar_por { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? ordem_decrescente { get; set; }

        public string? filtrar_por_data_de { get; set; }
        public string? filtrar_por_data_ate { get; set; }
        public string? filtrar_por_hora_de { get; set; }
        public string? filtrar_por_hora_ate { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? filtrar_apenas_alteracao { get; set; }

        public ClientFiltro? clientesFiltro { get; set; }

        public List<string>? clientesPorCodigo { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? exibir_caracteristicas { get; set; }

        public ListarClientesRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
        {
            this.pagina = pagina;
            this.registros_por_pagina = registros_por_pagina;
            this.apenas_importado_api = apenas_importado_api;
        }
    }
}

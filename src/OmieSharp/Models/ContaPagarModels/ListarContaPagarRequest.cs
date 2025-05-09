using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels
{
    public class ListarContaPagarRequest
    {
        public int pagina { get; set; }
        public int registros_por_pagina { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? apenas_importado_api { get; set; }

        public string? ordenar_por { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? ordem_decrescente { get; set; }


        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_data_de { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_data_ate { get; set; }


        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? filtrar_apenas_inclusao { get; set; }


        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_emissao_de { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_emissao_ate { get; set; }


        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_registro_de { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? filtrar_por_registro_ate { get; set; }

        public long? filtrar_conta_corrente { get; set; }
        public long? filtrar_cliente { get; set; }
        public string? filtrar_por_cpf_cnpj { get; set; }
        public string? filtrar_por_status { get; set; }
        public long? filtrar_por_projeto { get; set; }
        public long? filtrar_por_vendedor { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? exibir_obs { get; set; }

        public ListarContaPagarRequest(int pagina = 1, int registros_por_pagina = 50, bool apenas_importado_api = false)
        {
            this.pagina = pagina;
            this.registros_por_pagina = registros_por_pagina;
            this.apenas_importado_api = apenas_importado_api;
        }
    }
}

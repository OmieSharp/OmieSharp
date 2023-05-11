using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ContaCorrente
    {
        public long nCodCC { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cCodCCInt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? tipo_conta_corrente { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? codigo_banco { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? descricao { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? codigo_agencia { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? numero_conta_corrente { get; set; }

        public decimal saldo_inicial { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? bloqueado { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? bol_instr1 { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? bol_sn { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? cobr_sn { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? data_alt { get; set; }

        [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
        public DateOnly? data_inc { get; set; }

        [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
        public TimeOnly? hora_alt { get; set; }

        [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
        public TimeOnly? hora_inc { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? importado_api { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? inativo { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? nao_fluxo { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? nao_resumo { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? pdv_categoria { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? pdv_enviar { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? pdv_sincr_analitica { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? pix_sn { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? tipo { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? user_alt { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? user_inc { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? modalidade { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? nome_gerente { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? telefone { get; set; }

        public decimal? valor_limite { get; set; }
    }
}

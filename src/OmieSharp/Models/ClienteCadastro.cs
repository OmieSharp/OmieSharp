using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ClienteCadastro
    {
        public long codigo_cliente_omie { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? codigo_cliente_integracao { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? razao_social { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cnpj_cpf { get; set; }
        
        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? nome_fantasia { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? telefone1_ddd { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? telefone1_numero { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? contato { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? endereco { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? endereco_numero { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? bairro { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? complemento { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? estado { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cidade { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cep { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? codigo_pais { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? separar_endereco { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? pesquisar_cep { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? telefone2_ddd { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? telefone2_numero { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? fax_ddd { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? fax_numero { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? email { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? homepage { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? inscricao_estadual { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? inscricao_municipal { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? inscricao_suframa { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? optante_simples_nacional { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? tipo_atividade { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cnae { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? produtor_rural { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? contribuinte { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? observacao { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? obs_detalhadas { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? recomendacao_atraso { get; set; }

        public List<Tag>? tags { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? pessoa_fisica { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? exterior { get; set; }

        public string? logradouro { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? importado_api { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? bloqueado { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? cidade_ibge { get; set; }

        public int valor_limite_credito { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? bloquear_faturamento { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? nif { get; set; }

        [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
        public string? documento_exterior { get; set; }
        
        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? inativo { get; set; }

        [JsonConverter(typeof(BooleanSNJsonConverter))]
        public bool? bloquear_exclusao { get; set; }

        public Recomendacoes? recomendacoes { get; set; }

        public EnderecoEntrega? enderecoEntrega { get; set; }

        public DadosBancarios? dadosBancarios { get; set; }

        public List<Caracteristica>? caracteristicas { get; set; }

        public Info? info { get; set; }
    }
}

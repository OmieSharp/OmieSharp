using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ClientFiltro
    {
        public long? codigo_cliente_omie { get; set; }
        public string? codigo_cliente_integracao { get; set; }
        public string? cnpj_cpf { get; set; }
        public string? razao_social { get; set; }
        public string? nome_fantasia { get; set; }
        public string? endereco { get; set; }
        public string? bairro { get; set; }
        public string? cidade { get; set; }
        public string? estado { get; set; }
        public string? cep { get; set; }
        public string? contato { get; set; }
        public string? email { get; set; }
        public string? homepage { get; set; }
        public string? inscricao_municipal { get; set; }
        public string? inscricao_estadual { get; set; }
        public string? inscricao_suframa { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? pessoa_fisica { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? optante_simples_nacional { get; set; }

        [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
        public bool? inativo { get; set; }

        public List<string>? tags { get; set; }
    }
}

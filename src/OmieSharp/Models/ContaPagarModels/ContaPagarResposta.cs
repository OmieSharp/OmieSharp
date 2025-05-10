using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ContaPagarResposta
{
    /// <summary>
    /// Código do Lançamento de Contas a Pagar 
    /// </summary>
    public long codigo_lancamento_omie { get; set; }

    /// <summary>
    /// Código de Integração do Lançamento de Contas a Pagar 
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_lancamento_integracao { get; set; }

    /// <summary>
    /// Código do Status da baixa do contas a pagar
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_status { get; set; }

    /// <summary>
    /// Descrição do Status da baixa do contas a pagar
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? descricao_status { get; set; }

    public bool Success => (codigo_status ?? "999").Equals("0");
}
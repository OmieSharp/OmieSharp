using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ContaPagarResposta
{
    /// <summary>
    /// Código do Lançamento de Contas a Pagar 
    /// </summary>
    [JsonPropertyName("codigo_lancamento_omie")]
    public long CodigoLancamentoOmie { get; set; }

    /// <summary>
    /// Código de Integração do Lançamento de Contas a Pagar 
    /// </summary>
    [JsonPropertyName("codigo_lancamento_integracao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoLancamentoIntegracao { get; set; }

    /// <summary>
    /// Código do Status da baixa do contas a pagar
    /// </summary>
    [JsonPropertyName("codigo_status")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoStatus { get; set; }

    /// <summary>
    /// Descrição do Status da baixa do contas a pagar
    /// </summary>
    [JsonPropertyName("descricao_status")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? DescricaoStatus { get; set; }

    [JsonIgnore]
    public bool Success => (CodigoStatus ?? "999").Equals("0");
}
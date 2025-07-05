using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.ContaPagar;

public class ContaPagarBaixaRealizadaOmieEvent : BaseOmieEvent
{
    [JsonPropertyName("codigo_baixa")]
    public long? CodigoBaixa { get; set; }

    [JsonPropertyName("codigo_baixa_integracao")]
    public string? CodigoBaixaIntegracao { get; set; }

    [JsonPropertyName("codigo_cliente_fornecedor")]
    public long? CodigoClienteFornecedor { get; set; }

    [JsonPropertyName("codigo_conta_corrente")]
    public long? CodigoContaCorrente { get; set; }

    [JsonPropertyName("conta_a_pagar")]
    public List<OmieSharp.Models.ContaPagarModels.ContaPagar>? ContaPagar { get; set; }

    [JsonPropertyName("data")]
    public DateTime? Data { get; set; }

    [JsonPropertyName("data_cred")]
    public DateTime? DataCred { get; set; }

    [JsonPropertyName("desconto")]
    public long? Desconto { get; set; }

    [JsonPropertyName("juros")]
    public long? Juros { get; set; }

    [JsonPropertyName("multa")]
    public long? Multa { get; set; }

    [JsonPropertyName("observacao")]
    public string? Observacao { get; set; }

    [JsonPropertyName("tarifa")]
    public int? Tarifa { get; set; }

    [JsonPropertyName("valor")]
    public long? Valor { get; set; }
}

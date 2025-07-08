using System.Text.Json.Serialization;

namespace OmieSharp.Events.Body.ContaPagar;

public class ContaPagarReference
{
    [JsonPropertyName("codigo_lancamento_integracao")]
    public string? CodigoLancamentoIntegracao { get; set; }

    [JsonPropertyName("codigo_lancamento_omie")]
    public long CodigoLancamentoOmie { get; set; }

    [JsonPropertyName("data_emissao")]
    public DateTime DataEmissao { get; set; }

    [JsonPropertyName("data_entrada")]
    public DateTime DataEntrada { get; set; }

    [JsonPropertyName("data_vencimento")]
    public DateTime DataVencimento { get; set; }

    [JsonPropertyName("numero_documento")]
    public string? NumeroDocumento { get; set; }

    [JsonPropertyName("numero_documento_fiscal")]
    public string? NumeroDocumentoFiscal { get; set; }

    [JsonPropertyName("numero_parcela")]
    public string? NumeroParcela { get; set; }

    [JsonPropertyName("valor_documento")]
    public decimal ValorDocumento { get; set; }
}

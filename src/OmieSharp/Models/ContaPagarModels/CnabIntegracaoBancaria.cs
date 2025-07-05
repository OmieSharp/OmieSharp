using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class CnabIntegracaoBancaria
{
    /// <summary>
    /// Código da Forma de Pagamento
    /// </summary>
    [JsonPropertyName("codigo_forma_pagamento")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoFormaPagamento { get; set; }

    /// <summary>
    /// Código do Banco para Transferência Bancária
    /// </summary>
    [JsonPropertyName("banco_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? BancoTransferencia { get; set; }

    /// <summary>
    /// Número da Agência para Transferência Bancária
    /// </summary>
    [JsonPropertyName("agencia_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? AgenciaTransferencia { get; set; }

    /// <summary>
    /// Número da Conta Corrente para Transferência Bancária
    /// </summary>
    [JsonPropertyName("conta_corrente_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ContaCorrenteTransferencia { get; set; }

    /// <summary>
    /// Finalidade da transferência
    /// </summary>
    [JsonPropertyName("finalidade_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? FinalidadeTransferencia { get; set; }

    /// <summary>
    /// CNPJ ou CPF do Titular
    /// </summary>
    [JsonPropertyName("cpf_cnpj_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CpfCnpjTransferencia { get; set; }

    /// <summary>
    /// Nome do Titular da Conta Corrente
    /// </summary>
    [JsonPropertyName("nome_transferencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NomeTransferencia { get; set; }

    /// <summary>
    /// Código de Barras (de Cobrança Bancária, de Concessionária ou de Impostos)
    /// </summary>
    [JsonPropertyName("codigo_barras_boleto")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoBarrasBoleto { get; set; }

    /// <summary>
    /// Percentual de Juros ao Mês do Boleto
    /// </summary>
    [JsonPropertyName("juros_boleto")]
    public decimal? JurosBoleto { get; set; }

    /// <summary>
    /// Percentual de Multa por Atraso do Boleto
    /// </summary>
    [JsonPropertyName("multa_boleto")]
    public decimal? MultaBoleto { get; set; }

    /// <summary>
    /// QR Code do PIX
    /// </summary>
    [JsonPropertyName("pix_qrcode")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? PixQrcode { get; set; }
}
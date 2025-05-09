using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class CnabIntegracaoBancaria
{
    /// <summary>
    /// Código da Forma de Pagamento
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_forma_pagamento { get; set; }

    /// <summary>
    /// Código do Banco para Transferência Bancária
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? banco_transferencia { get; set; }

    /// <summary>
    /// Número da Agência para Transferência Bancária
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? agencia_transferencia { get; set; }

    /// <summary>
    /// Número da Conta Corrente para Transferência Bancária
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? conta_corrente_transferencia { get; set; }

    /// <summary>
    /// Finalidade da transferência
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? finalidade_transferencia { get; set; }

    /// <summary>
    /// CNPJ ou CPF do Titular
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cpf_cnpj_transferencia { get; set; }

    /// <summary>
    /// Nome do Titular da Conta Corrente
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? nome_transferencia { get; set; }

    /// <summary>
    /// Código de Barras (de Cobrança Bancária, de Concessionária ou de Impostos)
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? codigo_barras_boleto { get; set; }

    /// <summary>
    /// Percentual de Juros ao Mês do Boleto
    /// </summary>
    public decimal juros_boleto { get; set; }

    /// <summary>
    /// Percentual de Multa por Atraso do Boleto
    /// </summary>
    public decimal multa_boleto { get; set; }

    /// <summary>
    /// QR Code do PIX
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? pix_qrcode { get; set; }

}
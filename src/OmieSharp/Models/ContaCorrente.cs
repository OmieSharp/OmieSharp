using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ContaCorrente
{
    [JsonPropertyName("nCodCC")]
    public long CodCC { get; set; }

    [JsonPropertyName("cCodCCInt")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodCCInt { get; set; }

    [JsonPropertyName("tipo_conta_corrente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? TipoContaCorrente { get; set; }

    [JsonPropertyName("codigo_banco")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoBanco { get; set; }

    [JsonPropertyName("descricao")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Descricao { get; set; }

    [JsonPropertyName("codigo_agencia")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? CodigoAgencia { get; set; }

    [JsonPropertyName("numero_conta_corrente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NumeroContaCorrente { get; set; }

    [JsonPropertyName("saldo_inicial")]
    public decimal SaldoInicial { get; set; }

    [JsonPropertyName("bloqueado")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BloqueadoSN { get; set; }

    [JsonPropertyName("bol_instr1")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? BolInstr1 { get; set; }

    [JsonPropertyName("bol_sn")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? BolSN { get; set; }

    [JsonPropertyName("cobr_sn")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? CobrSN { get; set; }

    [JsonPropertyName("data_alt")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataAlt { get; set; }

    [JsonPropertyName("data_inc")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataInc { get; set; }

    [JsonPropertyName("hora_alt")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraAlt { get; set; }

    [JsonPropertyName("hora_inc")]
    [JsonConverter(typeof(TimeOnlyNullableJsonConverter))]
    public TimeOnly? HoraInc { get; set; }

    [JsonPropertyName("importado_api")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? ImportadoApiSN { get; set; }

    [JsonPropertyName("inativo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? InativoSN { get; set; }

    [JsonPropertyName("nao_fluxo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? NaoFluxoSN { get; set; }

    [JsonPropertyName("nao_resumo")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? NaoResumoSN { get; set; }

    [JsonPropertyName("pdv_categoria")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? PdvCategoria { get; set; }

    [JsonPropertyName("pdv_enviar")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PdvEnviarSN { get; set; }

    [JsonPropertyName("pdv_sincr_analitica")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PdvSincrAnaliticaSN { get; set; }

    [JsonPropertyName("pix_sn")]
    [JsonConverter(typeof(BooleanNullableSNJsonConverter))]
    public bool? PixSN { get; set; }

    [JsonPropertyName("tipo")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Tipo { get; set; }

    [JsonPropertyName("user_alt")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? UsuarioAlt { get; set; }

    [JsonPropertyName("user_inc")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? UsuarioInc { get; set; }

    [JsonPropertyName("modalidade")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Modalidade { get; set; }

    [JsonPropertyName("nome_gerente")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? NomeGerente { get; set; }

    [JsonPropertyName("telefone")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? Telefone { get; set; }

    [JsonPropertyName("valor_limite")]
    public decimal? ValorLimite { get; set; }
}

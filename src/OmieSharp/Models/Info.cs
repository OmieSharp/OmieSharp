using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Info
{
    /// <summary>
    /// Data da Inclusão
    /// </summary>
    [JsonPropertyName("dInc")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataInc { get; set; }

    /// <summary>
    /// Hora da Inclusão
    /// </summary>
    [JsonPropertyName("hInc")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? HoraInc { get; set; }

    /// <summary>
    /// Usuário da Inclusão
    /// </summary>
    [JsonPropertyName("uInc")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? UsuarioInc { get; set; }

    /// <summary>
    /// Data da Alteração
    /// </summary>
    [JsonPropertyName("dAlt")]
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? DataAlt { get; set; }

    /// <summary>
    /// Hora da Alteração
    /// </summary>
    [JsonPropertyName("hAlt")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? HoraAlt { get; set; }

    /// <summary>
    /// Usuário da Alteração
    /// </summary>
    [JsonPropertyName("uAlt")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? UsuarioAlteracao { get; set; }

    /// <summary>
    /// Importado pela API (S/N)
    /// </summary>
    [JsonPropertyName("ImpAPI")]
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? ImpAPI { get; set; }
}

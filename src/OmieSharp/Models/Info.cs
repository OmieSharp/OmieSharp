using OmieSharp.JsonConverters;
using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class Info
{
    /// <summary>
    /// Data da Inclusão
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dInc { get; set; }

    /// <summary>
    /// Hora da Inclusão
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? hInc { get; set; }

    /// <summary>
    /// Usuário da Inclusão
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? uInc { get; set; }

    /// <summary>
    /// Data da Alteração
    /// </summary>
    [JsonConverter(typeof(DateOnlyNullableJsonConverter))]
    public DateOnly? dAlt { get; set; }

    /// <summary>
    /// Hora da Alteração
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? hAlt { get; set; }

    /// <summary>
    /// Usuário da Alteração
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? uAlt { get; set; }

    /// <summary>
    /// Importado pela API (S/N)
    /// </summary>
    [JsonConverter(typeof(EmptyToNullStringJsonConverter))]
    public string? cImpAPI { get; set; }
}

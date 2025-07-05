using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ClienteStatus
{
    [JsonPropertyName("codigo_cliente_omie")]
    public long CodigoClienteOmie { get; set; }

    [JsonPropertyName("codigo_cliente_integracao")]
    public string? CodigoClienteIntegracao { get; set; }

    /// <summary>
    /// Se o retorno for '0' significa que a solicitação foi executada com sucesso.
    //  Se o retorno for maior que '0' ocorreu algum erro durante o processamento da solicitação.
    /// O campo 'descricao_status' descreve o problema ocorrido.
    /// </summary>
    [JsonPropertyName("codigo_status")]
    public string? CodigoStatus { get; set; }

    /// <summary>
    /// Esse campo explica o resultado do campo 'codigo_status'.
    /// </summary>
    [JsonPropertyName("descricao_status")]
    public string? DescricaoStatus { get; set; }

    [JsonIgnore]
    public bool Success => (CodigoStatus ?? "999").Equals("0");
}

using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class ClienteCadastroChave
{
    [JsonPropertyName("codigo_cliente_omie")]
    public long? CodigoClienteOmie { get; private set; }

    [JsonPropertyName("codigo_cliente_integracao")]
    public string? CodigoClienteIntegracao { get; private set; }

    public ClienteCadastroChave(long codigo_cliente_omie)
    {
        this.CodigoClienteOmie = codigo_cliente_omie;
    }

    public ClienteCadastroChave(string codigo_cliente_integracao)
    {
        this.CodigoClienteIntegracao = codigo_cliente_integracao;
    }

    [JsonConstructor]
    public ClienteCadastroChave(long? codigo_cliente_omie, string? codigo_cliente_integracao)
    {
        this.CodigoClienteOmie = codigo_cliente_omie;
        this.CodigoClienteIntegracao = codigo_cliente_integracao;
    }
}

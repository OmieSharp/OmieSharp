using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels;

public class ContaPagarChave
{
    [JsonPropertyName("codigo_lancamento_omie")]
    public long? CodigoLancamentoOmie { get; private set; }

    [JsonPropertyName("codigo_lancamento_integracao")]
    public string? CodigoLancamentoIntegracao { get; private set; }
    
    [JsonConstructor]
    public ContaPagarChave(long? codigo_lancamento_omie = null, string? codigo_lancamento_integracao = null)
    {
        this.CodigoLancamentoOmie = codigo_lancamento_omie;
        this.CodigoLancamentoIntegracao = codigo_lancamento_integracao;
    }

    public ContaPagarChave(long codigo_lancamento_omie)
    {
        this.CodigoLancamentoOmie = codigo_lancamento_omie;
    }

    public ContaPagarChave(string codigo_lancamento_integracao)
    {
        this.CodigoLancamentoIntegracao = codigo_lancamento_integracao;
    }
}

using System.Text.Json.Serialization;

namespace OmieSharp.Models.ContaPagarModels
{
    public class ContaPagarChave
    {
        public long? codigo_lancamento_omie { get; private set; }
        public string? codigo_lancamento_integracao { get; private set; }
        
        [JsonConstructor]
        public ContaPagarChave(long? codigo_lancamento_omie = null, string? codigo_lancamento_integracao = null)
        {
            this.codigo_lancamento_omie = codigo_lancamento_omie;
            this.codigo_lancamento_integracao = codigo_lancamento_integracao;
        }

        public ContaPagarChave(long codigo_lancamento_omie)
        {
            this.codigo_lancamento_omie = codigo_lancamento_omie;
        }

        public ContaPagarChave(string codigo_lancamento_integracao)
        {
            this.codigo_lancamento_integracao = codigo_lancamento_integracao;
        }
    }
}

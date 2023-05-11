using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class ContaReceberChave
    {
        public long? codigo_lancamento_omie { get; private set; }
        public string? codigo_lancamento_integracao { get; private set; }

        [JsonConstructor]
        public ContaReceberChave(long? codigo_lancamento_omie = null, string ? codigo_lancamento_integracao = null)
        {
            this.codigo_lancamento_omie = codigo_lancamento_omie;
            this.codigo_lancamento_integracao = codigo_lancamento_integracao;
        }

        public ContaReceberChave(long codigo_lancamento_omie)
        {
            this.codigo_lancamento_omie = codigo_lancamento_omie;
        }

        public ContaReceberChave(string codigo_lancamento_integracao)
        {
            this.codigo_lancamento_integracao = codigo_lancamento_integracao;
        }
    }
}

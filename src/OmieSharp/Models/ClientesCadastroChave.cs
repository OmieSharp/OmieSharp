namespace OmieSharp.Models
{
    public class ClientesCadastroChave
    {
        public long? codigo_cliente_omie { get; private set; }
        public string? codigo_cliente_integracao { get; private set; }

        public ClientesCadastroChave(long codigo_cliente_omie)
        {
            this.codigo_cliente_omie = codigo_cliente_omie;
        }

        public ClientesCadastroChave(string codigo_cliente_integracao)
        {
            this.codigo_cliente_integracao = codigo_cliente_integracao;
        }
    }
}

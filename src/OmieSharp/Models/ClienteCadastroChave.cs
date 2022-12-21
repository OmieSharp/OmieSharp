namespace OmieSharp.Models
{
    public class ClienteCadastroChave
    {
        public long? codigo_cliente_omie { get; private set; }
        public string? codigo_cliente_integracao { get; private set; }

        public ClienteCadastroChave(long codigo_cliente_omie)
        {
            this.codigo_cliente_omie = codigo_cliente_omie;
        }

        public ClienteCadastroChave(string codigo_cliente_integracao)
        {
            this.codigo_cliente_integracao = codigo_cliente_integracao;
        }

        public ClienteCadastroChave(long? codigo_cliente_omie, string? codigo_cliente_integracao)
        {
            this.codigo_cliente_omie = codigo_cliente_omie;
            this.codigo_cliente_integracao = codigo_cliente_integracao;
        }
    }
}

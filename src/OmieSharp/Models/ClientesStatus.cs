namespace OmieSharp.Models
{
    public class ClientesStatus
    {
        public long codigo_cliente_omie { get; set; }

        public string? codigo_cliente_integracao { get; set; }

        /// <summary>
        /// Se o retorno for '0' significa que a solicitação foi executada com sucesso.
        //  Se o retorno for maior que '0' ocorreu algum erro durante o processamento da solicitação.
        /// O campo 'descricao_status' descreve o problema ocorrido.
        /// </summary>
        public string? codigo_status { get; set; }

        /// <summary>
        /// Esse campo explica o resultado do campo 'codigo_status'.
        /// </summary>
        public string? descricao_status { get; set; }

        public bool Success { get { return (codigo_status ?? "999").Equals("0"); } }
    }
}

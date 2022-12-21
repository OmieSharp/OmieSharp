namespace OmieSharp.Models
{
    public class ListarClienteResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ClienteCadastro>? clientes_cadastro { get; set; }

        public ListarClienteResponse()
        {
            pagina = 1;
            clientes_cadastro = new List<ClienteCadastro>();
        }
    }
}

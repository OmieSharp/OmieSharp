namespace OmieSharp.Models
{
    public class ListarClientesResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ClientesCadastro>? clientes_cadastro { get; set; }

        public ListarClientesResponse()
        {
            clientes_cadastro = new List<ClientesCadastro>();
        }
    }
}

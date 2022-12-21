namespace OmieSharp.Models
{
    public class ListarOrdemServicoResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<OrdemServico> osCadastro { get; set; }
    }
}

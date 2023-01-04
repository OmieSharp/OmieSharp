namespace OmieSharp.Models
{
    public class ListarContaCorrenteResponse
    {
        public int pagina { get; set; }
        public int total_de_paginas { get; set; }
        public int registros { get; set; }
        public int total_de_registros { get; set; }
        public List<ContaCorrente> ListarContasCorrentes { get; set; }

        public ListarContaCorrenteResponse()
        {
            pagina = 0;
            total_de_paginas = 0;
            registros = 0;
            total_de_registros = 0;
            ListarContasCorrentes = new List<ContaCorrente>();
        }
    }
}

namespace OmieSharp.Models
{
    public class ListarCadastroServicoResponse
    {
        public int nPagina { get; set; }
        public int nTotPaginas { get; set; }
        public int nRegistros { get; set; }
        public int nTotRegistros { get; set; }
        public List<CadastroServico> cadastros { get; set; }

        public ListarCadastroServicoResponse()
        {
            nPagina = 1;
            cadastros = new List<CadastroServico>();
        }
    }
}

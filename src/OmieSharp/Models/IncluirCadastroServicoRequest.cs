namespace OmieSharp.Models
{
    public class IncluirCadastroServicoRequest : CadastroServico
    {
        public CadastroServicoChave? intIncluir { get; set; }

        public IncluirCadastroServicoRequest(string cCodigo, string cCodIntServ, string cDescricao, string cDescrCompleta)
        {
            this.intIncluir = new CadastroServicoChave(cCodIntServ);

            this.cabecalho = new CadastroServicoCabecalho()
            {
                cDescricao = cDescricao,
                cCodigo = cCodigo,
            };

            this.descricao = new CadastroServicoDescricao()
            {
                cDescrCompleta = cDescrCompleta
            };

            this.impostos = new CadastroServicoImpostos();
        }
    }
}

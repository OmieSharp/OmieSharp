namespace OmieSharp.Models
{
    public class CadastroServico
    {
        public CadastroServicoChave? intListar { get; set; }

        public CadastroServicoCabecalho cabecalho { get; set; }
        public CadastroServicoDescricao descricao { get; set; }
        public CadastroServicoImpostos impostos { get; set; }

        public void FillProperties(CadastroServico cadastroServico)
        {
            this.cabecalho = cabecalho ?? new CadastroServicoCabecalho();
            this.descricao = descricao ?? new CadastroServicoDescricao();
            this.impostos = impostos ?? new CadastroServicoImpostos();
        }
    }
}

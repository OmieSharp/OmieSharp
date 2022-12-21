namespace OmieSharp.Models
{
    public class IncluirOrdemServicoRequest
    {
        public OrdemServicoCabecalho Cabecalho { get; set; }
        //public List<object> Departamentos { get; set; }
        public OrdemServicoEmail Email { get; set; }
        public OrdemServicoInformacoesAdicionais InformacoesAdicionais { get; set; }
        public List<OrdemServicoServicosPrestado> ServicosPrestados { get; set; }
    }
}

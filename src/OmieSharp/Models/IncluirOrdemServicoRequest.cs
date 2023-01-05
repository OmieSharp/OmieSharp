namespace OmieSharp.Models
{
    public class IncluirOrdemServicoRequest
    {
        public OrdemServicoCabecalho Cabecalho { get; set; }
        //public List<object> Departamentos { get; set; }
        public OrdemServicoEmail Email { get; set; }
        public Observacoes Observacoes { get; set; }
        public List<ParcelaOS> Parcelas { get; set; }
        public OrdemServicoInformacoesAdicionais InformacoesAdicionais { get; set; }
        public List<OrdemServicoServicosPrestado> ServicosPrestados { get; set; }
    }
}

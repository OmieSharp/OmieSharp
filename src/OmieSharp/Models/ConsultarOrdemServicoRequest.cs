namespace OmieSharp.Models
{
    public class ConsultarOrdemServicoRequest
    {
        public string? cCodIntOS { get; private set; }
        public int? nCodOS { get; private set; }
        public string? cNumOS { get; private set; }

        public ConsultarOrdemServicoRequest(string? cCodIntOS = null, int? nCodOS = null, string? cNumOS = null)
        {
            this.cCodIntOS = cCodIntOS;
            this.nCodOS = nCodOS;
            this.cNumOS = cNumOS;
        }

        public ConsultarOrdemServicoRequest(string cCodIntOS)
        {
            this.cCodIntOS = cCodIntOS;
        }

        public ConsultarOrdemServicoRequest(int nCodOS)
        {
            this.nCodOS = nCodOS;
        }
    }
}

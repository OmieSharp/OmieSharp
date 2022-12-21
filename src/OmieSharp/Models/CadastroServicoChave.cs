using System.Text.Json.Serialization;

namespace OmieSharp.Models
{
    public class CadastroServicoChave
    {
        public string? cCodIntServ { get; private set; }
        public long? nCodServ { get; private set; }

        public CadastroServicoChave(string cCodIntServ)
        {
            this.cCodIntServ = cCodIntServ;
        }

        public CadastroServicoChave(long nCodServ)
        {
            this.nCodServ = nCodServ;
        }

        [JsonConstructor]
        public CadastroServicoChave(string? cCodIntServ, long? nCodServ)
        {
            this.cCodIntServ = cCodIntServ;
            this.nCodServ = nCodServ;
        }   
    }
}

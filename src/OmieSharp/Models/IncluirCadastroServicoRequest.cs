using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class IncluirCadastroServicoRequest : CadastroServico
{
    [JsonPropertyName("intIncluir")]
    public CadastroServicoChave? IntIncluir { get; set; }

    public IncluirCadastroServicoRequest(string cCodigo, string cCodIntServ, string cDescricao, string? cDescrCompleta)
    {
        this.IntIncluir = new CadastroServicoChave(cCodIntServ);

        this.Cabecalho = new CadastroServicoCabecalho()
        {
            Descricao = cDescricao,
            Codigo = cCodigo
        };

        if (cDescrCompleta != null)
        {
            this.Descricao = new CadastroServicoDescricao()
            {
                DescrCompleta = cDescrCompleta
            };
        }

        this.Impostos = new CadastroServicoImpostos();
    }
}

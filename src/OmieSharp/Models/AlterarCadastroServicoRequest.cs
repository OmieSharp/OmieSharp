using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class AlterarCadastroServicoRequest : CadastroServico
{
    [JsonPropertyName("intEditar")]
    public CadastroServicoChave? ChaveEditar { get; set; }

    public AlterarCadastroServicoRequest(CadastroServicoChave chave, CadastroServico cadastroServico)
    {
        this.ChaveEditar = chave;
        this.FillProperties(cadastroServico);
    }
}

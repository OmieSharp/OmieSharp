namespace OmieSharp.Models;

public class AlterarCadastroServicoRequest : CadastroServico
{
    public CadastroServicoChave? intEditar { get; set; }

    public AlterarCadastroServicoRequest(CadastroServicoChave chave, CadastroServico cadastroServico)
    {
        this.intEditar = chave;
        this.FillProperties(cadastroServico);
    }
}

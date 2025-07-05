using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class CadastroServico
{
    [JsonPropertyName("intListar")]
    public CadastroServicoChave? Listar { get; set; }

    [JsonPropertyName("cabecalho")]
    public CadastroServicoCabecalho? Cabecalho { get; set; }

    [JsonPropertyName("descricao")]
    public CadastroServicoDescricao? Descricao { get; set; }

    [JsonPropertyName("impostos")]
    public CadastroServicoImpostos? Impostos { get; set; }

    public void FillProperties(CadastroServico cadastroServico)
    {
        this.Cabecalho = Cabecalho ?? new CadastroServicoCabecalho();
        this.Descricao = Descricao ?? new CadastroServicoDescricao();
        this.Impostos = Impostos ?? new CadastroServicoImpostos();
    }
}

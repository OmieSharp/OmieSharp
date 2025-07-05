using System.Text.Json.Serialization;

namespace OmieSharp.Models;

public class OrdemServico
{
    [JsonPropertyName("Cabecalho")]
    public OrdemServicoCabecalho? Cabecalho { get; set; }

    //public List<object> Departamentos { get; set; }

    [JsonPropertyName("Email")]
    public OrdemServicoEmail? Email { get; set; }

    [JsonPropertyName("InfoCadastro")]
    public OrdemServicoInfoCadastro? InfoCadastro { get; set; }

    [JsonPropertyName("InformacoesAdicionais")]
    public OrdemServicoInformacoesAdicionais? InformacoesAdicionais { get; set; }

    [JsonPropertyName("Observacoes")]
    public Observacoes? Observacoes { get; set; }

    [JsonPropertyName("Parcelas")]
    public List<ParcelaOS>? Parcelas { get; set; }

    [JsonPropertyName("ServicosPrestados")]
    public List<OrdemServicoServicosPrestado>? ServicosPrestados { get; set; }
}

using OmieSharp.Models;

namespace OmieSharp.IntegrationTests;

public class CadastroServicoTests : BaseTest
{
    private readonly OmieSharpClient _omieSharpClient;
    
    public CadastroServicoTests()
    {
        _omieSharpClient = GetOmieSharpClient();
    }

    [Fact]
    public async Task ListarCadastroServicoAsync_Success()
    {
        var request = new ListarCadastroServicoRequest();
        var response = await _omieSharpClient.ListarCadastroServicoAsync(request);
        Assert.NotEmpty(response.cadastros);
    }

    [Fact]
    public async Task ListarCadastroServicoAsync_NotFound()
    {
        var request = new ListarCadastroServicoRequest() { cCodigo = "999999999" };
        var response = await _omieSharpClient.ListarCadastroServicoAsync(request);
        Assert.Equal(0, response.nTotRegistros);
    }

    [Fact]
    public async Task ConsultarCadastroServicoAsync_NotFound()
    {
        var chave = new CadastroServicoChave(99999999999);
        var response = await _omieSharpClient.ConsultarCadastroServicoAsync(chave);
        Assert.Null(response);
    }

    [Fact]
    public async Task IncluirAlterarCadastroServicoAsync_Success()
    {
        var descricaoCompleta = $"Descrição do serviço TesteOmieSharp - {DateTime.Now:yyyy-MM-dd HH:mm:ss}";

        var chave = new CadastroServicoChave(Constants.SERVICO_CODIGO_INTEGRACAO);
        var cadastroServicoExistente = await _omieSharpClient.ConsultarCadastroServicoAsync(chave);
        
        if (cadastroServicoExistente == null)
        {
            var descricao = "Serviço TesteOmieSharp 001";
            
            var request = new IncluirCadastroServicoRequest(Constants.SERVICO_CODIGO_INTEGRACAO, Constants.SERVICO_CODIGO_INTEGRACAO, descricao, null);
            var response = await _omieSharpClient.IncluirCadastroServicoAsync(request);

            Assert.Equal("0", response.cCodStatus);
        }
        else
        {
            cadastroServicoExistente.descricao.cDescrCompleta = descricaoCompleta;

            var request = new AlterarCadastroServicoRequest(chave, cadastroServicoExistente);
            var response = await _omieSharpClient.AlterarCadastroServicoAsync(request);

            Assert.Equal("0", response.cCodStatus);
        }
    }
}
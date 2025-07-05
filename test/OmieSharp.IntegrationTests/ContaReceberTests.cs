using OmieSharp.IntegrationTests.ConfigModels;
using OmieSharp.Models;

namespace OmieSharp.IntegrationTests;

public class ContaReceberTests : BaseTest
{
    private readonly OmieSharpClient _omieSharpClient;
    private readonly ConfigurationFile _configurationFile;

    public ContaReceberTests()
    {
        _omieSharpClient = GetOmieSharpClient();
        _configurationFile = GetConfigurationFile();
    }

    [Fact]
    public async Task ConsultarContaReceberAsync_Success()
    {
        var codigo_lancamento_omie = _configurationFile.codigo_lancamento_omie;

        var request = new ContaReceberChave(codigo_lancamento_omie);
        var response = await _omieSharpClient.ConsultarContaReceberAsync(request);
        Assert.NotNull(response);
        Assert.Equal(codigo_lancamento_omie, response.CodigoLancamentoOmie);
    }

    [Fact]
    public async Task ConsultarContaReceberAsync_Notfound()
    {
        var request = new ContaReceberChave(99999999999);
        var response = await _omieSharpClient.ConsultarContaReceberAsync(request);
        Assert.Null(response);
    }
}

using OmieSharp.Models;
using OmieSharp.Models.ContaPagarModels;

namespace OmieSharp.IntegrationTests;

public class ContaPagarTests : BaseTest
{
    private readonly OmieSharpClient _omieSharpClient;
    //private readonly ConfigurationFile _configurationFile;

    public ContaPagarTests()
    {
        _omieSharpClient = GetOmieSharpClient();
        //_configurationFile = GetConfigurationFile();
    }

    [Fact]
    public async Task ListarContaPagarAsync_Success()
    {
        var request = new ListarContaPagarRequest();
        var response = await _omieSharpClient.ListarContaPagarAsync(request);
        Assert.NotEmpty(response.ContaPagarCadastro);
    }

    [Fact]
    public async Task ListarContaPagarAsync_Notfound()
    {
        var request = new ListarContaPagarRequest() { FiltrarPorProjeto = 99999999999 };
        var response = await _omieSharpClient.ListarContaPagarAsync(request);
        Assert.Empty(response.ContaPagarCadastro);
    }

    [Fact]
    public async Task ConsultarContaPagarAsync_Notfound()
    {
        var request = new ContaPagarChave("99999999999");
        var response = await _omieSharpClient.ConsultarContaPagarAsync(request);
        Assert.Null(response);
    }

    [Fact]
    public async Task IncluirConsultarAlterarExcluirContaPagar_Success()
    {
        var chaveClienteCadastro = new ClienteCadastroChave(Constants.CLIENTE_CODIGO_INTEGRACAO);
        var cliente = await _omieSharpClient.ConsultarClienteAsync(chaveClienteCadastro);
        if (cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");

        var chaveContaCorrente = new ContaCorrenteChave(Constants.CONTA_CORRENTE_CODIGO_INTEGRACAO);
        var contaCorrente = await _omieSharpClient.ConsultarContaCorrenteAsync(chaveContaCorrente);
        if (contaCorrente == null)
            throw new InvalidOperationException("Conta Corrente não encontrada");

        var codigoIntegracao = $"{DateTime.Now:yyyyMMdd-HHmmss}";
        var now = DateTime.Now.Date;
        var dataPrevisao = DateOnly.FromDateTime(now.AddDays(15));


        //-- Inclusão

        var request = new ContaPagar()
        {
            CodigoLancamentoIntegracao = codigoIntegracao,
            CodigoClienteFornecedor = cliente.CodigoClienteOmie,
            DataVencimento = dataPrevisao,
            ValorDocumento = 120.50M,
            CodigoCategoria = "2.04.01",
            DataPrevisao = dataPrevisao,
            IdContaCorrente = contaCorrente.CodCC
        };
        var responseInclusao = await _omieSharpClient.IncluirContaPagarAsync(request);
        var codigoOmie = responseInclusao.CodigoLancamentoOmie;

        Assert.Equal("0", responseInclusao.CodigoStatus);
        Assert.Equal(codigoIntegracao, responseInclusao.CodigoLancamentoIntegracao);


        //-- Consultar inclusão

        var chaveContaPagar = new ContaPagarChave(codigoIntegracao);
        var contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(chaveContaPagar);

        Assert.NotNull(contaApagar);
        Assert.Equal(codigoIntegracao, contaApagar.CodigoLancamentoIntegracao);
        Assert.Equal(codigoOmie, contaApagar.CodigoLancamentoOmie);


        //-- Alteração

        var observacao = $"Teste de alteração {DateTime.Now:yyyy-MM-dd-HH:mm:ss}";
        contaApagar.Observacao = observacao;

        var responseAlteracao = await _omieSharpClient.AlterarContaPagarAsync(contaApagar);
        Assert.Equal("0", responseAlteracao.CodigoStatus);
        Assert.Equal(responseAlteracao.CodigoLancamentoIntegracao, responseInclusao.CodigoLancamentoIntegracao);


        //-- Consultar alteração

        contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(chaveContaPagar);

        Assert.NotNull(contaApagar);
        Assert.Equal(codigoIntegracao, contaApagar.CodigoLancamentoIntegracao);
        Assert.Equal(codigoOmie, contaApagar.CodigoLancamentoOmie);
        //Assert.Equal(observacao, contaApagar.observacao); //Omie demora para reponder com a versão atualizada


        //-- Exclusão

        var responseExclusao = await _omieSharpClient.ExcluirContaPagarAsync(chaveContaPagar);
        Assert.Equal("0", responseExclusao.CodigoStatus);
        Assert.Equal(responseExclusao.CodigoLancamentoIntegracao, responseInclusao.CodigoLancamentoIntegracao);


        //-- Consultar exclusão

        contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(chaveContaPagar);
        //Assert.Null(contaApagar); //A exclusão não está ocorrendo imadiatamente
    }
}
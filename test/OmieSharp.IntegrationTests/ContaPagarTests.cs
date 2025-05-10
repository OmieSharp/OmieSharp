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
        Assert.NotEmpty(response.conta_pagar_cadastro);
    }

    [Fact]
    public async Task ListarContaPagarAsync_Notfound()
    {
        var request = new ListarContaPagarRequest() { filtrar_por_projeto = 99999999999 };
        var response = await _omieSharpClient.ListarContaPagarAsync(request);
        Assert.Empty(response.conta_pagar_cadastro);
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
        var cliente = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(Constants.CLIENTE_CODIGO_INTEGRACAO));
        if (cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");

        var contaCorrente = await _omieSharpClient.ConsultarContaCorrenteAsync(new ContaCorrenteChave(Constants.CONTA_CORRENTE_CODIGO_INTEGRACAO));
        if (contaCorrente == null)
            throw new InvalidOperationException("Conta Corrente não encontrada");

        var codigoIntegracao = $"{DateTime.Now:yyyyMMdd-HHmmss}";
        var now = DateTime.Now.Date;
        var dataPrevisao = DateOnly.FromDateTime(now.AddDays(15));


        //-- Inclusão

        var request = new ContaPagar()
        {
            codigo_lancamento_integracao = codigoIntegracao,
            codigo_cliente_fornecedor = cliente.codigo_cliente_omie,
            data_vencimento = dataPrevisao,
            valor_documento = 120.50M,
            codigo_categoria = "2.04.01",
            data_previsao = dataPrevisao,
            id_conta_corrente = contaCorrente.nCodCC
        };
        var responseInclusao = await _omieSharpClient.IncluirContaPagarAsync(request);
        var codigoOmie = responseInclusao.codigo_lancamento_omie;

        Assert.Equal("0", responseInclusao.codigo_status);
        Assert.Equal(codigoIntegracao, responseInclusao.codigo_lancamento_integracao);


        //-- Consultar inclusão

        var contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(new ContaPagarChave(codigoIntegracao));

        Assert.NotNull(contaApagar);
        Assert.Equal(codigoIntegracao, contaApagar.codigo_lancamento_integracao);
        Assert.Equal(codigoOmie, contaApagar.codigo_lancamento_omie);


        //-- Alteração

        var observacao = $"Teste de alteração {DateTime.Now:yyyy-MM-dd-HH:mm:ss}";
        contaApagar.observacao = observacao;

        var responseAlteracao = await _omieSharpClient.AlterarContaPagarAsync(contaApagar);
        Assert.Equal("0", responseAlteracao.codigo_status);
        Assert.Equal(responseAlteracao.codigo_lancamento_integracao, responseInclusao.codigo_lancamento_integracao);


        //-- Consultar alteração

        contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(new ContaPagarChave(codigoIntegracao));

        Assert.NotNull(contaApagar);
        Assert.Equal(codigoIntegracao, contaApagar.codigo_lancamento_integracao);
        Assert.Equal(codigoOmie, contaApagar.codigo_lancamento_omie);
        //Assert.Equal(observacao, contaApagar.observacao); //Omie demora para reponder com a versão atualizada


        //-- Exclusão

        var responseExclusao = await _omieSharpClient.ExcluirContaPagarAsync(new ContaPagarChave(codigoIntegracao));
        Assert.Equal("0", responseExclusao.codigo_status);
        Assert.Equal(responseExclusao.codigo_lancamento_integracao, responseInclusao.codigo_lancamento_integracao);


        //-- Consultar exclusão

        contaApagar = await _omieSharpClient.ConsultarContaPagarAsync(new ContaPagarChave(codigoIntegracao));
        Assert.Null(contaApagar);
    }
}
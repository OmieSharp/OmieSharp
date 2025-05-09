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
    public async Task IncluirContaPagar_Success()
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
        var response = await _omieSharpClient.IncluirContaPagarAsync(request);

        Assert.Equal("0", response.codigo_status);
        Assert.Equal(codigoIntegracao, response.codigo_lancamento_integracao);
    }
}
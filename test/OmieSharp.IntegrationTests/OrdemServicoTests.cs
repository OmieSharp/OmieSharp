using OmieSharp.Models;
using OmieSharp.Models.ContaPagarModels;

namespace OmieSharp.IntegrationTests;

public class OrdemServicoTests : BaseTest
{
    private readonly OmieSharpClient _omieSharpClient;
    //private readonly ConfigurationFile _configurationFile;

    public OrdemServicoTests()
    {
        _omieSharpClient = GetOmieSharpClient();
        //_configurationFile = GetConfigurationFile();
    }

    [Fact]
    public async Task ListarOrdemServicoAsync_Success()
    {
        var request = new ListarOrdemServicoRequest();
        var response = await _omieSharpClient.ListarOrdemServicoAsync(request);
        Assert.NotEmpty(response.OrdemServicos);
    }

    [Fact]
    public async Task ListarOrdemServicoAsync_Notfound()
    {
        var request = new ListarOrdemServicoRequest() { FiltrarPorCodigo = new List<OrdemServicoChave>() { new OrdemServicoChave("99999999999") } };
        var response = await _omieSharpClient.ListarOrdemServicoAsync(request);
        Assert.Empty(response.OrdemServicos);
    }

    [Fact]
    public async Task ConsultarOrdemServicoAsync_Notfound()
    {
        var request = new OrdemServicoChave("99999999999");
        var response = await _omieSharpClient.ConsultarOrdemServicoAsync(request);
        Assert.Null(response);
    }

    [Fact]
    public async Task IncluirOrdemServico_Success()
    {
        var cliente = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(Constants.CLIENTE_CODIGO_INTEGRACAO));
        if (cliente == null)
            throw new InvalidOperationException("Cliente não encontrado");

        var chaveConsulta = new CadastroServicoChave(Constants.SERVICO_CODIGO_INTEGRACAO);
        var servico = await _omieSharpClient.ConsultarCadastroServicoAsync(chaveConsulta);
        if (servico == null)
            throw new InvalidOperationException("Serviço não encontrado");

        var contaCorrente = await _omieSharpClient.ConsultarContaCorrenteAsync(new ContaCorrenteChave(Constants.CONTA_CORRENTE_CODIGO_INTEGRACAO));
        if (contaCorrente == null)
            throw new InvalidOperationException("Conta Corrente não encontrada");

        var codigoIntegracao = $"{DateTime.Now:yyyyMMdd-HHmmss}";
        var now = DateTime.Now.Date;
        var dataPrevisao = DateOnly.FromDateTime(now.AddDays(15));
        var qtd = 1;
        var valUnit = 100M;

        var request = new OrdemServico()
        {
            Cabecalho = new OrdemServicoCabecalho()
            {
                CodIntOS = codigoIntegracao,
                CodParc = null,
                Etapa = EtapasOS.SegundaColuna, //"20",
                DataPrevisao = dataPrevisao,
                CodCli = cliente.CodigoClienteOmie,
                QtdeParc = 1
            },
            Email = new OrdemServicoEmail()
            {
                EnvBoletoSN = false,
                EnvLinkSN = false,
                EnviarPara = "teste@teste.com.br"
            },
            InformacoesAdicionais = new OrdemServicoInformacoesAdicionais()
            {
                CidPrestServ = "SAO PAULO (SP)",
                CodCateg = "1.01.02",
                DadosAdicNF = "Teste TaskrowSharp",
                CodCC = contaCorrente.CodCC
            },
            Observacoes = new Observacoes() {
                ObsOS = "Teste OmiSharp"
            },
            Parcelas = new List<ParcelaOS>()
            {
                new ParcelaOS()
                {
                    DataVenc = dataPrevisao,
                    NumeroDias = 31,
                    NumeroParcela = 1,
                    Percentual = 100,
                    Valor = qtd * valUnit
                }
            },
            ServicosPrestados = new List<OrdemServicoServicosPrestado>()
            {
                new OrdemServicoServicosPrestado()
                {
                    CodServico = servico.Listar.CodServ,
					    DescServ = "Serviços prestado 001",
                    DadosAdicItem = "Serviços prestados",
					    RetemIssSN = false,
                    Impostos = new OrdemServicoServicosImpostos()
                    {
                        RetemIrrfSN = true,
						    RetemPisSN = true,
						    AliqCofins = 0,
						    AliqCsll = 0,
						    AliqIrrf = 15,
						    AliqIss = 3,
						    AliqPis = 4.5M
                    },
                    Qtde = qtd,
					    ValUnit = valUnit
                }
            }
        };
        var response = await _omieSharpClient.IncluirOrdemServicoAsync(request);

        Assert.Equal("0", response.CodStatus);
        Assert.Equal(codigoIntegracao, response.CodIntOS);
    }
}
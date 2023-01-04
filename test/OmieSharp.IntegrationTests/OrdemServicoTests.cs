using OmieSharp.IntegrationTests.ConfigModels;
using OmieSharp.Models;

namespace OmieSharp.IntegrationTests
{
    public class OrdemServicoTests : BaseTest
    {
        private readonly OmieSharpClient _omieSharpClient;
        private readonly ConfigurationFile _configurationFile;

        public OrdemServicoTests()
        {
            _omieSharpClient = GetOmieSharpClient();
            _configurationFile = GetConfigurationFile();
        }

        [Fact]
        public async Task ListarOrdemServicoAsync_Success()
        {
            var request = new ListarOrdemServicoRequest();
            var response = await _omieSharpClient.ListarOrdemServicoAsync(request);
            Assert.NotEmpty(response.osCadastro);
        }

        [Fact]
        public async Task ListarOrdemServicoAsync_Notfound()
        {
            var request = new ListarOrdemServicoRequest() { filtrar_por_codigo = new List<OrdemServicoChave>() { new OrdemServicoChave("99999999999") } };
            var response = await _omieSharpClient.ListarOrdemServicoAsync(request);
            Assert.Empty(response.osCadastro);
        }

        /*[Fact]
        public async Task IncluirOrdemServico_Success()
        {
            var codigoIntegracao = $"{DateTime.Now:yyyyMMdd-HHmmss}";
            var now = DateTime.Now.Date;
            var dataPrevisao = now.AddDays(15);

            var cliente = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(Constants.CLIENTE_CODIGO_INTEGRACAO));
            if (cliente == null)
                throw new InvalidOperationException("Cliente não encontrado");

            var servico = await _omieSharpClient.ConsultarCadastroServicoAsync(new CadastroServicoChave(Constants.SERVICO_CODIGO_INTEGRACAO));
            if (servico == null)
                throw new InvalidOperationException("Serviço não encontrado");

            var request = new IncluirOrdemServicoRequest()
            {
                Cabecalho = new OrdemServicoCabecalho()
                {
                    cCodIntOS = codigoIntegracao,
                    cCodParc = null,
                    cEtapa = "20",
                    dDtPrevisao = dataPrevisao.ToString("dd/MM/yyyy"),
                    nCodCli = cliente.codigo_cliente_omie,
                    nQtdeParc = 1
                },
                Email = new OrdemServicoEmail()
                {
                    cEnvBoleto = false,
                    cEnvLink = false,
                    cEnviarPara = "teste@teste.com.br"
                },
                InformacoesAdicionais = new OrdemServicoInformacoesAdicionais()
                {
                    cCidPrestServ = "SAO PAULO (SP)",
                    cCodCateg = "1.01.02",
                    cDadosAdicNF = "Teste TaskrowSharp",
                    nCodCC = cliente.dadosBancarios.conta_corrente
                }
            };
            var response = await _omieSharpClient.IncluirOrdemServicoAsync(request);

            Assert.True(response.Success);
            Assert.Equal(codigoIntegracao, response.codigo_cliente_integracao);
        }*/
    }
}
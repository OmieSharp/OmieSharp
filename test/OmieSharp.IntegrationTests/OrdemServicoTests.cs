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

        [Fact]
        public async Task IncluirOrdemServico_Success()
        {
            var cliente = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(Constants.CLIENTE_CODIGO_INTEGRACAO));
            if (cliente == null)
                throw new InvalidOperationException("Cliente não encontrado");

            var servico = await _omieSharpClient.ConsultarCadastroServicoAsync(new CadastroServicoChave(Constants.SERVICO_CODIGO_INTEGRACAO));
            if (servico == null)
                throw new InvalidOperationException("Serviço não encontrado");


        }
    }
}
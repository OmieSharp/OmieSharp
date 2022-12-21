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
    }
}
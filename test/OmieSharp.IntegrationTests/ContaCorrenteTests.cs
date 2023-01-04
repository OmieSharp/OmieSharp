using OmieSharp.IntegrationTests.ConfigModels;
using OmieSharp.Models;

namespace OmieSharp.IntegrationTests
{
    public class ContaCorrenteTests : BaseTest
    {
        private readonly OmieSharpClient _omieSharpClient;
        private readonly ConfigurationFile _configurationFile;

        public ContaCorrenteTests()
        {
            _omieSharpClient = GetOmieSharpClient();
            _configurationFile = GetConfigurationFile();
        }

        [Fact]
        public async Task ListarContaCorrenteAsync_Success()
        {
            var request = new ListarContaCorrenteRequest();
            var response = await _omieSharpClient.ListarContaCorrenteAsync(request);
            Assert.NotEmpty(response.ListarContasCorrentes);
        }

        [Fact]
        public async Task ListarContaCorrenteAsync_Notfound()
        {
            var request = new ListarContaCorrenteRequest() { codigo_integracao = "99999999999" };
            var response = await _omieSharpClient.ListarContaCorrenteAsync(request);
            Assert.Empty(response.ListarContasCorrentes);
        }

        [Fact]
        public async Task IncluirAlterarContaCorrenteAsync_Success()
        {
            var timestamp = $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fff}";

            var chave = new ContaCorrenteChave(Constants.CONTA_CORRENTE_CODIGO_INTEGRACAO);
            var contaCorrenteExistente = await _omieSharpClient.ConsultarContaCorrenteAsync(chave);

            var descicao = $"TesteOmieSharp - {timestamp}";

            if (contaCorrenteExistente == null)
            {
                var request = new ContaCorrente()
                {
                    cCodCCInt = Constants.CONTA_CORRENTE_CODIGO_INTEGRACAO,
                    tipo_conta_corrente = "CX",
                    codigo_banco = "999",
                    descricao = descicao,
                    saldo_inicial = 0
                };
                var response = await _omieSharpClient.IncluirContaCorrenteAsync(request);

                Assert.Equal("0", response.cCodStatus);
            }
            else
            {
                contaCorrenteExistente.descricao = descicao;

                var response = await _omieSharpClient.AlterarContaCorrenteAsync(contaCorrenteExistente);

                Assert.Equal("0", response.cCodStatus);
            }
        }
    }
}

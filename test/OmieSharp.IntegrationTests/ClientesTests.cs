using OmieSharp.IntegrationTests.ConfigModels;
using OmieSharp.Models;

namespace OmieSharp.IntegrationTests
{
    public class ClientesTests : BaseTest
    {
        private readonly OmieSharpClient _omieSharpClient;
        private readonly ConfigurationFile _configurationFile;

        public ClientesTests()
        {
            _omieSharpClient = GetOmieSharpClient();
            _configurationFile = GetConfigurationFile();
        }

        [Fact]
        public async Task ListarClientesAsync_Success()
        {
            var request = new ListarClientesRequest();
            var response = await _omieSharpClient.ListarClientesAsync(request);
            Assert.NotEmpty(response.clientes_cadastro);
        }

        [Fact]
        public async Task ConsultarClienteAsync_Success()
        {
            var request = new ClientesCadastroChave(_configurationFile.codigo_cliente_omie);
            var response = await _omieSharpClient.ConsultarClienteAsync(request);
            Assert.NotNull(response);
            Assert.Equal(_configurationFile.codigo_cliente_omie, response.codigo_cliente_omie);
        }

        [Fact]
        public async Task IncluirClienteAsync_Success()
        {
            var name = $"test_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-ffff}";

            var cliente = new ClientesCadastro
            {
                codigo_cliente_integracao = name,
                email = "teste@teste.com.br",
                razao_social = name,
                nome_fantasia = name
            };

            var response = await _omieSharpClient.IncluirClienteAsync(cliente);
            Assert.True(response.Success);
        }

        [Fact]
        public async Task AlterarClienteAsync_Success()
        {
            var cliente = await _omieSharpClient.ConsultarClienteAsync(new ClientesCadastroChave(_configurationFile.codigo_cliente_omie));

            const string fieldName = "omiesharp_test";
            cliente.caracteristicas ??= new List<Caracteristica>();
            var caracteristica = cliente.caracteristicas.FirstOrDefault(a => a.campo.Equals(fieldName));
            if (caracteristica == null)
                cliente.caracteristicas.Add(new Caracteristica(fieldName, ""));
            caracteristica.conteudo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ffff");

            var response = await _omieSharpClient.AlterarClienteAsync(cliente);
            Assert.True(response.Success);
        }
    }
}
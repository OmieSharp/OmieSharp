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
        public async Task IncluirAlterarClienteAsync_Success()
        {
            var now = DateTime.Now;
            var timestamp = $"{now:yyyy-MM-ddTHH:mm:ss.fff}";
            
            var codigoIntegracao = $"{now:yyyyMMdd_HHmmss_fff}";
            var email = "teste@teste.com.br";
            var razaoSocial = $"Teste OmieSharp LTDA {timestamp}";
            var nomeFantasia = $"Teste OmieSharp {timestamp}";
            var cnpj = "12121212000106";

            long codigoClienteOmie = 0;

            var responseListaClientes = await _omieSharpClient.ListarClientesAsync(
                new ListarClientesRequest() { 
                    clientesFiltro = new ClientFiltro() { 
                        cnpj_cpf = cnpj 
                    } 
                });

            var clienteExistente = responseListaClientes?.clientes_cadastro?.FirstOrDefault();

            if (clienteExistente == null)
            {
                var clienteIncluir = new ClientesCadastro
                {
                    codigo_cliente_integracao = codigoIntegracao,
                    email = email,
                    razao_social = razaoSocial,
                    nome_fantasia = nomeFantasia,
                    cnpj_cpf = cnpj,
                    inativo = true
                };

                var responseIncluir = await _omieSharpClient.IncluirClienteAsync(clienteIncluir);
                Assert.True(responseIncluir.Success);
                Assert.NotEqual(0, responseIncluir.codigo_cliente_omie);

                codigoClienteOmie = responseIncluir.codigo_cliente_omie;
            }
            else
            {
                codigoClienteOmie = clienteExistente.codigo_cliente_omie;
            }

            var clienteEditar = await _omieSharpClient.ConsultarClienteAsync(new ClientesCadastroChave(codigoClienteOmie));
            Assert.NotNull(clienteEditar);

            clienteEditar.razao_social = razaoSocial;
            clienteEditar.nome_fantasia = nomeFantasia;

            const string fieldName = "omiesharp_test";
            clienteEditar.caracteristicas ??= new List<Caracteristica>();
            var caracteristica = clienteEditar.caracteristicas.FirstOrDefault(a => a.campo.Equals(fieldName));
            if (caracteristica == null)
                clienteEditar.caracteristicas.Add(new Caracteristica(fieldName, timestamp));
            else
                caracteristica.conteudo = timestamp;

            var responseEditar = await _omieSharpClient.AlterarClienteAsync(clienteEditar);
            Assert.True(responseEditar.Success);
        }
    }
}
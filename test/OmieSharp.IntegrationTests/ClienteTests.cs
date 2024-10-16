using OmieSharp.IntegrationTests.ConfigModels;
using OmieSharp.Models;

namespace OmieSharp.IntegrationTests
{
    public class ClienteTests : BaseTest
    {
        private readonly OmieSharpClient _omieSharpClient;
        private readonly ConfigurationFile _configurationFile;

        public ClienteTests()
        {
            _omieSharpClient = GetOmieSharpClient();
            _configurationFile = GetConfigurationFile();
        }

        [Fact]
        public async Task ListarClientesAsync_Success()
        {
            var request = new ListarClienteRequest();
            var response = await _omieSharpClient.ListarClientesAsync(request);
            Assert.NotNull(response);
            Assert.NotEmpty(response.clientes_cadastro!);
        }

        [Fact]
        public async Task ListarClientes_Filtro_Cnpj_Success()
        {
            var request = new ListarClienteRequest() { clientesFiltro = new ClientFiltro() { cnpj_cpf = Constants.CLIENTE_CNPJ } };
            var response = await _omieSharpClient.ListarClientesAsync(request);
            Assert.NotNull(response);
            Assert.NotEmpty(response.clientes_cadastro!);
        }

        [Fact]
        public async Task ListarClientesAsync_NotFound()
        {
            var request = new ListarClienteRequest() { clientesPorCodigo = new List<ClienteCadastroChave>() { new ClienteCadastroChave(9999999) } };
            var response = await _omieSharpClient.ListarClientesAsync(request);
            Assert.Equal(0, response.total_de_registros);
        }

        [Fact]
        public async Task ConsultarClienteAsync_NotFound()
        {
            var chave = new ClienteCadastroChave(999999999);
            var response = await _omieSharpClient.ConsultarClienteAsync(chave);
            Assert.Null(response);
        }

        [Fact]
        public async Task IncluirAlterarClienteAsync_Success()
        {
            var timestamp = $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fff}";
            
            long codigoClienteOmie = 0;

            var requestListaClientes = new ListarClienteRequest()
            {
                clientesFiltro = new ClientFiltro()
                {
                    cnpj_cpf = Constants.CLIENTE_CNPJ
                }
            };
            var responseListaClientes = await _omieSharpClient.ListarClientesAsync(requestListaClientes);

            var clienteExistente = responseListaClientes?.clientes_cadastro?.FirstOrDefault();

            if (clienteExistente == null)
            {
                var clienteIncluir = new ClienteCadastro
                {
                    codigo_cliente_integracao = Constants.CLIENTE_CODIGO_INTEGRACAO,
                    email = Constants.CLIENTE_EMAIL,
                    razao_social = Constants.CLIENTE_RAZAO_SOCIAL,
                    nome_fantasia = Constants.CLIENTE_NOME_FANTASIA,
                    cnpj_cpf = Constants.CLIENTE_CNPJ,
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

            var clienteEditar = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(codigoClienteOmie));
            Assert.NotNull(clienteEditar);

            //clienteEditar.razao_social = razaoSocial;
            //clienteEditar.nome_fantasia = nomeFantasia;
            
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

        [Fact]
        public async Task IncluirAlterarFornecedorAsync_Success()
        {
            var timestamp = $"{DateTime.Now:yyyy-MM-ddTHH:mm:ss.fff}";

            long codigoClienteOmie = 0;

            var requestListaClientes = new ListarClienteRequest()
            {
                clientesFiltro = new ClientFiltro()
                {
                    cnpj_cpf = Constants.FORNECEDOR_CNPJ
                }
            };
            var responseListaClientes = await _omieSharpClient.ListarClientesAsync(requestListaClientes);

            var clienteExistente = responseListaClientes?.clientes_cadastro?.FirstOrDefault();

            if (clienteExistente == null)
            {
                var clienteIncluir = new ClienteCadastro
                {
                    codigo_cliente_integracao = Constants.FORNECEDOR_CODIGO_INTEGRACAO,
                    email = Constants.FORNECEDOR_EMAIL,
                    razao_social = Constants.FORNECEDOR_RAZAO_SOCIAL,
                    nome_fantasia = Constants.FORNECEDOR_NOME_FANTASIA,
                    cnpj_cpf = Constants.FORNECEDOR_CNPJ,
                    inativo = true,
                    tags = new List<Tag>() { new Tag("Fornecedor") }
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

            var clienteEditar = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(codigoClienteOmie));
            Assert.NotNull(clienteEditar);

            //clienteEditar.razao_social = razaoSocial;
            //clienteEditar.nome_fantasia = nomeFantasia;

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
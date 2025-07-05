using OmieSharp.Models;

namespace OmieSharp.IntegrationTests;

public class ClienteTests : BaseTest
{
    private readonly OmieSharpClient _omieSharpClient;
    //private readonly ConfigurationFile _configurationFile;

    public ClienteTests()
    {
        _omieSharpClient = GetOmieSharpClient();
        //_configurationFile = GetConfigurationFile();
    }

    [Fact]
    public async Task ListarClientesAsync_Success()
    {
        var request = new ListarClienteRequest();
        var response = await _omieSharpClient.ListarClientesAsync(request);
        Assert.NotNull(response);
        Assert.NotEmpty(response.ClientesCadastro!);
    }

    [Fact]
    public async Task ListarClientes_Filtro_Cnpj_Success()
    {
        var request = new ListarClienteRequest() { ClientesFiltro = new ClientFiltro() { CnpjCpf = Constants.CLIENTE_CNPJ } };
        var response = await _omieSharpClient.ListarClientesAsync(request);
        Assert.NotNull(response);
        Assert.NotEmpty(response.ClientesCadastro!);
    }

    [Fact]
    public async Task ListarClientesAsync_NotFound()
    {
        var request = new ListarClienteRequest() { ClientesPorCodigo = new List<ClienteCadastroChave>() { new ClienteCadastroChave(9999999) } };
        var response = await _omieSharpClient.ListarClientesAsync(request);
        Assert.Equal(0, response.TotalRegistros);
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
            ClientesFiltro = new ClientFiltro()
            {
                CnpjCpf = Constants.CLIENTE_CNPJ
            }
        };
        var responseListaClientes = await _omieSharpClient.ListarClientesAsync(requestListaClientes);

        var clienteExistente = responseListaClientes?.ClientesCadastro?.FirstOrDefault();

        if (clienteExistente == null)
        {
            var clienteIncluir = new ClienteCadastro
            {
                CodigoClienteIntegracao = Constants.CLIENTE_CODIGO_INTEGRACAO,
                Email = Constants.CLIENTE_EMAIL,
                RazaoSocial = Constants.CLIENTE_RAZAO_SOCIAL,
                NomeFantasia = Constants.CLIENTE_NOME_FANTASIA,
                CnpjCpf = Constants.CLIENTE_CNPJ,
                InativoSN = true
            };

            var responseIncluir = await _omieSharpClient.IncluirClienteAsync(clienteIncluir);
            Assert.True(responseIncluir.Success);
            Assert.NotEqual(0, responseIncluir.CodigoClienteOmie);

            codigoClienteOmie = responseIncluir.CodigoClienteOmie;
        }
        else
        {
            codigoClienteOmie = clienteExistente.CodigoClienteOmie;
        }

        var clienteEditar = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(codigoClienteOmie));
        Assert.NotNull(clienteEditar);

        //clienteEditar.razao_social = razaoSocial;
        //clienteEditar.nome_fantasia = nomeFantasia;
        
        const string fieldName = "omiesharp_test";
        clienteEditar.Caracteristicas ??= new List<Caracteristica>();
        var caracteristica = clienteEditar.Caracteristicas.FirstOrDefault(a => a.Campo.Equals(fieldName));
        if (caracteristica == null)
            clienteEditar.Caracteristicas.Add(new Caracteristica(fieldName, timestamp));
        else
            caracteristica.Conteudo = timestamp;

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
            ClientesFiltro = new ClientFiltro()
            {
                CnpjCpf = Constants.FORNECEDOR_CNPJ
            }
        };
        var responseListaClientes = await _omieSharpClient.ListarClientesAsync(requestListaClientes);

        var clienteExistente = responseListaClientes?.ClientesCadastro?.FirstOrDefault();

        if (clienteExistente == null)
        {
            var clienteIncluir = new ClienteCadastro
            {
                CodigoClienteIntegracao = Constants.FORNECEDOR_CODIGO_INTEGRACAO,
                Email = Constants.FORNECEDOR_EMAIL,
                RazaoSocial = Constants.FORNECEDOR_RAZAO_SOCIAL,
                NomeFantasia = Constants.FORNECEDOR_NOME_FANTASIA,
                CnpjCpf = Constants.FORNECEDOR_CNPJ,
                InativoSN = true,
                Tags = new List<Tag>() { new Tag("Fornecedor") }
            };

            var responseIncluir = await _omieSharpClient.IncluirClienteAsync(clienteIncluir);
            Assert.True(responseIncluir.Success);
            Assert.NotEqual(0, responseIncluir.CodigoClienteOmie);

            codigoClienteOmie = responseIncluir.CodigoClienteOmie;
        }
        else
        {
            codigoClienteOmie = clienteExistente.CodigoClienteOmie;
        }

        var clienteEditar = await _omieSharpClient.ConsultarClienteAsync(new ClienteCadastroChave(codigoClienteOmie));
        Assert.NotNull(clienteEditar);

        //clienteEditar.razao_social = razaoSocial;
        //clienteEditar.nome_fantasia = nomeFantasia;

        const string fieldName = "omiesharp_test";
        clienteEditar.Caracteristicas ??= new List<Caracteristica>();
        var caracteristica = clienteEditar.Caracteristicas.FirstOrDefault(a => a.Campo.Equals(fieldName));
        if (caracteristica == null)
            clienteEditar.Caracteristicas.Add(new Caracteristica(fieldName, timestamp));
        else
            caracteristica.Conteudo = timestamp;

        var responseEditar = await _omieSharpClient.AlterarClienteAsync(clienteEditar);
        Assert.True(responseEditar.Success);
    }
}
using OmieSharp.Events;
using OmieSharp.Events.Body.ContaReceber;
using OmieSharp.Events.Body.OrdemServico;
using System.Diagnostics;

namespace OmieSharp.IntegrationTests
{
    public class EventsTests : BaseTest
    {
        [Fact]
        public async Task EventoDesconchecido_Success()
        {
            var dic = new Dictionary<string, Type>
            {
                { "Erro-EventoDesconhecido.json", typeof(OmieEventRequest<object>) }
            };

            string path;
            foreach (var key in dic.Keys)
            {
                path = $"./SampleRequests/Events/Erro/{key}";

                try
                {
                    var json = await File.ReadAllTextAsync(path);
                    var omieEvent = OmieEventFactory.CreateFromJson(json);

                    Assert.NotNull(omieEvent);
                    Assert.IsType(dic[key], omieEvent);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Error validating Event -- path: {path}, error: {ex.Message}";
                    Debug.WriteLine(errorMessage);
                    throw new InvalidOperationException(errorMessage, ex);
                }
            }
        }

        [Fact]
        public async Task OrdemServicoEvents_Success()
        {
            var dic = new Dictionary<string, Type>
            {
                { "OrdemServico-Incluida.json", typeof(OmieEventRequest<OrdemServicoIncluidaOmieEvent>) },
                { "OrdemServico-Alterada.json", typeof(OmieEventRequest<OrdemServicoAlteradaOmieEvent>) },
                { "OrdemServico-EtapaAlterada.json", typeof(OmieEventRequest<OrdemServicoEtapaAlteradaOmieEvent>) },
                { "OrdemServico-Faturada.json", typeof(OmieEventRequest<OrdemServicoFaturadaOmieEvent>) },
                { "OrdemServico-Cancelada.json", typeof(OmieEventRequest<OrdemServicoCanceladaOmieEvent>) },
                { "OrdemServico-Excluida.json", typeof(OmieEventRequest<OrdemServicoExcluidaOmieEvent>) }
            };

            string path;
            foreach (var key in dic.Keys)
            {
                path = $"./SampleRequests/Events/OrdemServico/{key}";

                try
                {
                    var json = await File.ReadAllTextAsync(path);
                    var omieEvent = OmieEventFactory.CreateFromJson(json);

                    Assert.NotNull(omieEvent);
                    Assert.IsType(dic[key], omieEvent);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Error validating Event -- path: {path}, error: {ex.Message}";
                    Debug.WriteLine(errorMessage);
                    throw new InvalidOperationException(errorMessage, ex);
                }
            }
        }

        [Fact]
        public async Task ContaReceberEvents_Success()
        {
            var dic = new Dictionary<string, Type>
            {
                { "ContaReceber-Incluido.json", typeof(OmieEventRequest<ContaReceberIncluidoOmieEvent>) },
                { "ContaReceber-Alterado.json", typeof(OmieEventRequest<ContaReceberAlteradoOmieEvent>) }
            };

            string path;
            foreach (var key in dic.Keys)
            {
                path = $"./SampleRequests/Events/ContaReceber/{key}";

                try
                {
                    var json = await File.ReadAllTextAsync(path);
                    var omieEvent = OmieEventFactory.CreateFromJson(json);

                    Assert.NotNull(omieEvent);
                    Assert.IsType(dic[key], omieEvent);
                }
                catch (Exception ex)
                {
                    string errorMessage = $"Error validating Event -- path: {path}, error: {ex.Message}";
                    Debug.WriteLine(errorMessage);
                    throw new InvalidOperationException(errorMessage, ex);
                }
            }
        }
    }
}
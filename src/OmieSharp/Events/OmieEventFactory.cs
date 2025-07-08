using OmieSharp.Events.Body;
using OmieSharp.Events.Body.ContaPagar;
using OmieSharp.Events.Body.ContaReceber;
using OmieSharp.Events.Body.OrdemServico;
using System.Text.Json;

namespace OmieSharp.Events;

public static class OmieEventFactory
{
    public static object? CreateFromJson(string json)
    {
        if (json == null) 
            throw new ArgumentNullException(nameof(json));

        var eventRequest = JsonSerializer.Deserialize<OmieEventRequest<dynamic>>(json);
        if (eventRequest == null || string.IsNullOrEmpty(eventRequest.Topic))
        {
            if (json.Contains("ping"))
                return new OmieEventRequest<object>(messageId: "", topic: "ping", "", new OmieEventRequestAuthor("", "", 0), "", "", "");

            return null;
        }

        var topic = eventRequest.Topic!;

        if (topic.StartsWith("OrdemServico.", StringComparison.CurrentCultureIgnoreCase))
            return CreateOrdemServicoEvent(topic, json);
        
        if (topic.StartsWith("Financas.ContaReceber.", StringComparison.CurrentCultureIgnoreCase))
            return CreateContaReceberEvent(topic, json);
        
        if (topic.StartsWith("Financas.ContaPagar.BaixaRealizada", StringComparison.CurrentCultureIgnoreCase))
            return CreateContaPagarEvent(topic, json);

        //Evento desconhecido (não tratado)
        return JsonSerializer.Deserialize<OmieEventRequest<object>>(json);
    }

    public static OmieEventRequest<T>? CreateFromJson<T>(string json) where T : BaseOmieEvent
    {
        var obj = CreateFromJson(json);
        if (obj == null)
            return default;

        return (OmieEventRequest<T>)obj;
    }

    private static object? CreateOrdemServicoEvent(string topic, string json)
    {
        if (topic.Equals("OrdemServico.Incluida", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoIncluidaOmieEvent>>(json);

        if (topic.Equals("OrdemServico.Alterada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoAlteradaOmieEvent>>(json);

        if (topic.Equals("OrdemServico.EtapaAlterada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoEtapaAlteradaOmieEvent>>(json);

        if (topic.Equals("OrdemServico.Faturada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoFaturadaOmieEvent>>(json);

        if (topic.Equals("OrdemServico.Cancelada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoCanceladaOmieEvent>>(json);

        if (topic.Equals("OrdemServico.Excluida", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<OrdemServicoExcluidaOmieEvent>>(json);

        return null;
    }

    private static object? CreateContaReceberEvent(string topic, string json)
    {
        if (topic.Equals("Financas.ContaReceber.Incluido", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<ContaReceberIncluidoOmieEvent>>(json);

        if (topic.Equals("Financas.ContaReceber.Alterado", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequest<ContaReceberAlteradoOmieEvent>>(json);

        if (topic.Equals("Financas.ContaReceber.BaixaRealizada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequestMultiple<ContaReceberBaixaRealizadaOmieEvent>>(json);

        return null;
    }

    private static object? CreateContaPagarEvent(string topic, string json)
    {
        if (topic.Equals("Financas.ContaPagar.BaixaRealizada", StringComparison.CurrentCultureIgnoreCase))
            return JsonSerializer.Deserialize<OmieEventRequestMultiple<ContaPagarBaixaRealizadaOmieEvent>>(json);

        return null;
    }
}

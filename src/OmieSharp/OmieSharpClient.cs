using OmieSharp.EventHandlers;
using OmieSharp.Exceptions;
using OmieSharp.Models;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OmieSharp
{
    public class OmieSharpClient
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string UserAgent { get; set; }
        public HttpClient HttpClient { get; private set; }

        private static readonly Uri baseUrl = new("https://app.omie.com.br/");

        #region Events

        public event ApiCallExecutedEventHandler? OnApiCallExecuted;

        #endregion

        public OmieSharpClient(string appKey, string appSecret, HttpClient httpClient)
        {
            ValidateAppKey(appKey);
            ValidateAppSecret(appSecret);

            this.AppKey = appKey;
            this.AppSecret = appSecret;
            this.HttpClient = httpClient;

            this.UserAgent = $"OmieSharp v{Utils.Application.GetAppVersion()}";
        }

        private readonly JsonSerializerOptions jsonSerializerOptions = new()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        private static void ValidateAppKey(string appKey)
        {
            ArgumentNullException.ThrowIfNull(appKey);

            if (appKey.Length < 6)
                throw new ArgumentException("Invalid AppKey");
        }

        private static void ValidateAppSecret(string appSecret)
        {
            ArgumentNullException.ThrowIfNull(appSecret);

            if (appSecret.Length < 32)
                throw new ArgumentException("Invalid AppSecret");
        }

        private async Task<T2> ExecuteApiCall<T1, T2>(HttpMethod httpMethod, Uri fullUrl, OmieBaseRequest<T1> omieRequest)
        {
            var jsonRequest = (omieRequest != null ? JsonSerializer.Serialize(omieRequest, jsonSerializerOptions) : null);

            try
            {
                var httpRequest = new HttpRequestMessage(httpMethod, fullUrl);
                
                if (jsonRequest != null)
                {
                    var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                    requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    httpRequest.Content = requestContent;
                }

                var stopwatch = Stopwatch.StartNew();
                var httpResponse = await this.HttpClient.SendAsync(httpRequest);
                stopwatch.Stop();

                var jsonResponse = await httpResponse.Content.ReadAsStringAsync();
                
                RegisterApiCallExecuted(httpMethod, fullUrl, httpResponse.StatusCode, httpResponse.IsSuccessStatusCode, jsonRequest, jsonResponse, stopwatch.ElapsedMilliseconds);

                if (!httpResponse.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);
                    var errorMessage = errorResponse?.ErrorMessage ?? "";

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (errorMessage.Contains("já foi processada") || errorMessage.Contains("j\u00e1 foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [1]!","faultcode": "SOAP-ENV:Client-5113"}
                    //{\"faultstring\":\"ERROR: N\\u00e3o existem registros para a p\\u00e1gina [1]!\",\"faultcode\":\"SOAP-ENV:Client-5113\"}
                    if (errorMessage.Contains("Não existem registros") || errorMessage.Contains("N\\u00e3o existem registros"))
                        return default;

                    //{"faultstring": "ERROR: Cliente não cadastrado para o Código [999999999] !","faultcode": "SOAP-ENV:Client-105"}
                    //{"faultstring": "ERROR: Lançamento não cadastrado para o Código [123] !", "faultcode": "SOAP-ENV:Client-105"}
                    //{"faultstring": "ERROR: Serviço não cadastrado para o Código de integração do Serviço [teste-010] ! Tag [cCodIntServ]!","faultcode": "SOAP-ENV:Client-5002"}
                    if (errorMessage.Contains("não cadastrado") || errorMessage.Contains("n\\u00e3o cadastrado"))
                        return default;

                    //{"faultstring":"ERROR: OS n\u00e3o cadastrada para o C\u00f3digo de Integra\u00e7\u00e3o [99999999999] !","faultcode":"SOAP-ENV:Client-103"}
                    if (errorMessage.Contains("não cadastrada") || errorMessage.Contains("n\\u00e3o cadastrada"))
                        return default;

                    //{"faultstring":"ERROR: Nenhuma conta corrente foi encontrada!","faultcode":"SOAP-ENV:Client-101"}
                    if (errorMessage.Contains("Nenhuma conta corrente"))
                        return default;

                    throw new OmieSharpWebException(httpResponse.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)httpResponse.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<T2>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {fullUrl} -- {ex.Message}", ex);
            }
        }

        private void RegisterApiCallExecuted(HttpMethod httpMethod, Uri fullUrl, HttpStatusCode httpStatusCode, bool isSuccess, string? jsonRequest, string? jsonResponse, long elapsedMilliseconds)
        {
            if (isSuccess)
                Debug.WriteLine($"API Call - {httpMethod} {fullUrl} -- HttpStatus: {(int)httpStatusCode}");
            else
                Debug.WriteLine($"API Call ERROR - {httpMethod} {fullUrl} -- HttpStatus: {(int)httpStatusCode} -- Response: {jsonResponse}");

            OnApiCallExecuted?.Invoke(httpMethod, fullUrl, httpStatusCode, isSuccess, jsonRequest, jsonResponse, elapsedMilliseconds);
        }

        #region Cliente

        public async Task<ListarClienteResponse> ListarClientesAsync(ListarClienteRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarClienteRequest>("ListarClientes", AppKey, AppSecret, request);
            var response = await ExecuteApiCall<ListarClienteRequest, ListarClienteResponse>(HttpMethod.Post, fullUrl, omieRequest);
            if (response == null)
                return new ListarClienteResponse();
            return response;
        }

        public async Task<ClienteCadastro?> ConsultarClienteAsync(ClienteCadastroChave chave)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastroChave>("ConsultarCliente", AppKey, AppSecret, chave);
            return await ExecuteApiCall<ClienteCadastroChave, ClienteCadastro?>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<ClienteStatus> IncluirClienteAsync(ClienteCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastro>("IncluirCliente", AppKey, AppSecret, request);
            return await ExecuteApiCall<ClienteCadastro, ClienteStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<ClienteStatus> AlterarClienteAsync(ClienteCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastro>("AlterarCliente", AppKey, AppSecret, request);
            return await ExecuteApiCall<ClienteCadastro, ClienteStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        #endregion

        #region CadastroServico

        public async Task<ListarCadastroServicoResponse> ListarCadastroServicoAsync(ListarCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarCadastroServicoRequest>("ListarCadastroServico", AppKey, AppSecret, request);
            var response = await ExecuteApiCall<ListarCadastroServicoRequest, ListarCadastroServicoResponse>(HttpMethod.Post, fullUrl, omieRequest);
            if (response == null)
                return new ListarCadastroServicoResponse();
            return response;
        }

        public async Task<CadastroServico?> ConsultarCadastroServicoAsync(CadastroServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<CadastroServicoChave>("ConsultarCadastroServico", AppKey, AppSecret, chave);
            return await ExecuteApiCall<CadastroServicoChave, CadastroServico?>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<IncluirCadastroServicoResponse> IncluirCadastroServicoAsync(IncluirCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<IncluirCadastroServicoRequest>("IncluirCadastroServico", AppKey, AppSecret, request);
            return await ExecuteApiCall<IncluirCadastroServicoRequest, IncluirCadastroServicoResponse>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<AlterarCadastroServicoResponse> AlterarCadastroServicoAsync(AlterarCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<AlterarCadastroServicoRequest>("AlterarCadastroServico", AppKey, AppSecret, request);
            return await ExecuteApiCall<AlterarCadastroServicoRequest, AlterarCadastroServicoResponse>(HttpMethod.Post, fullUrl, omieRequest);
        }

        #endregion

        #region OrdemServico

        public async Task<ListarOrdemServicoResponse> ListarOrdemServicoAsync(ListarOrdemServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarOrdemServicoRequest>("ListarOS", AppKey, AppSecret, request);
            var response = await ExecuteApiCall<ListarOrdemServicoRequest, ListarOrdemServicoResponse>(HttpMethod.Post, fullUrl, omieRequest);
            if (response == null)
                return new ListarOrdemServicoResponse();
            return response;
        }

        public async Task<OrdemServico?> ConsultarOrdemServicoAsync(OrdemServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServicoChave>("ConsultarOS", AppKey, AppSecret, chave);
            return await ExecuteApiCall<OrdemServicoChave, OrdemServico?>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<OrdemServicoStatus> IncluirOrdemServicoAsync(OrdemServico request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServico>("IncluirOS", AppKey, AppSecret, request);
            return await ExecuteApiCall<OrdemServico, OrdemServicoStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<OrdemServicoStatus> AlterarOrdemServicoAsync(OrdemServico request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServico>("AlterarOS", AppKey, AppSecret, request);
            return await ExecuteApiCall<OrdemServico, OrdemServicoStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<OrdemServicoStatus> ExcluirOrdemServicoAsync(OrdemServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServicoChave>("ExcluirOS", AppKey, AppSecret, chave);
            return await ExecuteApiCall<OrdemServicoChave, OrdemServicoStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        #endregion

        #region ContaCorrente

        public async Task<ListarContaCorrenteResponse> ListarContaCorrenteAsync(ListarContaCorrenteRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarContaCorrenteRequest>("ListarContasCorrentes", AppKey, AppSecret, request);
            var response = await ExecuteApiCall<ListarContaCorrenteRequest, ListarContaCorrenteResponse>(HttpMethod.Post, fullUrl, omieRequest);
            if (response == null)
                return new ListarContaCorrenteResponse();
            return response;
        }

        public async Task<ContaCorrente?> ConsultarContaCorrenteAsync(ContaCorrenteChave chave)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrenteChave>("ConsultarContaCorrente", AppKey, AppSecret, chave);
            var contaCorrente = await ExecuteApiCall<ContaCorrenteChave, ContaCorrente?>(HttpMethod.Post, fullUrl, omieRequest);
            if (contaCorrente.nCodCC == 0)
                return null;
            return contaCorrente;
        }

        public async Task<ContaCorrenteStatus> IncluirContaCorrenteAsync(ContaCorrente request)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrente>("IncluirContaCorrente", AppKey, AppSecret, request);
            return await ExecuteApiCall<ContaCorrente, ContaCorrenteStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        public async Task<ContaCorrenteStatus> AlterarContaCorrenteAsync(ContaCorrente request)
        {
            //{"faultstring":"ERROR: A tag [pdv_sincr_analitica] somente deve ser informada quando a tag [tipo_conta_corrente] for igual a 'CC', 'AC', 'CX' ou 'CN' e a tag [pdv_enviar] for 'S' !","faultcode":"SOAP-ENV:Client-1020"}
            request.pdv_sincr_analitica = null;

            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrente>("AlterarContaCorrente", AppKey, AppSecret, request);
            return await ExecuteApiCall<ContaCorrente, ContaCorrenteStatus>(HttpMethod.Post, fullUrl, omieRequest);
        }

        #endregion

        #region ContaReceber

        public async Task<ContaReceber?> ConsultarContaReceberAsync(ContaReceberChave chave)
        {
            var relativeUrl = new Uri("/api/v1/financas/contareceber/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaReceberChave>("ConsultarContaReceber", AppKey, AppSecret, chave);
            return await ExecuteApiCall<ContaReceberChave, ContaReceber?>(HttpMethod.Post, fullUrl, omieRequest);
        }

        #endregion
    }
}
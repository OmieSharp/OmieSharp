using OmieSharp.Exceptions;
using OmieSharp.Models;
using System.Net.Http.Headers;
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

        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public OmieSharpClient(string appKey, string appSecret, HttpClient httpClient)
        {
            ValidateAppKey(appKey);
            ValidateAppSecret(appSecret);

            _jsonSerializerOptions = new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };

            this.AppKey = appKey;
            this.AppSecret = appSecret;
            this.HttpClient = httpClient;

            this.UserAgent = $"OmieSharp v{Utils.Application.GetAppVersion()}";
        }

        private static void ValidateAppKey(string appKey)
        {
            if (appKey == null)
                throw new ArgumentNullException(nameof(appKey));

            if (appKey.Length < 6)
                throw new ArgumentException(nameof(appKey));
        }

        private static void ValidateAppSecret(string appSecret)
        {
            if (appSecret == null)
                throw new ArgumentNullException(nameof(appSecret));

            if (appSecret.Length < 32)
                throw new ArgumentException(nameof(appSecret));
        }

        #region Cliente

        public async Task<ListarClienteResponse> ListarClientesAsync(ListarClienteRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarClienteRequest>("ListarClientes", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [1]!","faultcode": "SOAP-ENV:Client-5113"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("Não existem registros"))
                        return new ListarClienteResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ListarClienteResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClienteCadastro?> ConsultarClienteAsync(ClienteCadastroChave chave)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastroChave>("ConsultarCliente", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Cliente não cadastrado para o Código [999999999] !","faultcode": "SOAP-ENV:Client-105"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("não cadastrado"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ClienteCadastro>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClienteStatus> IncluirClienteAsync(ClienteCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastro>("IncluirCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ClienteStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClienteStatus> AlterarClienteAsync(ClienteCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastro>("AlterarCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }
                var model = JsonSerializer.Deserialize<ClienteStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        #endregion

        #region CadastroServico

        public async Task<ListarCadastroServicoResponse> ListarCadastroServicoAsync(ListarCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarCadastroServicoRequest>("ListarCadastroServico", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring":"ERROR: N\u00e3o existem registros para a p\u00e1gina [1]!","faultcode":"SOAP-ENV:Client-5113"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("Não existem registros"))
                        return new ListarCadastroServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ListarCadastroServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<CadastroServico?> ConsultarCadastroServicoAsync(CadastroServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<CadastroServicoChave>("ConsultarCadastroServico", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Serviço não cadastrado para o Código de integração do Serviço [teste-010] ! Tag [cCodIntServ]!","faultcode": "SOAP-ENV:Client-5002"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("não cadastrado"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<CadastroServico>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<IncluirCadastroServicoResponse> IncluirCadastroServicoAsync(IncluirCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<IncluirCadastroServicoRequest>("IncluirCadastroServico", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [20]!","faultcode": "SOAP-ENV:Client-5113"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("Não existem registros"))
                        return new IncluirCadastroServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<IncluirCadastroServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<AlterarCadastroServicoResponse> AlterarCadastroServicoAsync(AlterarCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<AlterarCadastroServicoRequest>("AlterarCadastroServico", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<AlterarCadastroServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        #endregion

        #region OrdemServico

        public async Task<ListarOrdemServicoResponse> ListarOrdemServicoAsync(ListarOrdemServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarOrdemServicoRequest>("ListarOS", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring":"ERROR: N\u00e3o existem registros para a p\u00e1gina [1]!","faultcode":"SOAP-ENV:Client-5113"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("Não existem registros"))
                        return new ListarOrdemServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }
                
                var model = JsonSerializer.Deserialize<ListarOrdemServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<OrdemServico?> ConsultarOrdemServicoAsync(OrdemServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServicoChave>("ConsultarOS", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring":"ERROR: OS n\u00e3o cadastrada para o C\u00f3digo de Integra\u00e7\u00e3o [99999999999] !","faultcode":"SOAP-ENV:Client-103"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("não cadastrada"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<OrdemServico>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<OrdemServicoStatus> IncluirOrdemServicoAsync(OrdemServico request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServico>("IncluirOS", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<OrdemServicoStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<OrdemServicoStatus> AlterarOrdemServicoAsync(OrdemServico request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServico>("AlterarOS", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<OrdemServicoStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<OrdemServicoStatus> ExcluirOrdemServicoAsync(OrdemServicoChave chave)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<OrdemServicoChave>("ExcluirOS", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<OrdemServicoStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        #endregion

        #region ContaCorrente

        public async Task<ListarContaCorrenteResponse> ListarContaCorrenteAsync(ListarContaCorrenteRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarContaCorrenteRequest>("ListarContasCorrentes", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring":"ERROR: Nenhuma conta corrente foi encontrada!","faultcode":"SOAP-ENV:Client-101"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("Nenhuma conta corrente"))
                        return new ListarContaCorrenteResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ListarContaCorrenteResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ContaCorrente?> ConsultarContaCorrenteAsync(ContaCorrenteChave chave)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrenteChave>("ConsultarContaCorrente", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ContaCorrente>(jsonResponse)!;

                if (model.nCodCC == 0)
                    return null;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ContaCorrenteStatus> IncluirContaCorrenteAsync(ContaCorrente request)
        {
            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrente>("IncluirContaCorrente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ContaCorrenteStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ContaCorrenteStatus> AlterarContaCorrenteAsync(ContaCorrente request)
        {
            //{"faultstring":"ERROR: A tag [pdv_sincr_analitica] somente deve ser informada quando a tag [tipo_conta_corrente] for igual a 'CC', 'AC', 'CX' ou 'CN' e a tag [pdv_enviar] for 'S' !","faultcode":"SOAP-ENV:Client-1020"}
            request.pdv_sincr_analitica = null;

            var relativeUrl = new Uri("/api/v1/geral/contacorrente/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaCorrente>("AlterarContaCorrente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ContaCorrenteStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        #endregion

        #region ContaReceber

        public async Task<ContaReceber?> ConsultarContaReceberAsync(ContaReceberChave chave)
        {
            var relativeUrl = new Uri("/api/v1/financas/contareceber/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ContaReceberChave>("ConsultarContaReceber", AppKey, AppSecret, chave);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);
            
            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(jsonResponse);

                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("já foi processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Lançamento não cadastrado para o Código [123] !", "faultcode": "SOAP-ENV:Client-105"}
                    if ((errorResponse?.ErrorMessage ?? "").Contains("não cadastrado"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error: {errorResponse?.ErrorCode} {errorResponse?.ErrorMessage} (API StatusCode: {(int)response.StatusCode})", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ContaReceber>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        #endregion
    }
}
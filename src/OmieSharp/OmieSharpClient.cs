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

        private JsonSerializerOptions _jsonSerializerOptions;

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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [1]!","faultcode": "SOAP-ENV:Client-5113"}
                    if (jsonResponse.Contains("N\\u00e3o existem registros"))
                        return new ListarClienteResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ListarClienteResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClienteCadastro?> ConsultarClienteAsync(ClienteCadastroChave request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClienteCadastroChave>("ConsultarCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Cliente não cadastrado para o Código [999999999] !","faultcode": "SOAP-ENV:Client-105"}
                    if (jsonResponse.Contains("Cliente n\\u00e3o cadastrado"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring":"ERROR: N\u00e3o existem registros para a p\u00e1gina [1]!","faultcode":"SOAP-ENV:Client-5113"}
                    if (jsonResponse.Contains("N\\u00e3o existem registros"))
                        return new ListarCadastroServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<ListarCadastroServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<CadastroServico?> ConsultarCadastroServicoAsync(CadastroServicoChave request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<CadastroServicoChave>("ConsultarCadastroServico", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Serviço não cadastrado para o Código de integração do Serviço [teste-010] ! Tag [cCodIntServ]!","faultcode": "SOAP-ENV:Client-5002"}
                    if (jsonResponse.Contains("Servi\\u00e7o n\\u00e3o cadastrado"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [20]!","faultcode": "SOAP-ENV:Client-5113"}
                    if (jsonResponse.Contains("N\\u00e3o existem registros para a p\\u00e1gina"))
                        return new IncluirCadastroServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<IncluirCadastroServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<IncluirCadastroServicoResponse> AlterarCadastroServicoAsync(AlterarCadastroServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/servico/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<AlterarCadastroServicoRequest>("IncluirCadastroServico", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: Não existem registros para a página [20]!","faultcode": "SOAP-ENV:Client-5113"}
                    if (jsonResponse.Contains("N\\u00e3o existem registros para a p\\u00e1gina"))
                        return new IncluirCadastroServicoResponse();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<IncluirCadastroServicoResponse>(jsonResponse)!;

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
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }
                
                var model = JsonSerializer.Deserialize<ListarOrdemServicoResponse>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<OrdemServico?> ConsultarOrdemServicoAsync(ConsultarOrdemServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ConsultarOrdemServicoRequest>("ConsultarOS", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    //{"faultstring": "ERROR: OS não cadastrada para o Código de Integração [999999999999] !","faultcode": "SOAP-ENV:Client-103"}
                    if (jsonResponse.Contains("OS não cadastrada"))
                        return null;

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
                }

                var model = JsonSerializer.Deserialize<OrdemServico>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClienteStatus> IncluirClienteAsync(IncluirOrdemServicoRequest request)
        {
            var relativeUrl = new Uri("/api/v1/servicos/os/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<IncluirOrdemServicoRequest>("IncluirOS", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest, _jsonSerializerOptions);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    //{"faultstring":"ERROR: Esta requisi\u00e7\u00e3o j\u00e1 foi processada ou est\u00e1 sendo processada e voc\u00ea pode tentar novamente \u00e0s 19:04:08. (1)","faultcode":"SOAP-ENV:Client-1100"}
                    if (jsonResponse.Contains("j\u00e1 foi processada ou est\u00e1 sendo processada"))
                        throw new OmieSharpDuplicateRequestException();

                    throw new OmieSharpWebException(response.StatusCode, $"Error statusCode: {(int)response.StatusCode}", jsonRequest, jsonResponse);
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
    }
}
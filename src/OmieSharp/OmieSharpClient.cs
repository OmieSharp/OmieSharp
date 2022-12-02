using OmieSharp.Exceptions;
using OmieSharp.Models;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace OmieSharp
{
    public class OmieSharpClient
    {
        public string AppKey { get; set; }
        public string AppSecret { get; set; }
        public string UserAgent { get; set; }
        public HttpClient HttpClient { get; private set; }
        private static readonly Uri baseUrl = new("https://app.omie.com.br/");

        public OmieSharpClient(string appKey, string appSecret, HttpClient httpClient)
        {
            ValidateAppKey(appKey);
            ValidateAppSecret(appSecret);

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

        #region Clientes

        public async Task<ListarClientesResponse> ListarClientesAsync(ListarClientesRequest request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ListarClientesRequest>("ListarClientes", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new OmieSharpException($"Error statusCode: {(int)response.StatusCode}");

                var model = JsonSerializer.Deserialize<ListarClientesResponse>(jsonResponse)!;

                return model;
            }
            catch (System.Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClientesCadastro> ConsultarClienteAsync(ClientesCadastroChave request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClientesCadastroChave>("ConsultarCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new OmieSharpException($"Error statusCode: {(int)response.StatusCode}");
                
                var model = JsonSerializer.Deserialize<ClientesCadastro>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClientesStatus> IncluirClienteAsync(ClientesCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClientesCadastro>("IncluirCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new OmieSharpException($"Error statusCode: {(int)response.StatusCode}");

                var model = JsonSerializer.Deserialize<ClientesStatus>(jsonResponse)!;

                return model;
            }
            catch (Exception ex)
            {
                throw new OmieSharpException($"Error in Omie API Call {relativeUrl} -- {ex.Message} -- Url: {fullUrl}", ex);
            }
        }

        public async Task<ClientesStatus> AlterarClienteAsync(ClientesCadastro request)
        {
            var relativeUrl = new Uri("/api/v1/geral/clientes/", UriKind.Relative);
            var fullUrl = new Uri(baseUrl, relativeUrl);
            var omieRequest = new OmieBaseRequest<ClientesCadastro>("AlterarCliente", AppKey, AppSecret, request);
            var jsonRequest = JsonSerializer.Serialize(omieRequest);

            try
            {
                var requestContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                requestContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await this.HttpClient.PostAsync(fullUrl, requestContent);

                var jsonResponse = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new OmieSharpException($"Error statusCode: {(int)response.StatusCode}");

                var model = JsonSerializer.Deserialize<ClientesStatus>(jsonResponse)!;

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
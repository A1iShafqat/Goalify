using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Extensions.Http;

namespace Goalify.Services.RequestProvider
{

    public class RequestProviderService : IRequestProvider
    {
        private readonly Lazy<HttpClient> _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerContext;
        private readonly ILogger<RequestProviderService> _logger;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

        public RequestProviderService(HttpMessageHandler? messageHandler, ILogger<RequestProviderService> logger)
        {
            _logger = logger;

            _httpClient = new Lazy<HttpClient>(() =>
            {
                var client = messageHandler is not null ? new HttpClient(messageHandler) : new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(30);
                return client;
            });

            _jsonSerializerContext = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = JsonNumberHandling.AllowReadingFromString,
            };

            // Retry policy: 3 retries with exponential backoff (2, 4, 8 seconds)
            _retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(3, attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                    (outcome, timespan, retryAttempt, context) =>
                    {
                        _logger.LogWarning("Retry {RetryAttempt} after {Delay}s due to transient failure.", retryAttempt, timespan.TotalSeconds);
                    });
        }

        // ===================== HTTP METHODS ===================== //

        public async Task<TResult> GetAsync<TResult>(string uri, string token = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.GetAsync(uri, cancellationToken));
                await HandleResponse(response);
                return await response.Content.ReadFromJsonAsync<TResult>(_jsonSerializerContext, cancellationToken) ??
                    throw new InvalidOperationException($"Response content could not be deserialized to {typeof(TResult).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GET {Uri} failed", uri);
                throw;
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data, string token = "", string header = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                if (!string.IsNullOrEmpty(header))
                    AddHeaderParameter(httpClient, header);

                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.PostAsJsonAsync(uri, data, _jsonSerializerContext, cancellationToken));
                await HandleResponse(response);
                return await response.Content.ReadFromJsonAsync<TResponse>(_jsonSerializerContext, cancellationToken) ??
                    throw new InvalidOperationException($"Response content could not be deserialized to {typeof(TResponse).Name}.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST {Uri} failed", uri);
                throw;
            }
        }

        public async Task<bool> PostAsync<TRequest>(string uri, TRequest data, string token = "", string header = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                if (!string.IsNullOrEmpty(header))
                    AddHeaderParameter(httpClient, header);

                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.PostAsJsonAsync(uri, data, _jsonSerializerContext, cancellationToken));
                await HandleResponse(response);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST {Uri} failed", uri);
                throw;
            }
        }

        public async Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(string.Empty);

            try
            {
                if (!string.IsNullOrWhiteSpace(clientId) && !string.IsNullOrWhiteSpace(clientSecret))
                    AddBasicAuthenticationHeader(httpClient, clientId, clientSecret);

                using var content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.PostAsync(uri, content, cancellationToken));
                await HandleResponse(response);
                return await response.Content.ReadFromJsonAsync<TResult>(_jsonSerializerContext, cancellationToken) ??
                    throw new InvalidOperationException($"Response content could not be deserialized to {typeof(TResult).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "POST (Basic Auth) {Uri} failed", uri);
                throw;
            }
        }

        public async Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                if (!string.IsNullOrEmpty(header))
                    AddHeaderParameter(httpClient, header);

                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.PutAsJsonAsync(uri, data, _jsonSerializerContext, cancellationToken));
                await HandleResponse(response);
                return await response.Content.ReadFromJsonAsync<TResult>(_jsonSerializerContext, cancellationToken) ??
                    throw new InvalidOperationException($"Response content could not be deserialized to {typeof(TResult).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "PUT {Uri} failed", uri);
                throw;
            }
        }

        public async Task DeleteAsync(string uri, string token = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.DeleteAsync(uri, cancellationToken));
                await HandleResponse(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "DELETE {Uri} failed", uri);
                throw;
            }
        }

        public async Task<TResult> PostFileAsync<TResult>(string uri, string filePath, string token = "", string header = "", CancellationToken cancellationToken = default)
        {
            var httpClient = GetOrCreateHttpClient(token);

            try
            {
                using var content = new MultipartFormDataContent();
                using var fileStream = File.OpenRead(filePath);
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                content.Add(fileContent, "file", Path.GetFileName(filePath));

                if (!string.IsNullOrEmpty(header))
                    AddHeaderParameter(httpClient, header);

                using var response = await _retryPolicy.ExecuteAsync(() => httpClient.PostAsync(uri, content, cancellationToken));
                await HandleResponse(response);
                return await response.Content.ReadFromJsonAsync<TResult>(_jsonSerializerContext, cancellationToken) ??
                    throw new InvalidOperationException($"Response content could not be deserialized to {typeof(TResult).Name}.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "File upload to {Uri} failed", uri);
                throw;
            }
        }

        // ===================== HELPERS ===================== //

        private HttpClient GetOrCreateHttpClient(string token = "")
        {
            var client = _httpClient.Value;
            client.DefaultRequestHeaders.Authorization = !string.IsNullOrEmpty(token)
                ? new AuthenticationHeaderValue("Bearer", token)
                : null;
            return client;
        }

        private static void AddHeaderParameter(HttpClient httpClient, string parameter)
        {
            if (!string.IsNullOrEmpty(parameter) && !httpClient.DefaultRequestHeaders.Contains(parameter))
                httpClient.DefaultRequestHeaders.Add(parameter, Guid.NewGuid().ToString());
        }

        private static void AddBasicAuthenticationHeader(HttpClient httpClient, string clientId, string clientSecret)
        {
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
        }

        private static async Task HandleResponse(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var content = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
                throw new ServiceAuthenticationException(content);

            throw new HttpRequestExceptionEx(response.StatusCode, content);
        }
    }

}

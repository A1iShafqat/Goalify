namespace Goalify.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult> GetAsync<TResult>(string uri, string token = "", CancellationToken cancellationToken = default);

        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data, string token = "", string header = "", CancellationToken cancellationToken = default);

        Task<bool> PostAsync<TRequest>(string uri, TRequest data, string token = "", string header = "", CancellationToken cancellationToken = default);

        Task<TResult> PostAsync<TResult>(string uri, string data, string clientId, string clientSecret, CancellationToken cancellationToken = default);

        Task<TResult> PutAsync<TResult>(string uri, TResult data, string token = "", string header = "", CancellationToken cancellationToken = default);

        Task DeleteAsync(string uri, string token = "", CancellationToken cancellationToken = default);

        Task<TResult> PostFileAsync<TResult>(string uri, string filePath, string token = "", string header = "", CancellationToken cancellationToken = default);
    }
}

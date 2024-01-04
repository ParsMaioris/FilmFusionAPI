public interface IHttpClientWrapper
{
    Task<T> GetAsync<T>(string requestUri) where T : new();
    Task<TResponse> PostAsync<TResponse, TRequest>(string requestUri, TRequest data) where TResponse : new();
}
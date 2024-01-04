using System.Text;
using Newtonsoft.Json;

public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient;
    private readonly ILoggerService _logger;

    public HttpClientWrapper(HttpClientSettings settings, ILoggerService logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(settings.BaseAddress)
        };
    }

    public async Task<T> GetAsync<T>(string uri) where T : new()
    {
        try
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent) ?? new T();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"Error fetching data from {uri}: {e.Message}");
            throw new ApplicationException($"Error fetching data from {uri}: {e.Message}", e);
        }
        catch (JsonException e)
        {
            _logger.LogError($"Error parsing response content for {uri}: {e.Message}");
            throw new ApplicationException($"Error parsing response content for {uri}.", e);
        }
        catch (Exception e)
        {
            _logger.LogError($"Unexpected error while fetching data from {uri}: {e.Message}");
            throw;
        }
    }

    public async Task<TResponse> PostAsync<TResponse, TRequest>(string uri, TRequest data) where TResponse : new()
    {
        try
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(responseContent) ?? new TResponse();
        }
        catch (HttpRequestException e)
        {
            _logger.LogError($"Error posting data to {uri}: {e.Message}");
            throw new ApplicationException($"Error posting data to {uri}: {e.Message}", e);
        }
        catch (JsonException e)
        {
            _logger.LogError($"Error parsing response content for {uri}: {e.Message}");
            throw new ApplicationException($"Error parsing response content for {uri}.", e);
        }
        catch (Exception e)
        {
            _logger.LogError($"Unexpected error while posting data to {uri}: {e.Message}");
            throw;
        }
    }
}
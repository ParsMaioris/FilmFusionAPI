using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

public class HttpClientWrapper : IHttpClientWrapper
{
    private readonly HttpClient _httpClient;
    private readonly ILoggerService _logger;
    private readonly string _apiKey;
    private readonly string _readAccessToken;

    public HttpClientWrapper(MoviesApiSetting settings, ILoggerService logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(settings.BaseAddress)
        };
        _apiKey = settings.ApiKey;
        _readAccessToken = settings.ReadAccessToken;

        if (!string.IsNullOrEmpty(_readAccessToken))
        {
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _readAccessToken);
        }
    }

    private HttpRequestMessage CreateRequest(HttpMethod method, string uri)
    {
        var request = new HttpRequestMessage(method, uri);

        if (!string.IsNullOrEmpty(_apiKey))
        {
            request.RequestUri = new Uri($"{_httpClient.BaseAddress}{uri}?api_key={_apiKey}");
        }

        return request;
    }

    public async Task<T> GetAsync<T>(string uri) where T : new()
    {
        try
        {
            var request = CreateRequest(HttpMethod.Get, uri);
            var response = await _httpClient.SendAsync(request);
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

            var request = CreateRequest(HttpMethod.Post, uri);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
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
public class MoviesApiSetting
{
    private string? _baseAddress;
    private string? _apiKey;
    private string? _readAccessToken;

    public string BaseAddress
    {
        get
        {
            if (_baseAddress == null)
            {
                throw new InvalidOperationException("BaseAddress is null.");
            }

            return _baseAddress;
        }
        set
        {
            _baseAddress = value;
        }
    }

    public string ApiKey 
    {
        get
        {
            if (_apiKey == null)
            {
                throw new InvalidOperationException("ApiKey is null.");
            }

            return _apiKey;
        }
        set
        {
            _apiKey = value;
        }
    }

    public string ReadAccessToken
    {
        get
        {
            if (_readAccessToken == null)
            {
                throw new InvalidOperationException("ReadAccessToken is null.");
            }

            return _readAccessToken;
        }
        set
        {
            _readAccessToken = value;
        }
    }
}
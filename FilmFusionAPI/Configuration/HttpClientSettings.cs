public class HttpClientSettings
{
    private string? _baseAddress;

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
}